using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector2 input;
    private Rigidbody2D rb;

    [Header("Movement variables")]
    public float speed;
    public float jumpHeight;
    
    [Header("Raycast variables")]
    public LayerMask groundLayer;
    public float rayDistance;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(input.x * speed, rb.linearVelocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        bool canJump = Physics2D.Raycast(transform.position, Vector2.down, rayDistance,  groundLayer);

        if (context.performed && canJump)
        {
            rb.AddForceY(jumpHeight, ForceMode2D.Impulse);
        }
    }
    
    public void GetMoveInput(InputAction.CallbackContext context)
    {
         input = context.ReadValue<Vector2>();
    }
}
