using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private float horizontalInput;
    private BoxCollider2D boxCollider;

     void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Only jump if grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            groundLayer
        );
        return hit.collider != null;
    }
}