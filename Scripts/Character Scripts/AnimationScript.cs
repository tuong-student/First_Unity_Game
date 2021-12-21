using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField]
    Character CharacterScript;

    Animator anim;
    internal string currentState;

    internal float animationTime;

    //character animation
    internal string IDLE_ANIMATION = "Idle";
    internal string RUN_ANIMATION = "Run";
    internal string JUMP_ANIMATION = "Jump";
    internal string ATTACK_ANIMATION = "Attack";
    internal string ATTACK1_ANIMATION = "Attack1";
    internal string ATTACK2_ANIMATION = "Attack2";
    internal string HIT_ANIMATION = "Hit";
    internal string DEATH_ANIMATION = "Death";
    internal string STANDUP_ANIMATION = "StandUp";

    //item animation
    private string OPEN_ANIMATION = "Open";
    private string FLOW_ANIMATION = "Flow";

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void ChangeAnimationState(string newState)
    {
        //stop the same animation form interrupting itseft
        if (currentState == newState) return;

        //play the animation
        anim.Play(newState);

        //ressign the current state
        currentState = newState;

        //Get new animation time
        animationTime = anim.GetCurrentAnimatorStateInfo(0).length;
    }

    public IEnumerator AttackComplete()
    {
        yield return new WaitForSeconds(animationTime);
        CharacterScript.isAttacking = false;
    }

    public IEnumerator HitComplete()
    {
        yield return new WaitForSeconds(animationTime);
        CharacterScript.isHitting = false;
    }

    public IEnumerator StandUpComplete()
    {
        yield return new WaitForSeconds(animationTime);
        CharacterScript._isStandingUp = false;
    }

    public void Idle()
    {
        ChangeAnimationState(IDLE_ANIMATION);
    }

    public void Run()
    {
        ChangeAnimationState(RUN_ANIMATION);
    }

    public void Jump()
    {
        ChangeAnimationState(JUMP_ANIMATION);

    }

    public void Attack()
    {
        ChangeAnimationState(ATTACK_ANIMATION);

    }

    public void Attack1()
    {
        ChangeAnimationState(ATTACK1_ANIMATION);

    }

    public void Attack2()
    {
        ChangeAnimationState(ATTACK2_ANIMATION);

    }

    public void Hit()
    {
        ChangeAnimationState(HIT_ANIMATION);

    }

    public void Death()
    {
        ChangeAnimationState(DEATH_ANIMATION);

    }

    public void StandUp()
    {
        ChangeAnimationState(STANDUP_ANIMATION);

    }

    public void Open()
    {
        ChangeAnimationState(OPEN_ANIMATION);
    }

    public void Flow()
    {
        ChangeAnimationState(FLOW_ANIMATION);
    }
}
