using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript;

    float animationTime;
    Animator anim;
    RuntimeAnimatorController ac;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ac = anim.runtimeAnimatorController;
    }

    private void Update()
    {
        if (playerScript.isGround)
        {
            anim.SetBool("isGround", true);
        }

        if (!playerScript.isRunning)
        {
            anim.SetBool("Run", false);
        }

        if (!playerScript.isDead)
        {
            anim.SetBool("Dead", false);
        }
        anim.SetFloat("yVelocity", playerScript.myBody.velocity.y);
    }

    internal void ResetAllBool()
    {
        foreach(AnimatorControllerParameter parameter in anim.parameters)
        {
            anim.SetBool(parameter.name, false);
        }
    }

    internal IEnumerator AttackComplete()
    {
        foreach (AnimationClip animationClip in ac.animationClips)
        {
            // Get animation time of the Attack Clip
            if (animationClip.name == "Attack")
            {
                animationTime = animationClip.length;
            }
        }
        yield return new WaitForSeconds(animationTime);
        playerScript.isAttacking = false;
    }
    internal IEnumerator HitComplete()
    {
        foreach (AnimationClip animationClip in ac.animationClips)
        {
            // Get animation time of the Hit Clip
            if (animationClip.name == "Hit")
            {
                animationTime = animationClip.length;
            }
        }
        yield return new WaitForSeconds(animationTime);
        playerScript.isHitting = false;
    }
    internal void Run()
    {
        anim.SetBool("Run", true);
    }
    internal void Attack()
    {
        ResetAllBool();
        anim.SetTrigger("Attack");
    }
    internal void Jump()
    {
        ResetAllBool();
        anim.SetBool("Jump", true);
    }
    internal void Fall()
    {
        ResetAllBool();
        anim.SetBool("Fall", true);
    }
    internal void Hit()
    {
        ResetAllBool();
        anim.SetTrigger("Hit");
    }
    internal void Death()
    {
        ResetAllBool();
        anim.SetBool("Dead", true);
    }


}
