using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 6f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    public Camera playerCamera;
    public FixedJoystick joystick;
    public Button jumpButton;
    private bool isJumping;
    void Start()
    {
#if UNITY_STANDALONE
        joystick.gameObject.SetActive(false);
        jumpButton.gameObject.SetActive(false);
#elif UNITY_ANDROID || UNITY_IOS
        joystick.gameObject.SetActive(true);
        jumpButton.gameObject.SetActive(true);
#endif
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        jumpButton.onClick.AddListener(OnJumpButtonPressed);
    }
    void Update()
    {
#if UNITY_STANDALONE
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = moveSpeed * Input.GetAxis("Vertical");
        float curSpeedY =  moveSpeed * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
#elif UNITY_ANDROID || UNITY_IOS
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = moveSpeed * joystick.Vertical;  
        float curSpeedY = moveSpeed * joystick.Horizontal;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        if (characterController.isGrounded && isJumping)
        {
            moveDirection.y = jumpPower;
            isJumping = false;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
#endif
        characterController.Move(moveDirection * Time.deltaTime);
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
    private void OnJumpButtonPressed()
    {
        if (characterController.isGrounded)
        {
            isJumping = true;
        }
    }
}