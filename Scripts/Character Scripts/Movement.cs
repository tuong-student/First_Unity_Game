using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Character CharacterScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void RunAndJump(float movementX)
    {

        Jump();
        Run(movementX);

        if (!CharacterScript.isAttacking)
        {

            // Change position horizontally
            transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * CharacterScript.move_Force;

        }

        
    }

    public virtual void Run(float movementX)
    {
        if (CharacterScript.isGround && !CharacterScript.isAttacking)
        {
            if (!CharacterScript.isHitting)
            {

                //Moving animation 
                if (movementX > 0)
                {
                    //moving right
                    CharacterScript.sr.flipX = false;
                    CharacterScript.anim.Run();
                }
                else if (movementX < 0)
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

    public virtual void Attach()
    {
        //Set isAttacking = true
        //Play animation
        //Deal damage for all enemy in range
        //Set isAttacking = false after animation done
        //Reset the movement speed
        if (!CharacterScript.isAttacking && CharacterScript.isAttackPress)
        {
            Debug.Log("movement Attack is running");
            CharacterScript.isAttackPress = false;
            CharacterScript.isAttacking = true;
            try
            {
                if (CharacterScript.isGround)
                {
                    //Attack1
                    CharacterScript.anim.Attack1();
                }
                else
                {
                    //Attack2
                    CharacterScript.anim.Attack2();
                }

            }
            catch
            {
                //This character isn't has Attack1 or Attack2
                CharacterScript.anim.Attack();
            }
            int tempMoveSpeed = CharacterScript.move_Force;
            StartCoroutine(CharacterScript.anim.AttackComplete()); //Set isAttaking = false
            CharacterScript.move_Force = tempMoveSpeed; //Reset the movement speed
        }
    }

    public virtual void Hit()
    {
        if (CharacterScript.isHited && !CharacterScript.isHitting)
        {
            CharacterScript.isHited = false;
            CharacterScript.isHitting = true;
            Debug.Log("Hited");

            //Play animation Hit
            CharacterScript.anim.Hit();

            StartCoroutine(CharacterScript.anim.HitComplete());

            //Push back
            pushBack();

            //Minus health
            CharacterScript.health -= CharacterScript._enemy.damage;
        }
    }

    void pushBack()
    {
        if (!CharacterScript.sr.flipX)
        {
            //Character is looking right
            CharacterScript.myBody.AddForce(new Vector2(-5f, 5f), ForceMode2D.Impulse);
        }
        else
        {
            //Character is looking left
            CharacterScript.myBody.AddForce(new Vector2(5f, 5f), ForceMode2D.Impulse);
        }
    }

    public virtual void Dead()
    {
        if (CharacterScript.isDead)
        {

            CharacterScript.isHited = false;
            //Play animation death
            CharacterScript.anim.Death();

            //Disable movement
            CharacterScript.myBody.constraints = RigidbodyConstraints2D.FreezeAll;

            //Go throught
            GetComponent<Collider2D>().enabled = false;

        }
    }


    public virtual void StandUp()
    {
        if(!CharacterScript.isDead && CharacterScript.anim.currentState == CharacterScript.anim.DEATH_ANIMATION)
        {

            //Play animation StandUp
            try
            {
                CharacterScript._isStandingUp = true;
                CharacterScript.anim.StandUp();
                StartCoroutine(CharacterScript.anim.StandUpComplete());
            }
            catch
            {
                CharacterScript.anim.Idle();
            }

            if (!CharacterScript._isStandingUp)
            {

                //Enable Movement
                CharacterScript.myBody.constraints = RigidbodyConstraints2D.None;

                //Not go throught
                GetComponent<Collider2D>().enabled = true;

            }

        }
    }

}
