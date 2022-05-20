using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform mainCamera;
    public float speed = 5f;
    public float sprintSpeed = 8f;
    public float jumpSpeed = 10;
    public float gravity = -9.81f;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private float speedY = 0;
    private bool isJumping = false;
    private bool isSprinting = false;

    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        CheckMovement();
        CheckJump();
    }

    private void CheckMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        isSprinting = Input.GetKey(KeyCode.LeftShift) ? true : false;

        Vector3 movement = new Vector3(x, 0, z).normalized;

        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            float targetSpeed = isSprinting ? sprintSpeed: speed;

            controller.Move(moveDirection.normalized * targetSpeed * Time.deltaTime);
        }
    }

    private void CheckJump()
    {
        if (!controller.isGrounded)
        {
            speedY += gravity * Time.deltaTime;
        }
        else
        {
            speedY = 0;
            isJumping = false;
        }

        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            speedY += jumpSpeed;
            isJumping = true;
            AudioManager.PlayJumpSound();
            Debug.Log("Jump");
        }

        Vector3 verticalMovement = Vector3.up * speedY;
        controller.Move(verticalMovement * Time.deltaTime);
    }


}
