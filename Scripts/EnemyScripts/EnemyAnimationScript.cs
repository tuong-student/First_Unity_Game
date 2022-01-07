using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationScript : MonoBehaviour
{
    [SerializeField] internal EnemyScript enemyScript;
    internal Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal IEnumerator HitComplete()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        enemyScript.isHitting = false;
    }
    internal void Run()
    {
        anim.SetInteger("AnimState", 2);
    }
    internal void Hit()
    {
        anim.SetTrigger("Hurt");
    }
    internal void Dead()
    {
        anim.SetTrigger("Death");
    }

}
