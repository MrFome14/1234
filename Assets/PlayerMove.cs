using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2, runSpeed = 4, jumpPower = 10;
    public float MouseX = 10, MouseY = 10;

    private Rigidbody rbody;

    public float max_angle = 70, min_angle = -60;

    public Transform camer;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }
    bool jumpCommand = false;
    float angle = 0;
    
    void Update()
    {
        jumpCommand |= Input.GetButtonDown("Jump");
        var mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.rotation *= Quaternion.Euler(0, mouseInput.x * MouseX * Time.deltaTime, 0);
        angle = Mathf.Clamp(angle - mouseInput.y * MouseY * Time.deltaTime, -max_angle, -min_angle);
        camer.localRotation = Quaternion.Euler(angle, 0, 0);
    }

    private void FixedUpdate()
    {
        var motionInput = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        motionInput.x += rbody.velocity.x;
        motionInput.z += rbody.velocity.z;
        var speed = Input.GetButton("Fire3") ? runSpeed : moveSpeed;
        motionInput = Vector3.ClampMagnitude(motionInput, speed);

        motionInput.y = rbody.velocity.y;
        //print($"Motion: {motionInput}, Jump: {jumpCommand}");

        if (jumpCommand)
        {
            jumpCommand = false;
            motionInput.y = jumpPower;
        }
        rbody.velocity = motionInput;
    }
}
