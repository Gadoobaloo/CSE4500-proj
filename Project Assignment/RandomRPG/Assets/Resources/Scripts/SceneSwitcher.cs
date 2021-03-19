using UnityEngine;
using UnityEngine.SceneManagement;

/*
 Scenes
0 - MainMenu
1 - FileSelect
2 - CharacterAssign
3 - WorldMap
4 - Battle
5 - End Screen
 */

public class SceneSwitcher : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(2);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    static public void ToWolrdMap()
    {
        SceneManager.LoadScene(3);
    }

    static public void ToGameEnd()
    {
        SceneManager.LoadScene(5);
    }
}