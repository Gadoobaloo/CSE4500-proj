using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private GameObject unitButton;
    static private Unit currentSpawnChoice;

    readonly List<Unit> Protags = new List<Unit>();
    readonly List<Unit> Enemies = new List<Unit>();

    // Start is called before the first frame update
    void Start()
    {
        unitButton = Resources.Load<GameObject>("Prefabs/UnitButton");
        Protags.AddRange(Resources.LoadAll<Unit>("Objects/Protags"));
        Enemies.AddRange(Resources.LoadAll<Unit>("Objects/Enemies"));

        Protags.TrimExcess();
        Enemies.TrimExcess();

        if (SceneManager.GetActiveScene().name == "CharacterAssign")
        {
            SpawnSet(Environment.None);
        }
        else
        {
            SpawnSet(BattleBG.BattleEnvironment);
        }
    }

    //just by passing in the environment type this should spawn the nessesary entities
    void SpawnSet(Environment enviro)
    {
        if (enviro == Environment.None)
        {
            int numOfProtagToSpawn = 3;

            while (numOfProtagToSpawn > 0)
            {
                DetermineProtagChoice();
                SpawnUnit();
                numOfProtagToSpawn--;
            }
        }
    }

    void DetermineProtagChoice()
    {
        bool needNewUnit;

        do
        {
            currentSpawnChoice = Protags[Random.Range(0, Protags.Count)];
            needNewUnit = GameInfo.CheckIfProtagRepeat(currentSpawnChoice);
        } while (needNewUnit);

        GameInfo.StoreProtag(currentSpawnChoice);
    }

    private void SpawnUnit()
    {
        GameObject toSpawn;

        toSpawn = Instantiate(unitButton, this.transform) as GameObject;

        toSpawn.GetComponent<UnitButton>().SetUnitData(currentSpawnChoice);

        //Debug.Log(toSpawn.name);
    }

    static public Unit GetSpawnChoice()
    {
        return currentSpawnChoice;
    }
}
