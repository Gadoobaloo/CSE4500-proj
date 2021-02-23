using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public string textMessage = "clicked!";

    private void OnMouseDown()
    {
        Debug.Log(textMessage);
    }



}
