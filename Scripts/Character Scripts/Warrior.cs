using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warrior : Character
{
    [SerializeField]
    private int Warrior_jump_Force = 8;

    public bool isUndead = false;

    public Slider timer;
    private bool isCounting = false;
    private void Awake()
    {
        max_health = 100;
        Awaken();
        jump_Force = Warrior_jump_Force;
        character_name = "Warrior";
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(max_health);
        healthBar.SetHealth(max_health);
        timer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        jump_Force = Warrior_jump_Force;
        movementX = Input.GetAxisRaw("Horizontal");
        healthBar.SetHealth(current_health);

        if (!isCounting && isUndead)
        {
            StartCoroutine(CountDown());
        }

        if(timer.value == 0 && isUndead)
        {
            ResetNormal();
            isUndead = false;
            isCounting = false;
        }
    }

    // Called base on use physical speed 
    private void FixedUpdate()
    {
        Move(movementX);
    }

    void ResetNormal()
    {
        Color alpha = sr.color;
        alpha.a = 1;
        sr.color = alpha;
        gameObject.layer = LayerMask.NameToLayer("Player");
        timer.gameObject.SetActive(false);
    }

    IEnumerator CountDown()
    {
        isCounting = true;
        while (isUndead)
        {
            yield return new WaitForSeconds(1f);
            timer.value -= 1;
        }
    }
}
