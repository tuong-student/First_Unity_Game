using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // Scripts
    [SerializeField] internal PlayerAnimationScript animationScript;
    [SerializeField] internal PlayerOncollisionScript oncollisionScript;
    [SerializeField] internal PlayerMovementScript movementScript;

    // Component
    [SerializeField] internal SpriteRenderer sr;
    [SerializeField] internal Rigidbody2D myBody;
    [SerializeField] internal Transform leftAttackPoint, rightAttackPoint;

    // Audio
    [SerializeField] internal AudioSource attackSound;
    [SerializeField] internal AudioSource jumpSound;
    [SerializeField] internal AudioSource hitSound;

    // Basic Variable
    internal float max_health = 100;
    [SerializeField]
    internal float current_health;
    internal float move_force = 5;
    internal float jump_force = 6;
    internal float damage = 50;
    internal float attack_rate = 2;
    internal float next_attack_time = 0;
    internal float attack_range = 0.67f;
    [SerializeField]
    internal LayerMask enemyLayer;
    internal EnemyScript enemy;
    internal Transform respawnPoint;

    internal float movementX;
    internal float movementY;

    // Logic Variable
    internal bool isGround;
    internal bool isFalling;
    internal bool isDead;
    internal bool isHitted;
    internal bool isAttackPress;
    internal bool isJumpPress;
    internal bool isRespawnPress;
    internal bool isRunning;
    internal bool isAttacking;
    internal bool isHitting;
    internal bool isUndead;
    internal bool isCounting;

    // Item zone
    [SerializeField]
    internal BarFollow timer;
    public Slider timerSlider;

    private void Awake()
    {
        current_health = max_health;
        respawnPoint = GameObject.FindWithTag("Respawn").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = respawnPoint.position;
        timerSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        if (isUndead && !isCounting)
        {
            isCounting = true;
            StartCoroutine(CountDown());
        }
        if(timerSlider.value == 0 && isUndead)
        {
            isUndead = false;
            isCounting = false;
            ResetNormal();
        }
    }

    private void FixedUpdate()
    {
        movementScript.RunAndJump();
        movementScript.Attack();
        movementScript.Hit();
        movementScript.Dead();
        movementScript.Respaw();
    }

    private void OnDrawGizmosSelected()
    {
        if (rightAttackPoint == null || leftAttackPoint == null) return;
        if (sr.flipX)
        {
            Gizmos.DrawWireSphere(leftAttackPoint.position, attack_range);
        }
        else
        {
            Gizmos.DrawWireSphere(rightAttackPoint.position, attack_range);
        }
    }

    private void ResetNormal()
    {
        Color alpha = sr.color;
        alpha.a = 1f;
        sr.color = alpha;

        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public IEnumerator CountDown()
    {
        while (isUndead)
        {
            yield return new WaitForSeconds(1f);
            timerSlider.value -= 1;
        }
    }

    void ReadInput()
    {
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                isJumpPress = true;
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                isAttackPress = true;
            }
            movementX = Input.GetAxisRaw("Horizontal");
            if (isGround)
            {
                if(movementX != 0)
                {
                    isRunning = true;
                }
                else
                {
                    isRunning = false;
                }
            }
            if (Time.time >= next_attack_time)
            {
                //Limit how many attack per second
                if (Input.GetKeyDown(KeyCode.J))
                {
                    isAttackPress = true;
                    next_attack_time = Time.time + 1 / attack_rate;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                isRespawnPress = true;
            }
        }
        if (current_health <= 0)
            isDead = true;
        else isDead = false;
    }
}
