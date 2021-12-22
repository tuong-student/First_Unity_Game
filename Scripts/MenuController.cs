using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Allow to change scene

public class MenuController : MonoBehaviour
{
    public Button volumeOnBtn;
    public Button volumeOffBtn;
    private AudioSource Audio;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        VolumeOn();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    
    public void VolumeOn()
    {
        Audio.Play();
        volumeOffBtn.gameObject.SetActive(true);
        volumeOnBtn.gameObject.SetActive(false);
    }

    public void VolumeOff()
    {
        Audio.Pause();
        volumeOffBtn.gameObject.SetActive(false);
        volumeOnBtn.gameObject.SetActive(true);
    }
    
}
