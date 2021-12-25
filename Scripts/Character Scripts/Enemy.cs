using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float speed;

    private void Awake()
    {
        max_health = 10;
        Awaken();
        character_name = "Badit";
    }

    // Update is called once per frame
    void Update()
    {
        if(this.current_health <= 0)
        {
            isDead = true;
        }
    }

    // FixedUpdate is called after a short delay
    private void FixedUpdate()
    {
        if (!isDead)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
            anim.Run();
        }
        else
        {
            movementScript.Dead();
        }
    }
}
