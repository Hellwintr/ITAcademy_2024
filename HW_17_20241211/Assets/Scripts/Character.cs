using System;
using Unity.Mathematics;
using UnityEngine;

public class Character: MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    Camera characterCamera;
    
    public float moveSpeed = 2f;
    public float sprintSpeed = 5.0f;
    public float jumpSpeed = 3f;
    public float rotationSpeed = 0.2f;
    public float animationBlendSpeed = 0.2f;
    public Transform respawnPoint;
    
    float rotationAngle = 0.0f;
    float targetAnimationSpeed = 0.0f;
    float speedY = 0.0f;
    float gravity = -9.81f;
    bool isSprint = false;
    bool isJumping = false;
    bool isDead = false;

    public CharacterController Controller { get { return characterController = characterController ?? GetComponent<CharacterController>(); } }
    public Camera CharacterCamera { get { return characterCamera = characterCamera ?? FindFirstObjectByType<Camera>(); } }
    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    private void Update()
    {
        if (!isDead)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                isJumping = true;
                CharacterAnimator.SetTrigger("Jump");
                speedY += jumpSpeed;
            }

            if (!Controller.isGrounded)
            {
                speedY += gravity * Time.deltaTime;
            }
            else if (speedY < 0f)
            {
                speedY = 0f;
            }

            CharacterAnimator.SetFloat("SpeedY", speedY / jumpSpeed);
            if (isJumping && speedY < 0f)
            {
                if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f,
                        LayerMask.GetMask("Default")))
                {
                    isJumping = false;
                    CharacterAnimator.SetTrigger("Land");
                }
            }

            isSprint = Input.GetKey(KeyCode.LeftShift);
            Vector3 movement = new Vector3(horizontal, 0, vertical);
            Vector3 rotatedMovement = Quaternion.Euler(0.0f, CharacterCamera.transform.rotation.eulerAngles.y, 0.0f) * movement.normalized;
            Vector3 verticalMovement = Vector3.up * speedY;
            float currentSpeed = isSprint ? sprintSpeed : moveSpeed;
            Controller.Move(verticalMovement + rotatedMovement * (currentSpeed * Time.deltaTime));
            if (rotatedMovement.sqrMagnitude > 0)
            {
                rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                targetAnimationSpeed = isSprint ? 1f : 0.5f;
            }
            else
            {
                targetAnimationSpeed = 0f;
            }

            if (Input.GetKey(KeyCode.Backspace))
            {
                isDead = true;
                CharacterAnimator.SetTrigger("Death");
            }

            if (Input.GetButtonDown("Fire1"))
            {
                CharacterAnimator.SetTrigger("Punch");
            }

            CharacterAnimator.SetFloat("Speed", Mathf.Lerp(CharacterAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
            Quaternion currentRotation = Controller.transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0, rotationAngle, 0);
            Controller.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);
        }
        if (Input.GetKey(KeyCode.Return) && isDead)
        {
                Controller.enabled = false;
                transform.position = respawnPoint.transform.position;
                Controller.enabled = true;
                CharacterAnimator.SetTrigger("Respawn");
                isDead = false;
        }
        
    }

    private void OnTriggerEnter(Collider obstacle)
    {
        Debug.Log($"Столкновение с объектом: {obstacle.gameObject.name}");
        if (obstacle.CompareTag("Obstacle"))
        {
            isDead = true;
            CharacterAnimator.SetTrigger("Death");
        }
    }
}
