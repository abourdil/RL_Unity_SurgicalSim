using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConeMovement : MonoBehaviour
{

    //[SerializeField] private float m_MovePower = 5; // The force added to the cone to move it.
    //[SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the cone.
    [SerializeField] private float m_MaxAngularVelocity = 0; // The maximum velocity the cone can rotate at.
    //[SerializeField] private float m_JumpPower = 2; // The force added to the cone when it jumps.

    private const float k_GroundRayLength = 1f; // The length of the ray to check if the cone is grounded.
    private Rigidbody m_Rigidbody;

    // Use this for initialization
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        // Set the maximum angular velocity.
        GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;

        Vector3 tempForce = Vector3.forward;
        m_Rigidbody.AddForce(tempForce);
    }

    public void Move(Vector3 moveDirection)
    {
        // Otherwise add force in the move direction.
        // m_Rigidbody.AddForce(moveDirection * m_MovePower);
        m_Rigidbody.position = m_Rigidbody.position + moveDirection / 50;

        // If on the ground and jump is pressed...
        //if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength)) {
        // ... add force in upwards.
        //    m_Rigidbody.AddForce(Vector3.up * m_JumpPower, ForceMode.Impulse);
        //}
    }
}
