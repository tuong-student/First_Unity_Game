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

            yield return new WaitForSeconds(1f);
            if (isPlayer && Player.current_health > 0)
            {
                WoodDoorBarIncrease();
            }
            else
            {
                WoodDoorBarDecresase();
            }

        }
    }

    void WoodDoorBarIncrease()
    {
        slider.value += 1;
        Debug.Log("increase");

    }

    void WoodDoorBarDecresase()
    {
        slider.value -= 1;
        Debug.Log("Decrease");

    }
}