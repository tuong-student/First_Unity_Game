using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Scripts
    [SerializeField] internal EnemyAnimationScript animationScript;
    [SerializeField] internal EnemyOncollisionScript oncollisionScript;
    [SerializeField] internal EnemyMovementScript movementScript;

    // Component
    [SerializeField] internal SpriteRenderer sr;
    [SerializeField] internal Rigidbody2D myBody;

    // Basic Variable
    internal float max_health = 100;
    [SerializeField]
    internal float current_health;
    internal float move_force = 5;
    internal float jump_force = 8;
    internal float damage = 10;
    internal float attack_rate = 2;
    internal float next_attack_time = 0;
    internal float attack_range;
    internal LayerMask enemyLayer;

    internal float movementX;
    internal float movementY;


    // Logic Variable
    internal bool isGround;
    internal bool isDead;
    internal bool isHitted;
    internal bool isRunning;
    internal bool isHitting;


    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;   
    }

    // Update is called once per frame
    void Update()
    {
        if (current_health <= 0)
            isDead = true;
        else isDead = false;
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            movementScript.Run();
        }
        else
        {
            movementScript.Dead();
        }

    }
}
