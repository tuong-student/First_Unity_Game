using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float speed;

    private void Awake()
    {
        Awaken();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.health <= 0)
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }
    }

    // FixedUpdate is called after a short delay
    private void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        if (isDead)
        {
            movementScript.Dead();

        }
        else
        {
            movementScript.StandUp();
            if (!_isStandingUp)
            {

                anim.Run();
                movementScript.Hit();

            }
        }
    }
}
