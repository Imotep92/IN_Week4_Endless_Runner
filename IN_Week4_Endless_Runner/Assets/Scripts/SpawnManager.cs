using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    #region obstacles

    public GameObject[] obstaclePrefabs;  //list of obstacles that cause gameover state

    private Vector3 spawnPos = new Vector3(45, 0, 0);  //spawn position for obstacles ONLY

    private float startDelay = 2; //start delay for obstacles ONLY

    private float spawnInterval;  //random rate spawn for obstacles ONLY

    #endregion obstacles


    #region Scenery

    public GameObject[] sceneryPrefabs; //list of SceneryPrefabs 

    private Vector3 spawnSceneryPos = new Vector3(45, 0, 2);

    private float startSceneryDelay = 2;

    private float spawnSceneryInterval;

    #endregion Scenery


    private PlayerController playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        Invoke("SpawnObstacle", startDelay); //initial spawn for obstacle prefabs

        Invoke("SceneryObstacle", startSceneryDelay); //initial spawn for scenery prefabs

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        int obstaclesIndex = Random.Range(0, obstaclePrefabs.Length);

        if (playerControllerScript.isDead == false) //change bool from "gameOver" to "isdead"
        {
            Instantiate(obstaclePrefabs[obstaclesIndex], spawnPos, obstaclePrefabs[obstaclesIndex].transform.rotation);
        }

        spawnInterval = Random.Range(4f, 6f);
        Invoke("SpawnObstacle", spawnInterval);
    }

    void SceneryObstacle()
    {
        int sceneryObstacleIndex = Random.Range(0, sceneryPrefabs.Length);

        if (playerControllerScript.isDead == false)
        {
            Instantiate(sceneryPrefabs[sceneryObstacleIndex], spawnSceneryPos, sceneryPrefabs[sceneryObstacleIndex].transform.rotation);
        }

        spawnSceneryInterval = Random.Range(8f, 12f);
        Invoke("SceneryObstacle", spawnSceneryInterval);
    }
  
}
