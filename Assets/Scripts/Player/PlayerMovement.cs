using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    Vector3 activeMoveSpeed;
    public float acceleration = 2f;
    public float gravity = -10f;
    public float jumpGrav = -5f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;

#if ENABLE_INPUT_SYSTEM
    InputAction movement;

    void Start()
    {
        movement = new InputAction("PlayerMovement", binding: "<Gamepad>/leftStick");
        movement.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/s")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/a")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/d")
            .With("Right", "<Keyboard>/rightArrow");


        movement.Enable();
    }

#endif

    // Update is called once per frame
    void Update()
    {
        float x;
        float z;
        bool jumpPressed = false;

#if ENABLE_INPUT_SYSTEM
        var delta = movement.ReadValue<Vector2>();
        x = delta.x;
        z = delta.y;
#else
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        jumpPressed = Input.GetButtonDown("Jump");
#endif

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGrounded);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        activeMoveSpeed = Vector3.Lerp(activeMoveSpeed, move * speed, acceleration * Time.deltaTime);

        controller.Move(activeMoveSpeed * Time.deltaTime);

        //if (jumpPressed && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //}

        if (velocity.y > 0)
        {
            velocity.y += jumpGrav * Time.deltaTime;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && gameObject.scene.IsValid())
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else
        {
            Debug.Log("Cant jump");
        }
    }
}
