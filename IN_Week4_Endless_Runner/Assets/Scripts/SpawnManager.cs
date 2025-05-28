using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstaclePrefabs;

    private Vector3 spawnPos = new Vector3(45, 0, 0);

    private float startDelay = 2;

    private float repeatRate = 2;

    private PlayerController playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int obstaclesIndex = Random.Range(0, obstaclePrefabs.Length);

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefabs[obstaclesIndex], spawnPos, obstaclePrefabs[obstaclesIndex].transform.rotation);
        }
    }
}
