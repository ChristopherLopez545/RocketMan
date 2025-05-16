using UnityEngine;
using UnityEngine.SceneManagement;
public class Obstacle : MonoBehaviour
{
    private GameObject player;
    public GameObject gameOverPanel;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player") ;  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border" )
        {
            Destroy(this.gameObject);
            Destroy(player.gameObject);
            //GameOver.Restart();
         //   gameOverPanel.SetActive(true);
        }   
        else if(collision.tag == "Player")
        {
            Destroy(player.gameObject);
        }
        else if(collision.tag == "Projectile")
        {
            Destroy(this.gameObject);
        }
    }

}
