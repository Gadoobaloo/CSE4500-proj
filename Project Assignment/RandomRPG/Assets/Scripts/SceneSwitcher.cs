using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 Scenes
0 - MainMenu
1 - FileSelect
2 - CharacterAssign
3 - WorldMap
4 - Battle
 */

public class SceneSwitcher : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(2);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
