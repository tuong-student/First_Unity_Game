using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]
    GameObject[] Items;
    GameObject Spawnitem;

    [SerializeField]
    Transform[] SpawnPositions;


    //Variable
    int RandomIndex;
    int oldRandomPosition;
    int RandomPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 10));

            //Creat item
            RandomIndex = Random.Range(0, Items.Length);
            while(RandomPosition == oldRandomPosition)
            {
                RandomPosition = Random.Range(0, SpawnPositions.Length);
            }
            oldRandomPosition = RandomPosition;

            Spawnitem = Instantiate(Items[RandomIndex]);

            Debug.Log("Old position" + oldRandomPosition);
            Debug.Log("new positon" + RandomPosition);
            Debug.Log("Item created");
            Spawnitem.transform.position = SpawnPositions[RandomPosition].position;

            //Destroy old item
            yield return new WaitForSeconds(5f);

            Destroy(Spawnitem);
        }

    }

}
