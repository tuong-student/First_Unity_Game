using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyRefrence;

    private GameObject spawedEnemy;

    [SerializeField]
    private Transform Open_Door, Close_Door;

    private int randomIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    private void Update()
    {
        
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
                spawedEnemy.transform.position = Open_Door.position;
                spawedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 6);
                spawedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                //right side
                spawedEnemy.transform.position = Close_Door.position;
                spawedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 6);
            }

        }

    }
    
}
