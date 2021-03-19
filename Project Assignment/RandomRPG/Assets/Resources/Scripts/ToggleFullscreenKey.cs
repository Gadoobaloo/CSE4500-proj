using UnityEngine;

public class ToggleFullscreenKey : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }
}