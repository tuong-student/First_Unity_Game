using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    [SerializeField] Transform[] leftDoors, rightDoors;

    GameObject spawnEnemy;
    int randomEnemyIndex, randomDoorIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());   
        StartCoroutine(SpawnEnemy());   
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {

            yield return new WaitForSeconds(Random.Range(2f, 7f));

            Debug.Log("Spawn enemy");

            randomEnemyIndex = Random.Range(0, enemys.Length);
            randomDoorIndex = Random.Range(0, leftDoors.Length);
            randomSide = Random.Range(0, 2);

            spawnEnemy = Instantiate(enemys[randomEnemyIndex]);

            if (randomSide == 0)
            {
                // left side
                spawnEnemy.transform.position = leftDoors[randomDoorIndex].position;
                EnemyScript enemyScript = spawnEnemy.GetComponent<EnemyScript>();
                enemyScript.movementX = 1;
                enemyScript.move_force = Random.Range(5f, 10f);
            }
            else
            {
                // right side
                spawnEnemy.transform.position = rightDoors[randomDoorIndex].position;
                EnemyScript enemyScript = spawnEnemy.GetComponent<EnemyScript>();
                enemyScript.movementX = -1;
                enemyScript.move_force = Random.Range(5f, 10f);
            }
        }

    }
}
