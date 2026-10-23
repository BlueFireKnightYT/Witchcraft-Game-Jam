using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector2 input;
    private Rigidbody2D rb;

    private int rabbitLayer;
    private bool isDashing = false;
    private bool canDash = true;

    [Header("Movement variables")]
    public float speed;
    public float dashBoost;
    public float jumpHeight;
    
    [Header("Raycast variables")]
    public LayerMask groundLayer;
    public float rayDistance;
    
    void Start()
    {
        rabbitLayer = LayerMask.NameToLayer("RabbitPlayer");
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if(!isDashing)
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

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && gameObject.layer == rabbitLayer && canDash)
        {
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        isDashing = true;
        rb.AddForceX(input.x * dashBoost, ForceMode2D.Impulse);
        Debug.Log("DASH!");
        yield return new WaitForSeconds(0.2f);
        isDashing = false;
    }
    
    public void GetMoveInput(InputAction.CallbackContext context)
    {
         input = context.ReadValue<Vector2>();
    }
}
