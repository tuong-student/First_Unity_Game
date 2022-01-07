using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodDoorBar : MonoBehaviour
{
    bool isPlayer = false;
    [SerializeField] Slider slider;
    [SerializeField] int WoodDoorPoint = 50;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource increaseSound;
    [SerializeField] GameObject WinGame;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Count());
        slider.maxValue = WoodDoorPoint;
        slider.value = 0;
        WinGame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value == slider.maxValue)
        {
            anim.SetBool("Open", true);
            Time.timeScale = 0;
            WinGame.gameObject.SetActive(true);
            MenuController.ins.SoundOff();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }

    IEnumerator Count()
    {
        while (true)
        {
            if (isPlayer)
            {
                yield return new WaitForSeconds(1f);
                if (!isPlayer) continue;
                slider.value += 1;
                increaseSound.Play();
            }
            else
            {
                yield return new WaitForSeconds(2f);
                if (isPlayer) continue;
                slider.value -= 1;
            }
        }
    }
}
