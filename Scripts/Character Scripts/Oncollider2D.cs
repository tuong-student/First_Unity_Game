using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oncollider2D : Oncollider2DFather
{
    [SerializeField]
    Character CharacterScript;

    protected string GROUND_TAG = "Ground";
    protected string ENEMY_TAG = "Enemy";
    protected string TRAP_TAG = "Trap";
    protected string ITEM_TAG = "Item";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Compare 2 collision base on their tag
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            CharacterScript.isGround = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            CharacterScript.isHited = true;
            Debug.Log("Enemy Touched");

            //get Enemy Script of Enemy gameObject
            CharacterScript._enemy = collision.gameObject.GetComponent<Enemy>();
        }

        if (collision.gameObject.CompareTag(TRAP_TAG))
        {
            CharacterScript.isTraped = true;
        }

        if (collision.gameObject.CompareTag(ITEM_TAG))
        {
            collision.gameObject.GetComponent<ItemScript>().isActive = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            CharacterScript.isGround = true;
        }
    }
}
