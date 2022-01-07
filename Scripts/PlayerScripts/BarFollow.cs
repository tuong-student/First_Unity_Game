using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFollow : MonoBehaviour
{
    public Slider slider;
    public Transform followPoint;
    public Vector3 offset;
    private Transform Player;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        //followPoint.position = Player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        slider.transform.position = followPoint.position + offset;
    }

}
