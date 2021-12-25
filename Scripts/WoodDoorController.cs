using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WoodDoorController : MonoBehaviour
{
    public LevelController LevelControl;

    public Slider slider;

    public int WoodDoorPoint = 10;

    private bool isPlayer;

    [SerializeField]
    private Character Player;

    [SerializeField]
    private Text winText;

    //Audio
    public AudioSource increaseSound;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isPlayer = false;
        slider.maxValue = WoodDoorPoint;
        StartCoroutine(WoodDoorControl());
        winText.enabled = false;
    }

    private void Update()
    {
        if(slider.value == slider.maxValue)
        {
            GetComponent<Animator>().SetBool("isOpen", true);
            winText.enabled = true;
            LevelControl.PauseGame();
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

    IEnumerator WoodDoorControl()
    {
        while (true)
        {

            if (isPlayer && Player.current_health > 0)
            {
                yield return new WaitForSeconds(2f);
                if (!isPlayer) continue;
                WoodDoorBarIncrease();
            }
            else
            {
                yield return new WaitForSeconds(3f);
                if (isPlayer) continue;
                WoodDoorBarDecresase();
            }

        }
    }

    void WoodDoorBarIncrease()
    {
        slider.value += 1;
        increaseSound.Play();
    }

    void WoodDoorBarDecresase()
    {
        slider.value -= 1;
    }
}