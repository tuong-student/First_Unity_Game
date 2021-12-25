using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyRefrence;

    private GameObject spawedEnemy;

    [SerializeField]
    private Transform[] Right_Open_Doors;

    [SerializeField]
    private Transform[] Left_Open_Doors;

    private int randomIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {

        while (true)
        {

            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, enemyRefrence.Length);
            randomSide = Random.Range(0, 2);

            spawedEnemy = Instantiate(enemyRefrence[randomIndex]);

            //left side
            if (randomSide == 0)
            {
                //Pick random left to spawn enemy
                int LeftRandomIndex = Random.Range(0, Left_Open_Doors.Length);
                spawedEnemy.transform.position = Left_Open_Doors[LeftRandomIndex].position;
                spawedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 10);
                spawedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f); //turn sprite
            }
            else
            {
                //right side
                int RightRandomIndex = Random.Range(0, Right_Open_Doors.Length);
                spawedEnemy.transform.position = Right_Open_Doors[RightRandomIndex].position;
                spawedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 10);
            }

        }

    }
    
}
