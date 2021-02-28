using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayType { Playable, NPC }
public enum AttackTarget { SingleOpponent, AllOpponents, Self, SingleAlly, AllAllies }

public class GameInfo : MonoBehaviour
{
    static private List<int> levelHistory = new List<int>();
    static private List<Unit> protagHistory = new List<Unit>();

    //static private GameInfo instance;

    /*
    static string charChoice1;
    static string charChoice2;
    static string charChoice3;
    */

    private void Start()
    {
        /*
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        */
    }

    static public bool CheckIfLevelRepeat(int level)
    {
        bool levelWasRepeated = false;

        foreach (int pastLevel in levelHistory)
        {
            if(pastLevel == level)
            {
                levelWasRepeated = true;
            }
        }
        return levelWasRepeated;
    }

    static public bool CheckIfProtagRepeat(Unit protag)
    {
        bool protagWasRepeated = false;

        if(protagHistory != null)
        {
            foreach (Unit pastProtag in protagHistory)
            {
                if (pastProtag == protag)
                {
                    protagWasRepeated = true;
                }
            }
        }

        return protagWasRepeated;
    }


    static public void StoreLevel(int level)
    {
        levelHistory.Add(level);
    }

    static public void StoreProtag(Unit protag)
    {
        protagHistory.Add(protag);
    }

    static public Unit GetProtagHistory(int index)
    {
        return protagHistory[index];
    }



}
