using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;
    public float speed = 5f;
    public float jumpSpeed = 10;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    float speedY = 0;
    float gravity = -9.81f;
    bool isJumping = false;

    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

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
        }

        Vector3 verticalMovement = Vector3.up * speedY;
        controller.Move(verticalMovement * Time.deltaTime);
        
        Vector3 direction = new Vector3(x, 0, z).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}
