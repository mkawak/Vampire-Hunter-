using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject Hell_Boss_1;

    private float Hell_Boss_1_Interval = 3.5f; //number of seconds in between spawns

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(Hell_Boss_1_Interval, Hell_Boss_1));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy) //to perform something aftre a fixed amount of time
    {
        yield return new WaitForSeconds(interval);
        //Instantiate: params: (game object, position of object, angle)
        //currently spawns enemy at random place in the game
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
