using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    public float spawnTime;

public float decreaseRate = 0.01f; // how much faster it gets per spawn
public float minSpawnTime = 0.3f;  // lowest allowed spawn interval

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
            // Speed up spawn rate
        if (timeBetweenSpawn > minSpawnTime)
            timeBetweenSpawn -= decreaseRate;
        }
    }

    void Spawn ()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY,maxY);

        Instantiate(obstacle,transform.position+ new Vector3(randomX,randomY,0),transform.rotation);
    }
}
