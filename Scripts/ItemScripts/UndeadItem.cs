using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadItem : ItemScript
{
    PlayerScript playerScript;

    internal int UndeadTime = 10;

    private void OnDestroy()
    {
        if (isActive)
        {

            Color alpha = Player.GetComponent<SpriteRenderer>().color;
            alpha.a = 0.5f;
            Player.GetComponent<SpriteRenderer>().color = alpha;
            playerScript = Player.GetComponent<PlayerScript>();
            Player.layer = LayerMask.NameToLayer("Untouch");

            playerScript.isUndead = true;
            playerScript.timerSlider.maxValue = UndeadTime;
            playerScript.timerSlider.value = UndeadTime;
        }
    }
}
