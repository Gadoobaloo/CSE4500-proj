using System.Collections.Generic;
using UnityEngine;

public enum PlayType { Playable, NPC }

public enum AttackTarget { SingleOpponent, AllOpponents, Self, SingleAlly, AllAllies }

public class GameInfo : MonoBehaviour
{
    static private List<int> levelHistory = new List<int>();
    static public List<Unit> protagSuggestHistory = new List<Unit>();
    static public List<Unit> protagChoices = new List<Unit>();

    static public bool CheckIfLevelRepeat(int level)
    {
        bool levelWasRepeated = false;

        foreach (int pastLevel in levelHistory)
        {
            if (pastLevel == level)
            {
                levelWasRepeated = true;
            }
        }
        return levelWasRepeated;
    }

    static public bool CheckIfProtagRepeat(Unit protag)
    {
        bool protagWasRepeated = false;

        if (protagSuggestHistory != null)
        {
            foreach (Unit pastProtag in protagSuggestHistory)
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
        levelHistory.TrimExcess();
    }

    static public void StoreProtag(Unit protag)
    {
        protagSuggestHistory.Add(protag);
        protagSuggestHistory.TrimExcess();
    }

    static public void StoreProtagChoice(Unit protagChoice)
    {
        if (protagChoices.Count < 3)
        {
            protagChoices.Add(protagChoice);
            protagChoices.TrimExcess();
        }
    }

    static public Unit GetProtagHistory(int index)
    {
        return protagSuggestHistory[index];
    }

    static public Unit GetProtagChoice(int index)
    {
        return protagChoices[index];
    }

    static public int GetProtagChoiceSize()
    {
        return protagChoices.Count;
    }
}