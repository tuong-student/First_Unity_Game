using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public Transform character;

    private Vector3 tempPos;

    public Vector3 offSet;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    //Follow Character
    private void LateUpdate()
    {

        tempPos = transform.position;
        tempPos.x = character.position.x + offSet.x;
        tempPos.y = character.position.y + offSet.y;

        transform.position = tempPos;
    }
}
