using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOncollisionScript : MonoBehaviour
{
    [SerializeField] internal EnemyScript enemyScript;

    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            enemyScript.isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            enemyScript.isGround = true;
        }
    }
}
