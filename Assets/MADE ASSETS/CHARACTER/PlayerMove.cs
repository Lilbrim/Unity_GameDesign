using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpH = 3f;

    public float Sprint = 20f;

    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isgrounded;

    // Update is called once per frame
    void Update()
{
    isgrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask.value);
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    if (isgrounded && velocity.y < 0)
    {
        velocity.y = -4f;
    }

    Vector3 move = transform.right * x + transform.forward * z;

    // Check if sprinting
    if (Input.GetKey("left shift") && isgrounded)
    {
        speed = Sprint;
    }
    else
    {
        // Reset speed when shift is released
        speed = 12f;  // Normal walking speed
    }

    controller.Move(move * speed * Time.deltaTime);

    if (Input.GetButtonDown("Jump") && isgrounded)
    {
        velocity.y = Mathf.Sqrt(jumpH * -2f * gravity);
    }

    velocity.y += gravity * Time.deltaTime;

    controller.Move(velocity * Time.deltaTime);
}
}
