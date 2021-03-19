using UnityEngine;

public class ToggleFullscreen : MonoBehaviour
{
    public void ToggeleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}