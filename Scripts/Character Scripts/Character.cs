using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //Get other scripts like animation...
    [SerializeField]
    internal AnimationScript anim;
    [SerializeField]
    internal Oncollider2DFather oncollider2DScript;
    [SerializeField]
    internal Movement movementScript;

    [SerializeField]
    internal SpriteRenderer sr;
    [SerializeField]
    internal Transform RespawnPoint;

    public HealthBar healthBar;

    public Transform RightattackPoint;
    public Transform LeftattackPoint;

    public float attackRange;
    public LayerMask enemyLayers;

    //Audio
    public AudioSource attackSound;
    public AudioSource hitSound;
    public AudioSource deadSound;

    //Basic variales
    public int _max_health;
    public int _current_health;
    public int _damage = 10;
    public int _mana = 100;
    public int _move_Force = 5;
    public int _max_Speed = 50;
    public int _jump_Force = 10;
    public string _character_Name;
    public float attackRate = 2;
    float nexAttackTime = 0;

    //Locgic variables
    internal bool _isDead = false;
    internal bool _isAttacking = false;
    internal bool _isAttackPress = false;
    internal bool _isJumpPress = false;
    internal bool _isRespawnPress = false;
    internal bool _isHited = false;
    internal bool _isHitting = false;
    internal bool _isTraped = false;
    internal bool _isStandingUp = false;
    internal bool _isGround;
    internal Character _enemy;


    internal float movementX;
    internal float movementY;

    internal Rigidbody2D myBody;
    

    public void Awaken()
    {
        myBody = GetComponent<Rigidbody2D>();
        current_health = max_health;
    }

    private void OnDrawGizmosSelected()
    {
        if (RightattackPoint == null || LeftattackPoint == null) return;
        if (sr.flipX)
        {
            Gizmos.DrawWireSphere(LeftattackPoint.position, attackRange);
        }
        else
        {
            Gizmos.DrawWireSphere(RightattackPoint.position, attackRange);
        }
    }

    public void ReadInput()
    {
        if (current_health <= 0) isDead = true;
        if (current_health > max_health) current_health = max_health;
        if (!isDead)
        {

            if (Input.GetButtonDown("Jump") && isGround)
            {
                isJumpPress = true;
            }

            if(Time.time >= nexAttackTime)
            {
                //Limit how many attack per second
                if (Input.GetKeyDown(KeyCode.J) && !isAttacking)
                {
                    isAttackPress = true;
                    nexAttackTime = Time.time + 1 / attackRate;
                }
            }
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                movementScript.Respawn();
            }

        }

    }

    public virtual void Move(float movementX)
    {
        if (!isDead)
        {

            movementScript.Attack();

            movementScript.RunAndJump(movementX);

            if(isHited) movementScript.Hit(_enemy.damage);

        }
        else
        {

            movementScript.Dead();

        }
    }


    //Contructor
    public bool isDead
    {
        get { return this._isDead; }
        set { this._isDead = value; }
    }
    public bool isAttacking
    {
        get { return this._isAttacking; }
        set { this._isAttacking = value; }
    }
    public bool isAttackPress
    {
        get { return this._isAttackPress; }
        set { this._isAttackPress = value; }
    }
    public bool isJumpPress
    {
        get { return this._isJumpPress; }
        set { this._isJumpPress = value; }
    }
    public bool isHited
    {
        get { return this._isHited; }
        set { this._isHited = value; }
    }
    public bool isHitting
    {
        get { return this._isHitting; }
        set { this._isHitting = value; }
    }
    public bool isTraped
    {
        get { return this._isTraped; }
        set { this._isTraped = value; }
    }
    public bool isGround
    {
        get { return this._isGround; }
        set { this._isGround = value; }
    }

    //Basic variable
    public int max_health
    {
        get { return this._max_health; }
        set { this._max_health = value; }
    }
    public int current_health
    {
        get{ return this._current_health; }
        set{ this._current_health = value; }
    }
    public int damage
    {
        get { return this._damage; }
        set { this._damage = value; }
    }
    public int mana
    {
        get { return this._mana; }
        set { this._mana = value; }
    }
    public int move_Force
    {
        get { return this._move_Force; }
        set { this._move_Force = value; }
    }
    public int max_Speed
    {
        get { return this._max_Speed; }
        set { this._max_Speed = value; }
    }
    public int jump_Force
    {
        get { return this._jump_Force; }
        set { this._jump_Force = value; }
    }
    public string character_name
    {
        get { return this._character_Name; }
        set { this._character_Name = value; }
    }

    public void Info()
    {
        Debug.Log("health: " + current_health);
        Debug.Log("mana: " + mana);
        Debug.Log("jump_Force: " + jump_Force);
    }

}
