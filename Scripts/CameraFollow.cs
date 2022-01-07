using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private float maxX, minX;

    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // LateUpdate is called once per frame AFTER Update calculated
    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if(tempPos.x < maxX && tempPos.x > minX)
            transform.position = tempPos;


    }
}
