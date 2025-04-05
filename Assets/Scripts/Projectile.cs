using System;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float direction;
    [SerializeField] private float speed;
    private bool hit;
    private BoxCollider2D boxCollider;
    private Animator anim;
    private float lifetime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
            //return;
        }
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed,0,0);
          lifetime += Time.deltaTime;
        if (lifetime > 2) 
            gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("Explode");
    }
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        if (boxCollider == null)
           boxCollider = GetComponent<BoxCollider2D>();
        
        
        direction = _direction;

        gameObject.SetActive(true);

        hit = false;

        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(MathF.Sign(localScaleX) != _direction)
        {
            localScaleX= -localScaleX; // this flips the ball 
        }
           transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
     private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
