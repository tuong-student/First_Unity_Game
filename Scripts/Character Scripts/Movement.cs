using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Character CharacterScript;

    public virtual void RunAndJump(float movementX)
    {
        
        Jump();
        Run();

        if (!CharacterScript.isAttacking)
        {

            // Change position horizontally
            transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * CharacterScript.move_Force;

        }

        
    }

    public virtual void Run()
    {
        if (CharacterScript.isGround && !CharacterScript.isAttacking)
        {
            if (!CharacterScript.isHitting)
            {

                //Moving animation 
                if (CharacterScript.movementX > 0)
                {
                    //moving right
                    CharacterScript.sr.flipX = false;
                    CharacterScript.anim.Run();
                }
                else if (CharacterScript.movementX < 0)
                {
                    //moving left
                    CharacterScript.sr.flipX = true;
                    CharacterScript.anim.Run();
                }
                else
                {
                    //stand
                    CharacterScript.anim.Idle();
                }

            }

        }
    }

    public virtual void Jump()
    {

        if (CharacterScript.isJumpPress && CharacterScript.isGround)
        {
            CharacterScript.isGround = false;
            CharacterScript.isJumpPress = false;

            Debug.Log("this is Jump()");
            //can be replace by myBody.velocity = new Vector2(x, y);
            CharacterScript.myBody.AddForce(new Vector2(0f, CharacterScript.jump_Force), ForceMode2D.Impulse);
            CharacterScript.anim.Jump(); //Play animation
        }
        if (!CharacterScript.isGround)
        {
            if (CharacterScript.movementX > 0)
            {
                //moving right
                CharacterScript.sr.flipX = false;
            }
            else if (CharacterScript.movementX < 0)
            {
                //moving left
                CharacterScript.sr.flipX = true;
            }
        }

    }

    public void Attack()
    {
        //Set isAttacking = true .
        //Play animation .
        //Play attack sound .
        //Check if player turn left or right .
        //Detect all enemy in range .
        //Deal damage for all enemy in range
        //Set isAttacking = false after animation done .
        if (!CharacterScript.isAttacking && CharacterScript.isAttackPress)
        {
            CharacterScript.isAttacking = true;
            CharacterScript.isAttackPress = false;
            //Play anim
            try 
            {
                if (CharacterScript.isGround)
                {
                    CharacterScript.anim.Attack1();
                }
                else
                {
                    CharacterScript.anim.Attack2();
                }
            }
            catch
            {
                //This character don't have Attack1 or 2
                CharacterScript.anim.Attack();
            }
            //Play sound
            CharacterScript.attackSound.Play();

            //Check turn
            Transform attackPoint;
            if (CharacterScript.sr.flipX)
            {
                //Turn left
                attackPoint = CharacterScript.LeftattackPoint;
            }
            else
            {
                //Turn right
                attackPoint = CharacterScript.RightattackPoint;
            }

            //Detect all enemy
            Collider2D[] hitEnemies;

            hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, CharacterScript.attackRange, CharacterScript.enemyLayers);

            //Deal damage
            Character enemyScript;
            foreach(Collider2D enemy in hitEnemies)
            {
                enemyScript = enemy.GetComponent<Character>(); //Get this enemy Script
                if (!enemyScript.isDead)
                {
                    enemyScript.isHited = true;
                    enemyScript.movementScript.Hit(CharacterScript.damage);
                }
            }
            //Set isAttacking = false
            StartCoroutine(CharacterScript.anim.AttackComplete());
        }
    }

    public virtual void Hit(int damage)
    {
        if (CharacterScript.isHited && !CharacterScript.isHitting)
        {
            CharacterScript.isHited = false;
            CharacterScript.isHitting = true;
            Debug.Log("Hited");

            //Play animation Hit
            CharacterScript.anim.Hit();

            StartCoroutine(CharacterScript.anim.HitComplete());

            //Play sound
            CharacterScript.hitSound.Play();

            //Push back
            pushBack();

            //Minus health
            CharacterScript.current_health -= damage;
        }
    }

    void pushBack()
    {
        if (!CharacterScript.sr.flipX)
        {
            //Character is looking right
            CharacterScript.myBody.AddForce(new Vector2(-5f, 2f), ForceMode2D.Impulse);
        }
        else
        {
            //Character is looking left
            CharacterScript.myBody.AddForce(new Vector2(5f, 2f), ForceMode2D.Impulse);
        }
    }

    public virtual void Dead()
    {
        if (CharacterScript.isDead)
        {

            CharacterScript.isHited = false;
            //Play animation death
            CharacterScript.anim.Death();

            //Play sound
            CharacterScript.deadSound.Play();

            //Go throught
            GetComponent<Collider2D>().isTrigger = true;

            if (CharacterScript.isGround)
            {
                //Disable Falling
                CharacterScript.myBody.constraints = RigidbodyConstraints2D.FreezeAll;
            }

        }
    }


    public virtual void StandUp()
    {
        if(CharacterScript._isRespawnPress && !CharacterScript._isStandingUp)
        {

            //Play animation StandUp
            CharacterScript._isStandingUp = true;
            CharacterScript._isRespawnPress = false;
           
            CharacterScript.anim.StandUp();
            StartCoroutine(CharacterScript.anim.StandUpComplete());
            
            Debug.Log("Reset player");
            CharacterScript.anim.Idle();

            //Not go throught
            GetComponent<Collider2D>().isTrigger = false;

            //Enable Movement
            CharacterScript.myBody.constraints = RigidbodyConstraints2D.None;
            CharacterScript.myBody.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }

    public void Respawn()
    {
        CharacterScript.isDead = false;
        CharacterScript._isRespawnPress = true;
        transform.position = CharacterScript.RespawnPoint.position;
        CharacterScript.current_health = CharacterScript.max_health;
        CharacterScript.healthBar.SetHealth(CharacterScript.max_health);

        StandUp();
    }
}
