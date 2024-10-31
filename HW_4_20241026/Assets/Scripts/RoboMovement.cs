using System;
using UnityEngine;

public class RoboMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    private Rigidbody _rigidbody;
   void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX |  RigidbodyConstraints.FreezeRotationZ;
    }
    private void Update()
    {
        float sideForce = Input.GetAxis("Horizontal") * turnSpeed;
        if (sideForce != 0f)
        {
            _rigidbody.angularVelocity = new Vector3(0f, sideForce, 0f);
        }
        float forwardForce = Input.GetAxis("Vertical") * moveSpeed;
        if (forwardForce != 0f)
        {
                _rigidbody.linearVelocity = _rigidbody.transform.forward * forwardForce;
        }
    }
}
