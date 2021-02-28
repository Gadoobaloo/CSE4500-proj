using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    private GameObject unitButton;

    List<Unit> Protags = new List<Unit>();
    List<Unit> Enemies = new List<Unit>();
    static public Unit currentSpawnChoice;

    // Start is called before the first frame update
    void Start()
    {
        unitButton = Resources.Load<GameObject>("Prefabs/UnitButton");

        Protags.AddRange(Resources.LoadAll<Unit>("Objects/Protags"));
        Enemies.AddRange(Resources.LoadAll<Unit>("Objects/Enemies"));

        Protags.TrimExcess();
        Enemies.TrimExcess();

        if (SceneManager.GetActiveScene().name == "CharacterAssign") {
            SpawnSet(Environment.None);
        } else
        {
            SpawnSet(BattleBG.BattleEnvironment);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //just by passing in the environment type this should spawn the nessesary entities
    void SpawnSet(Environment environment)
    {
        //but how does it determine it?
        //there are two types
        //for the char choice, make sure there are three on screen and when one is selected, replace that one
        //for enemy spawn, spawn enemies at the start of a battle, spawn as many as needed

        if(environment == Environment.None)
        {
            int numOfProtagToSpawn = 3;

            while(numOfProtagToSpawn > 0)
            {
                DetermineProtagChoice();
                SpawnUnit();
                Debug.Log("spawned");
            }
        }
    }


    void DetermineProtagChoice()
    {
        bool needNewUnit = true;

        do
        {
            currentSpawnChoice = Protags[Random.Range(0, Protags.Count)];
            needNewUnit = GameInfo.checkIfProtagRepeat(currentSpawnChoice);
        } while (needNewUnit);

        GameInfo.storeProtag(currentSpawnChoice);
    }

    private void SpawnUnit()
    {
        GameObject toSPawn = Instantiate(unitButton, this.transform) as GameObject;
    }

}
