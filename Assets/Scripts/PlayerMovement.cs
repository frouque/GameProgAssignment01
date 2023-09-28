using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float mouseSensitivy = 5.0f;
    public bool hasDoubleJumpPowerUp;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private float walkSpeed = 5;
    private float runSpeed = 8;
    private Animator animator;
    private Vector3 movement;
    private bool hasDoubleJump;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        //UpdateRotation();
        ProcessMovement();
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void LateUpdate()
    {
        UpdateAnimator();
    }
    void UpdateRotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivy, 0, Space.Self);

    }

    void ProcessMovement()
    {
        // Moving the character forward according to the speed
        float speed = GetMovementSpeed();

        // Get the camera's forward and right vectors
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Make sure to flatten the vectors so that they don't contain any vertical component
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalize the vectors to ensure consistent speed in all directions
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction based on input and camera orientation
        Vector3 moveDirection = (cameraForward * Input.GetAxis("Vertical")) + (cameraRight * Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            transform.forward = moveDirection;
        }
        // Apply the movement direction and speed
        movement = moveDirection.normalized * speed * Time.deltaTime;

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            if (hasDoubleJumpPowerUp)
            {
                hasDoubleJumpPowerUp = false;
                hasDoubleJump = true;
            }
            if (Input.GetButtonDown("Jump"))
            {
                gravity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                animator.SetTrigger("DoJump");
            }
            else
            {
                // Dont apply gravity if grounded and not jumping
                gravity.y = -1.0f;
            }
        }
        else if (Input.GetButtonDown("Jump") && hasDoubleJump)
        {
            animator.SetTrigger("DoDoubleJump");
            gravity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            hasDoubleJump = false;
        }
        else
        {
            // Since there is no physics applied on character controller we have this applies to reapply gravity
            gravity.y += gravityValue * Time.deltaTime;
        }
        // Apply gravity and move the character
        playerVelocity = gravity * Time.deltaTime + movement;
        controller.Move(playerVelocity);
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }

    void UpdateAnimator()
    {
        bool isGrounded = controller.isGrounded;
        float currentSpeed = GetMovementSpeed();

        if (movement != Vector3.zero)
        {
            if (GetMovementSpeed() == runSpeed)
            {
                animator.SetFloat("Speed", 1.0f);
            }
            else
            {
                animator.SetFloat("Speed", 0.5f);
            }
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }
        animator.SetBool("IsGrounded", isGrounded);

    }
}
