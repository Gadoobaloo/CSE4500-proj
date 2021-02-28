using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 GOALS:
-determine what 3 levels will be displayed
    -send info to world map bg
-get input from player to record what the next environment will be
    -send info to "GameInfo.cs"
 */

public class WorldMap : MonoBehaviour
{
    Environment leftLevel;
    Environment middleLevel;
    Environment rightLevel;

    public GameObject leftBG;
    WorldMapBG leftBGScript;

    public GameObject middleBG;
    WorldMapBG middleBGScript;

    public GameObject rightBG;
    WorldMapBG rightBGScript;

    // Start is called before the first frame update
    void Start()
    {
        leftBGScript = leftBG.GetComponent<WorldMapBG>();
        middleBGScript = middleBG.GetComponent<WorldMapBG>();
        rightBGScript = rightBG.GetComponent<WorldMapBG>();

        leftLevel = DetermineLevel();
        middleLevel = DetermineLevel();
        rightLevel = DetermineLevel();

        leftBGScript.ChangeSprite(leftLevel);
        middleBGScript.ChangeSprite(middleLevel);
        rightBGScript.ChangeSprite(rightLevel);
    }

    //determine what 3 levels will be displayed on the world map
    Environment DetermineLevel()
    {
        Environment choice = Environment.None;
        int suggestion = 0;
        bool needNewSuggest = true;

        do
        {
            suggestion = Random.Range(1, Enviroments.GetNumOfEnvironments());
            needNewSuggest = GameInfo.CheckIfLevelRepeat(suggestion);
        } while (needNewSuggest);

        GameInfo.StoreLevel(suggestion);
        choice = Enviroments.IntToEnvironment(suggestion);

        return choice;
    }

    public void getClick(string id)
    {
        switch (id)
        {
            case "left":
                Debug.Log("left one was clicked");
                BattleBG.BattleEnvironment = leftLevel;
                SceneManager.LoadScene(4);
                break;
            case "middle":
                Debug.Log("middle one was clicked");
                BattleBG.BattleEnvironment = middleLevel;
                SceneManager.LoadScene(4);
                break;
            case "right":
                Debug.Log("right one was clicked");
                BattleBG.BattleEnvironment = rightLevel;
                SceneManager.LoadScene(4);
                break;
            default:
                Debug.Log("invalid id");
                break;
        }
    }

}
