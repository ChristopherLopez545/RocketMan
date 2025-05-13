using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public Transform spawnPoint;

    void Start()
    {
        InvokeRepeating("SpawnPowerUp", 5f, 20f); // start after 5s, repeat every 15s
    }

    void SpawnPowerUp()
    {
        Vector3 spawnPos = new Vector3(
            Camera.main.transform.position.x + 10f, // ahead of the player
            Random.Range(-2f, 2f),                  // random vertical pos
            0f
        );

        Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
    }
}