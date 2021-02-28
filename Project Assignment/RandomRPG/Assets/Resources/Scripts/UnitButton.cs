using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UnitButton : MonoBehaviour
{
    private Unit unitData;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "CharacterAssign")
        {
            unitData = GameInfo.getProtagHistory(id);

        }else
        {
            //SpawnSet(BattleBG.BattleEnvironment);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
