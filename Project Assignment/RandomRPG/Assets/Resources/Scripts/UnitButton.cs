using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    private Unit unitData;
    public Image childImage;

    private GameObject battleSystemGO;
    private BattleSystem battleSystemScript;

    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("BattleSystem") != null)
        {
            currentHP = unitData.maxHP;

            battleSystemGO = GameObject.Find("BattleSystem");
            battleSystemScript = battleSystemGO.GetComponent<BattleSystem>();

            GetComponent<Button>().interactable = false;

            battleSystemScript.OnBattleStateStart += ButtonDisable;
            battleSystemScript.OnBattleStateInBetween += ButtonDisable;
            battleSystemScript.OnBattleStateTargetEnemy += ButtonEnable;
        }
        childImage.sprite = unitData.largeSpite;
    }

    public void SetUnitData(Unit tempUnit) 
    {
        unitData = tempUnit;
    }

    public void ClickedAction()
    {
        if (unitData.playType == PlayType.Playable) 
        {
            GameInfo.StoreProtagChoice(unitData);
            GetComponent<Button>().interactable = false;
            Destroy(this.gameObject, 1.0f);
        } else if (unitData.playType == PlayType.NPC)
        {
            Debug.Log("enemy was clicked");
            StartCoroutine(battleSystemScript.AttackSingleOpponent(this.gameObject));
            //GetComponent<Button>().interactable = false;
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

    public int TakeDamage(int damage)
    {
        currentHP -= damage;
        return currentHP;
    }

    public string GetUnitName()
    {
        return unitData.charName;
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    public void Die()
    {
        battleSystemScript.OnBattleStateStart -= ButtonDisable;
        battleSystemScript.OnBattleStateInBetween -= ButtonDisable;
        battleSystemScript.OnBattleStateTargetEnemy -= ButtonEnable;
        Spawner.numOfEnemies--;
        Destroy(this.gameObject);
    }


}
