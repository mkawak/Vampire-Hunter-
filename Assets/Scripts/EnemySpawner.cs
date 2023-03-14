using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // private GameObject Hell_Boss_1;
    public List<Enemy> level1Enemies;
    public List<Enemy> level2Enemies;
    public List<Enemy> level3Enemies;
    public List<Enemy> level4Enemies;
    private List<List<Enemy>> enemies;

    public Transform leftPos, rightPos, topPos, bottomPos;

    private float Hell_Boss_1_Interval = 1.2f; //number of seconds in between spawns
    private int randomSide;
    private int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(Hell_Boss_1_Interval));
        enemies = new List<List<Enemy>>() {level1Enemies, level2Enemies, level3Enemies, level4Enemies};
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnEnemy(float interval) //to perform something after a fixed amount of time
    {
        yield return new WaitForSeconds(interval);

        randomSide = Random.Range(0, 4);

        int randEnemy = Random.Range(0, enemies[level - 1].Count);

        Enemy newEnemy = Instantiate(enemies[level - 1][randEnemy]);
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

        // Circle equation

        StartCoroutine(spawnEnemy(interval));
    }

    public void LevelUp() {
        if (level == 4) return;
        level++;
        Hell_Boss_1_Interval -= 0.3f;
    }
}
