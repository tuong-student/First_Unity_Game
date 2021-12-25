using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Allow to change scene

public class MenuController : MonoBehaviour
{
    public Button volumeOnBtn;
    public Button volumeOffBtn;

    private void Start()
    {
        VolumeOn();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    
    public void VolumeOn()
    {
        if (volumeOffBtn == null) return;
        volumeOffBtn.gameObject.SetActive(false);
        volumeOnBtn.gameObject.SetActive(true);
    }

    public void VolumeOff()
    {
        volumeOffBtn.gameObject.SetActive(true);
        volumeOnBtn.gameObject.SetActive(false);
    }
    
}
