using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{
    [SerializeField]
    private int Warrior_jump_Force = 8;

    private void Awake()
    {
        Awaken();
        jump_Force = Warrior_jump_Force;
        character_name = "Warrior";
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(max_health);
        healthBar.SetHealth(max_health);
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        jump_Force = Warrior_jump_Force;
        movementX = Input.GetAxisRaw("Horizontal");
    }

    // Called base on use physical speed 
    private void FixedUpdate()
    {
        Move(movementX);
    }


}
