using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{
    [SerializeField]
    private int Warrior_jump_Force = 10;


    private void Awake()
    {
        Awaken();
        jump_Force = Warrior_jump_Force;
        character_name = "Warrior";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }
        jump_Force = Warrior_jump_Force;
        movementX = Input.GetAxisRaw("Horizontal");
        ReadInput();
    }

    private void FixedUpdate()
    {
        Move(movementX);
    }


}
