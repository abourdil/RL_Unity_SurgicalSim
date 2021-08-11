﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System;

public class ConeControl : MonoBehaviour
{

    private ConeMovement cone; // Reference to the cone controller.

    private Vector3 move;
    // the world-relative desired move direction, calculated from the camForward and user input.

    private Transform cam; // A reference to the main camera in the scenes transform
    private Vector3 camForward; // The current forward direction of the camera
                                //private bool jump; // whether the jump button is currently pressed

    // Use this for initialization
    void Start()
    {
        // Set up the reference.
        cone = GetComponent<ConeMovement>();
        print("hi");
        // get the transform of the main camera
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("Warning: no main camera found. Cone needs a Camera tagged \"MainCamera\", for camera-relative controls.");
            // we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get the axis and jump input.

        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        float jump = CrossPlatformInputManager.GetAxis("Jump");
        print(jump);
        if (jump != 0) { print(jump); }

        // calculate move direction including jump
        if (cam != null)
        {
            // calculate camera relative direction to move:
            camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            move = (v * camForward + h * cam.right + jump * cam.up).normalized;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            move = (v * Vector3.forward + h * Vector3.right + jump * Vector3.up).normalized;
        }

    }

    private void FixedUpdate()
    {
        // Call the Move function of the cone controller
        cone.Move(move);
    }
}
