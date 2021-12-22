using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OpenGate", 3f);
        
    }

    void OpenGate()
    {
        gameObject.SetActive(false);
    }
}
