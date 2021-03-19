using UnityEngine;

public class closegame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Application.Quit();
        }
    }
}