using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [SerializeField] internal EnemyScript enemyScript;


    internal void MoveHorizontal()
    {
        if (enemyScript.movementX > 0)
        {
            // turn right
            enemyScript.sr.flipX = false;
        }
        if (enemyScript.movementX < 0)
        {
            // turn left
            enemyScript.sr.flipX = true;
        }
        if (!enemyScript.isHitting)
        {
            transform.position += new Vector3(enemyScript.movementX, 0f, 0f) * Time.deltaTime * enemyScript.move_force;
        }
    }
    internal void Run()
    {
        if (!enemyScript.isDead)
        {
            enemyScript.animationScript.Run();
            MoveHorizontal();
        }
    }
    internal void Hit(float damage)
    {
        if (enemyScript.isHitted)
        {
            enemyScript.isHitted = false;
            enemyScript.isHitting = true;

            enemyScript.animationScript.Hit();
            enemyScript.current_health -= damage;

            StartCoroutine(enemyScript.animationScript.HitComplete());
        }
    }
    internal void Dead()
    {
        if (enemyScript.isDead)
        {
            enemyScript.animationScript.Dead();

            //Go throught
            GetComponent<Collider2D>().isTrigger = true;

            if (enemyScript.isGround)
            {
                //Disable Falling
                enemyScript.myBody.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }

}
