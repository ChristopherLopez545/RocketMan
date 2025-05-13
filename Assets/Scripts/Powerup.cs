using UnityEngine;

public class Powerup : MonoBehaviour
{
    // find the player 
    private GameObject player;

    public GameObject Wall_buster;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player") ;  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player"))
    {
        PlayerAttacks attackScript = player.GetComponent<PlayerAttacks>();
        if (attackScript != null)
        {
            attackScript.powerShots.Add(Wall_buster); // push it into the list
        }

        Destroy(gameObject); // remove the power-up from scene
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
