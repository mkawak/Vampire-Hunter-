using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject Hell_Boss_1;

    [SerializeField]
    private Transform leftPos, rightPos, topPos, bottomPos;

    private float Hell_Boss_1_Interval = 3.5f; //number of seconds in between spawns
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(Hell_Boss_1_Interval, Hell_Boss_1));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy) //to perform something after a fixed amount of time
    {
        yield return new WaitForSeconds(interval);

        randomSide = Random.Range(0, 4);

        GameObject newEnemy = Instantiate(enemy);
        if(randomSide == 0)
        {
            newEnemy.transform.position = topPos.transform.position;
        } else if (randomSide == 1)
        {
            newEnemy.transform.position = rightPos.transform.position;
        } else if (randomSide == 2)
        {
            newEnemy.transform.position = bottomPos.transform.position;
        } else
        {
            newEnemy.transform.position = leftPos.transform.position;
        }

        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
