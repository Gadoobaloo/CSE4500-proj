using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    //when cliked let battle sytem know what move was selected

    private GameObject battleSystemGO;
    private BattleSystem battleSystemScript;

    public GameObject parent;

    private void Start()
    {
        GetComponent<Button>().interactable = false;
        
        if(GameObject.Find("BattleSystem") != null)
        {
            battleSystemGO = GameObject.Find("BattleSystem");
            battleSystemScript = battleSystemGO.GetComponent<BattleSystem>();

            battleSystemScript.OnBattleStatePlayerTurn += ButtonEnable;
            battleSystemScript.OnBattleStateInBetween += ButtonDisable;
        }
    }

    private void ButtonEnable(object sender, EventArgs e)
    {
        GetComponent<Button>().interactable = true;
    }

    private void ButtonDisable(object sender, EventArgs e)
    {
        GetComponent<Button>().interactable = false;
    }

    public void AttackClick()
    {
        Debug.Log("attack was pressed!");
        StartCoroutine(battleSystemScript.SetupAttack(this.name, parent.name));
    }

}
