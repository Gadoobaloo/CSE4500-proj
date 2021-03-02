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

    static public int numOfEnemies;

    int sceneCoutdown;

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


    private void Update()
    {
        if (this.transform.childCount < 3 && SceneManager.GetActiveScene().name == "CharacterAssign")
        {
            DetermineProtagChoice();
            SpawnUnit();
            sceneCoutdown--;
            if(sceneCoutdown <= 0)
            {
                SceneSwitcher.ToWolrdMap();
            }
        }
    }

    //just by passing in the environment type this should spawn the nessesary entities
    void SpawnSet(Environment enviro)
    {
        if (enviro == Environment.None)
        {
            int numOfProtagToSpawn = 3;
            sceneCoutdown = 3;

            while (numOfProtagToSpawn > 0)
            {
                DetermineProtagChoice();
                SpawnUnit();
                numOfProtagToSpawn--;
            }
        } else
        {
            DetermineEnemyChoice(enviro);
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

    void DetermineEnemyChoice(Environment enviro)
    {
        foreach(Unit enemy in Enemies)
        {
            if(enemy.charEnvironment == enviro)
            {
                int min = enemy.minSpawnRate;
                int max = enemy.maxSpawnRate;

                int numToSpawn = Random.Range(min, max + 1);

                while(numToSpawn > 0)
                {
                    currentSpawnChoice = enemy;
                    SpawnUnit();
                    numOfEnemies++;
                    numToSpawn--;
                }
            }
        }
    }

    private void SpawnUnit()
    {
        GameObject toSpawn;

        toSpawn = Instantiate(unitButton, this.transform) as GameObject;

        toSpawn.GetComponent<UnitButton>().SetUnitData(currentSpawnChoice);
    }

    static public Unit GetSpawnChoice()
    {
        return currentSpawnChoice;
    }
}
