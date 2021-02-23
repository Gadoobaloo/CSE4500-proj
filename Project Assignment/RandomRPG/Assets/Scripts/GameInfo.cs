using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enviroment { None, Beach, Castle, City, Desert, Forest, Snow, Space, Underwater, Volcano }
public enum PlayType { Playable, NPC }
public enum AttackTarget { SingleOpponent, AllOpponents, Self, SingleAlly, AllAllies }

public class GameInfo : MonoBehaviour
{
    private int numOfEnvironments = 9;
    List<int> levelHistory = new List<int>();


    private void NextLevelChooser()
    {
        List<Enviroment> nextEnvironments = new List<Enviroment>();

        do
        {
            RandomLevelNumber();
        } while (IsLevelNewCheck());



    }

    private int RandomLevelNumber()
    {
        int randomChoice = Random.Range(1, numOfEnvironments + 1);

        return randomChoice;
    }

    bool IsLevelNewCheck()
    {
        bool isNewLevel = true;

        return isNewLevel;
    }


}
