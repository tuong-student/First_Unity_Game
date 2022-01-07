using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private GameObject player;
    private PlayerScript playerScript;

    [SerializeField] Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
        slider.maxValue = playerScript.max_health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerScript.current_health;
    }
}
