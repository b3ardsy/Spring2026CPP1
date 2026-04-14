using UnityEngine;

//This is a failsafe so RB doesn't get removed.
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    // Configurable Variables
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    //Pull our input so that we can see what our input values are. 

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetButtonDown("Jump");
        // Move our player horizontally based on the horz input value.
        rb.linearVelocityX = horizontalInput * moveSpeed;
        // Jump logic
        if (jumpInput)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }
}
