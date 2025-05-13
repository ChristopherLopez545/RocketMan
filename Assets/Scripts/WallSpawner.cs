using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public Transform spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnWall", 1f, 15f); // call SpawnWall() every 2 sec
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnWall()
{
   Vector3 spawnPos = new Vector3(Camera.main.transform.position.x + 10f, Random.Range(-2f, 2f), 0f);
    GameObject wall = Instantiate(wallPrefab, spawnPos, Quaternion.identity);

    float randomHeight = Random.Range(1f, 5f);
    wall.transform.localScale = new Vector3(1, randomHeight, 1);
}
}
