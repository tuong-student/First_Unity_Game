using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button Pause;
    public Button Play;
    public Button RestartBtn;
    public Button ExitBtn;


    private bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!isPause)
            {
                isPause = true;
                PauseGame();
            }
            else
            {
                isPause = false;
                ResumeGame();
            }

        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Play.gameObject.SetActive(true);
        RestartBtn.gameObject.SetActive(true);
        ExitBtn.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Play.gameObject.SetActive(false);
        RestartBtn.gameObject.SetActive(false);
        ExitBtn.gameObject.SetActive(false);
    }
}
