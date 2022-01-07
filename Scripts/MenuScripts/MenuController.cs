using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController ins;

    public GameObject PauseMenu;
    public GameObject IngameMenu;

    public Button SoundOnBtn;
    public Button SoundOffBtn;
    public Button PauseGameBtn;
    public Button ResumeGameBtn;

    private AudioSource music;

    bool isPause;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            PauseGameBtn.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.gameObject.SetActive(false);
        music = GetComponent<AudioSource>();
        SoundOn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                Pause();
                isPause = true;
            }
            else
            {
                Resume();
                isPause = false;
            }
        }


    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded += OnLevelFinishLoading;
    }

    void OnLevelFinishLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == SceneManager.GetActiveScene().name)
        {
            Resume();
        }

        if(scene.name == "MainMenu" || scene.name == "ChooseCharacter")
        {
            PauseGameBtn.gameObject.SetActive(false);
            ResumeGameBtn.gameObject.SetActive(false);
        }
        else
        {
            PauseGameBtn.gameObject.SetActive(true);
            ResumeGameBtn.gameObject.SetActive(true);
            Resume();
        }
    }


    public void SelectPlayer()
    {
        SceneManager.LoadScene("ChooseCharacter");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenu.gameObject.SetActive(true);
        ResumeGameBtn.gameObject.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.gameObject.SetActive(false);
        ResumeGameBtn.gameObject.SetActive(false);
    }

    public void SoundOn()
    {
        if (SoundOffBtn == null) return;
        music.Play();
        SoundOffBtn.gameObject.SetActive(false);
        SoundOnBtn.gameObject.SetActive(true);
    }

    public void SoundOff()
    {
        music.Stop();
        SoundOffBtn.gameObject.SetActive(true);
        SoundOnBtn.gameObject.SetActive(false);
    }

}
