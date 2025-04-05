using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed ;
    [SerializeField] private float JumpMultiplier;
     [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private float HorizontalInput;
    private BoxCollider2D boxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
         boxCollider = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
         HorizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(HorizontalInput * speed,body.linearVelocityY);
        if(Input.GetKey(KeyCode.Space))
        {
            body.linearVelocity = new Vector2(body.linearVelocityX,speed);
        }
        // flipping the character
        if(HorizontalInput > 0.01f)
        {  
            transform.localScale =new Vector3(4.78818f,4.060786f,1);
         }
         else if(HorizontalInput < -0.01f )
         {
            transform.localScale = new Vector3(-4.78818f,4.060786f,1);
         }

        if(Input.GetKey(KeyCode.A))
        {

        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
     private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return HorizontalInput == 0;
    }

}
