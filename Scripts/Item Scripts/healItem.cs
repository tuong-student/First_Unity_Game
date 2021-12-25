using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healItem : ItemScript
{
    Character playerScript;

    public int healAmount = 30;

    private void OnDestroy()
    {
        if (isActive)
        {
            playerScript = Player.GetComponent<Character>();
            playerScript.current_health += healAmount;
        }
    }

}
