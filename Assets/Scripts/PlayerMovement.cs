using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public InputAction moveAction;       // Reference to the Move action from the Input Action Asset
    public float moveSpeed = 10f;        // Speed of player movement
    private Rigidbody2D rb;              // Reference to the Rigidbody2D component
    private Animator animator;           // Reference to the animator (AC_Player)
    private Vector2 moveInput;           // Store the player's movement input

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();

        // Get the animator component attached to the player
        animator = GetComponent<Animator>();

        // Enable the move action
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Read the movement input (WASD, Gamepad stick) and store it in moveInput
        moveInput = moveAction.ReadValue<Vector2>();

        // If the player is moving, update the animator with movement direction
        if (moveInput != Vector2.zero)
        {
            // Set the XInput and YInput so the animator knows which direction the player is moving
            animator.SetFloat("XInput", moveInput.x);
            animator.SetFloat("YInput", moveInput.y);
        }
        else
        {
            animator.SetFloat("XInput", 0);
            animator.SetFloat("YInput", 0);
        }
        
    }

    // FixedUpdate is called at fixed intervals and is used for physics updates
    void FixedUpdate()
    {
        // Use MovePosition for smooth kinematic movement
        Vector2 targetPosition = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;

        // Move the Rigidbody2D to the new position while respecting collisions
        rb.MovePosition(targetPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Foreground")
        {
            Debug.Log("wall hit");
        }
        if (collision.gameObject.tag == "Stone")
        {
            PlayStoryEnd();
        }
    }

    public void PlayStoryEnd()
    {
        SceneManager.LoadScene("StoryEnd");
    }
}
