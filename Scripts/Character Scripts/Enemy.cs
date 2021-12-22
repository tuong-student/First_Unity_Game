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

    // Update is called once per frame
    void Update()
    {
        if(this.current_health <= 0)
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
        anim.Run();
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        
    }
}
