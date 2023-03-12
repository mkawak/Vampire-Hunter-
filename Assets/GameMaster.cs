using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    //[SerializeField] public Transform player;
    [SerializeField] public int maxEnemies = 100;
    [SerializeField] public int secondsBetweenWaves = 10;
    [SerializeField] public GameObject enemy1; // enemy to spawn
    [SerializeField] public int enemiesPerWave = 5; 
    [SerializeField] public int targetFramesPerSecond = 60;
    [SerializeField] public Camera camera;

    //below vars are used to know the spawn limits on the current map, 
    // ignored since spawning at placeholder location
    [SerializeField] private float maxY = 590.0f;
    [SerializeField] private float minY = 657.0f;
    [SerializeField] private float maxX = 1072.0f;
    [SerializeField] private float minX = 427.0f;
    


    private int framesPassed = 0;
    private GameObject player;

    private List<GameObject> enemyList = new List<GameObject>();

    public void Awake()
    {
        instance = this;
        Application.targetFrameRate = targetFramesPerSecond;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // pass time until time to spawn wave
        if (++framesPassed >= secondsBetweenWaves * targetFramesPerSecond)
        {
            // reset timer
            framesPassed = 0;

            // spawn all enemies in a wave
            for (int i = 0; i < enemiesPerWave; ++i)
            {
                // ignore spawn if maxEnemies reached
                if (enemyList.Count < maxEnemies)
                {
                    int randomSide = Random.Range(0, 4);

                    // placeholder: spawn at center of map (x: 716, y: 401)                    
                    Vector3 spawnPosition = new Vector3(716.0f, 401.0f, 1f);
                    if (randomSide == 0)
                    {
                        Vector3 leftPosition = camera.ViewportToWorldPoint(new Vector3(-0.1f, Random.Range(-0.1f, 1.0f), 1f));
                        spawnPosition = leftPosition;
                    }
                    else if (randomSide == 1)
                    {
                        Vector3 rightPosition = camera.ViewportToWorldPoint(new Vector3(1.0f, Random.Range(-0.1f, 1.0f), 1f));
                        spawnPosition = rightPosition;
                    }
                    else if (randomSide == 2)
                    {
                        Vector3 topPosition = camera.ViewportToWorldPoint(new Vector3(Random.Range(-0.1f, 1.0f), 1.0f, 1f));
                        spawnPosition = topPosition;
                    }
                    else
                    {
                        Vector3 bottomPosition = camera.ViewportToWorldPoint(new Vector3(Random.Range(-0.1f, 1.0f), -0.1f, 1f));
                        spawnPosition = bottomPosition;
                    }
                    /*if(spawnPosition.x >= maxX)
                    {
                        spawnPosition.x = maxX;
                    }
                    if (spawnPosition.x <= minX)
                    {
                        spawnPosition.x = minX;
                    }
                    if (spawnPosition.y >= maxY)
                    {
                        spawnPosition.y = maxY;
                    }
                    if (spawnPosition.y <= minY)
                    {
                        spawnPosition.y = minY;
                    }*/

                    // spawn enemy
                    GameObject newEnemy = Instantiate(enemy1);

                    // get enemy object
                    Enemy newSpawn = newEnemy.GetComponent<Enemy>();

                    // move enemy to spawnPosition and assign the player as target for enemy
                    newEnemy.transform.position = spawnPosition;
                    //newSpawn.player = this.player;
                    newSpawn.player = this.player.transform;

                    // add enemy in the list of spawned enemies
                    enemyList.Add(newEnemy);
                }
            }

        }
    }
}
