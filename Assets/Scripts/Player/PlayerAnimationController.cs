using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.x > 0)
        {
            sr.flipX = false;
        }
        else if (rb.linearVelocity.x < 0)
        {
            sr.flipX = true;
        }
    }
}
