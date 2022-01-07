using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    [SerializeField] Transform[] respawnPoints;

    GameObject spawnitem;

    int itemIndex;
    int pointIndex;
    int oldRandomPosition;

    private void Start()
    {
        StartCoroutine(SpawnItem());
        StartCoroutine(SpawnItem());
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 8f));

            itemIndex = Random.Range(0, items.Length);
            pointIndex = Random.Range(0, respawnPoints.Length);

            while (pointIndex == oldRandomPosition)
            {
                pointIndex = Random.Range(0, respawnPoints.Length);
            }
            oldRandomPosition = pointIndex;

            spawnitem = Instantiate(items[itemIndex]);

            spawnitem.transform.position = respawnPoints[pointIndex].position;

            yield return new WaitForSeconds(10f);
            Destroy(spawnitem);
        }
    }
}
