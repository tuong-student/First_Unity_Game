using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript;

    internal void MoveHorizontal()
    {
        if(playerScript.movementX > 0)
        {
            // turn right
            playerScript.sr.flipX = false;
        }
        if(playerScript.movementX < 0)
        {
            // turn left
            playerScript.sr.flipX = true;
        }
        if (!playerScript.isAttacking && !playerScript.isHitting)
        {
            transform.position += new Vector3(playerScript.movementX, 0f, 0f) * Time.deltaTime * playerScript.move_force;
        }
    }

    internal void Run()
    {
        if(playerScript.isRunning)
        {
            // Play animation
            playerScript.animationScript.Run();
        }
    }
    internal void Jump()
    {
        if(playerScript.isJumpPress)
        {
            playerScript.isGround = false;
            playerScript.isJumpPress = false;

            // Play sound
            playerScript.jumpSound.Play();

            playerScript.animationScript.Jump();
            //Move Up
            playerScript.myBody.AddForce(new Vector2(0f, playerScript.jump_force), ForceMode2D.Impulse);
        }
        
    }
    internal void RunAndJump()
    {
        if (!playerScript.isDead)
        {
            Run();
            Jump();

            MoveHorizontal();
        }
    }
    internal void Fall()
    {

    }
    internal void Attack()
    {
        if (playerScript.isAttackPress && !playerScript.isAttacking)
        {
            playerScript.isAttackPress = false;
            playerScript.isAttacking = true;
            playerScript.animationScript.Attack();

            // Play Sound
            playerScript.attackSound.Play();

            //Check turn
            Transform attackPoint;
            if (playerScript.sr.flipX)
            {
                //Turn left
                attackPoint = playerScript.leftAttackPoint;
            }
            else
            {
                //Turn right
                attackPoint = playerScript.rightAttackPoint;
            }

            // Get all enemy in Range
            Collider2D[] hitEnemies;

            hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, playerScript.attack_range, playerScript.enemyLayer);

            // Deal damage 
            EnemyScript enemyScript;
            foreach (Collider2D enemy in hitEnemies)
            {
                enemyScript = enemy.GetComponent<EnemyScript>(); //Get this enemy Script
                if (!enemyScript.isDead)
                {
                    enemyScript.isHitted = true;
                    enemyScript.movementScript.Hit(playerScript.damage);
                }
            }

            StartCoroutine(playerScript.animationScript.AttackComplete());
        }
    }
    internal void Hit()
    {
        if (playerScript.isHitted && !playerScript.isHitting)
        {
            playerScript.isHitted = false;
            playerScript.isHitting = true;

            playerScript.animationScript.Hit();

            playerScript.hitSound.Play();

            // minus health
            playerScript.current_health -= playerScript.enemy.damage;

            StartCoroutine(playerScript.animationScript.HitComplete());
        }
    }
    void pushBack()
    {
        if (!playerScript.sr.flipX)
        {
            //Character is looking right
            playerScript.myBody.AddForce(new Vector2(-5f, 2f), ForceMode2D.Impulse);
        }
        else
        {
            //Character is looking left
            playerScript.myBody.AddForce(new Vector2(5f, 2f), ForceMode2D.Impulse);
        }
    }
    internal void Dead()
    {
        if (playerScript.isDead)
        {
            playerScript.animationScript.Death();

            // Go throught
            GetComponent<Collider2D>().isTrigger = true;

            if (playerScript.isGround)
            {
                // Disable Falling
                playerScript.myBody.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }
    internal void Respaw()
    {
        if (playerScript.isRespawnPress && playerScript.isDead)
        {
            // Reset 
            GetComponent<Collider2D>().isTrigger = false;
            playerScript.myBody.constraints = RigidbodyConstraints2D.None;
            playerScript.myBody.constraints = RigidbodyConstraints2D.FreezeRotation;

            // Set alive
            playerScript.isDead = false;
            playerScript.isRespawnPress = false;
            transform.position = playerScript.respawnPoint.position;
            playerScript.current_health = playerScript.max_health;
        }
    }

}
