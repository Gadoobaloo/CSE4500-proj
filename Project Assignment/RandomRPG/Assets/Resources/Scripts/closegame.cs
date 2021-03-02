using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closegame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown("space")) { 
                Application.Quit();
        }
    }

}
