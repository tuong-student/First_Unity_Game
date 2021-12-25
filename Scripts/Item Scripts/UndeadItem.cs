using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadItem : ItemScript
{
    Warrior playerScript;

    public static int undeadTime = 10;

    private void OnDestroy()
    {
        if (isActive)
        {
            Color alpha = Player.GetComponent<SpriteRenderer>().color;
            alpha.a = 0.5f;
            Player.GetComponent<SpriteRenderer>().color = alpha;
            Player.layer = LayerMask.NameToLayer("UnTouch");
            playerScript = Player.GetComponent<Warrior>();
            playerScript.isUndead = true;
            playerScript.timer.gameObject.SetActive(true);
            playerScript.timer.maxValue = undeadTime;
            playerScript.timer.value = undeadTime;
        }
    }
}
