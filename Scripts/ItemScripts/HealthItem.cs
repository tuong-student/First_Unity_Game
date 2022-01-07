using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : ItemScript
{
    PlayerScript playerScript;

    public float health_amount = 30;

    private void OnDestroy()
    {
        if (isActive)
        {
            playerScript = Player.GetComponent<PlayerScript>();
            playerScript.current_health += health_amount;
            if(playerScript.current_health > playerScript.max_health)
            {
                playerScript.current_health = playerScript.max_health;
            }
        }
    }
}
