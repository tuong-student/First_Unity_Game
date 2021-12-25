using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Slider slider;

    public Transform character;

    private Vector3 tempPos;

    public Vector3 offSet;

    public void SetMaxTime(int health)
    {
        slider.maxValue = health;
    }

    public void SetTime(int health)
    {
        slider.value = health;
    }

    private void LateUpdate()
    {
        //follow character
        tempPos = slider.gameObject.transform.position;
        tempPos.x = character.position.x + offSet.x;
        tempPos.y = character.position.y + offSet.y;

        slider.gameObject.transform.position = tempPos;
    }
}
