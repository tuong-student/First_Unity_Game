using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOncollisionScript : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript;

    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private string ITEM_TAG = "Item";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            playerScript.isGround = true;
            playerScript.isFalling = false;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            playerScript.isHitted = true;
            playerScript.enemy = collision.gameObject.GetComponent<EnemyScript>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            playerScript.isFalling = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            playerScript.isGround = true;
        }
        if (collision.gameObject.CompareTag(ITEM_TAG))
        {
            collision.gameObject.GetComponent<ItemScript>().isActive = true;
            Destroy(collision.gameObject);
        }
    }
}
