using UnityEngine;

//This is a failsafe so RB + Animator doesn't get removed.
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    // Configurable Variables
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Animator animator;

    //Pull our input so that we can see what our input values are. 

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator an;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        bool jumpInput = Input.GetButtonDown("Jump");
        // Move our player horizontally based on the horz input value.
        rb.linearVelocityX = horizontalInput * moveSpeed;
        if (horizontalInput > 0.01f)
        {
            sr.flipX = false;
        }
        else if (horizontalInput < -0.01f)
        {
            sr.flipX = true;
        }
        // Jump logic
        if (jumpInput)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (horizontalInput != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }
}
