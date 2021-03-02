using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum BattleState { Start, PlayerTurn, EnemyTurn, InBetween, Won, Lost}

public class BattleSystem : MonoBehaviour
{
    //static public BattleState currentBattleState;

    static public int numOfBattles;

    public event EventHandler OnBattleStateStart;
    public event EventHandler OnBattleStatePlayerTurn;
    public event EventHandler OnBattleStateEnemyTurn;
    public event EventHandler OnBattleStateInBetween;
    public event EventHandler OnBattleStateTargetEnemy;
    public event EventHandler OnBattleStateTargetAlly;
    public event EventHandler OnBattleStateEnd;

    public Text battleText;

    public GameObject EnemyPanel;

    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;

    private Unit Char1Data;
    private Unit Char2Data;
    private Unit Char3Data;

    private GameObject activeChar = null;
    private Unit activeCharData = null;
    private int attackID = 3;

    // Start is called before the first frame update
    void Start()
    {
        Char1Data = Char1.GetComponent<CharProfile>().GetCharData();
        Char2Data = Char2.GetComponent<CharProfile>().GetCharData();
        Char3Data = Char3.GetComponent<CharProfile>().GetCharData();

        //currentBattleState = BattleState.Start;
        StartCoroutine(BattleStart());
    }

    private void Update()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies == null)
        {
            OnBattleStateEnd?.Invoke(this, EventArgs.Empty);
        }
    }

    IEnumerator BattleStart()
    {
        OnBattleStateStart?.Invoke(this, EventArgs.Empty);
        battleText.text = "Some enemies appeared!";
        yield return new WaitForSeconds(2f);

        StartCoroutine(PlayerTurn(Char1, Char1Data));
    }

    IEnumerator PlayerTurn(GameObject nowChar, Unit nowCharData)
    {
        //currentBattleState = BattleState.PlayerTurn;
        OnBattleStatePlayerTurn?.Invoke(this, EventArgs.Empty); //send ping to all subscribers on this list
        yield return new WaitForSeconds(0f);
        battleText.text = "What will " + nowCharData.charName + " do?";
        nowChar.GetComponent<CharProfile>().MoveUp();
    }

    IEnumerator EnemyTurn()
    {
        OnBattleStateEnemyTurn?.Invoke(this, EventArgs.Empty);
        battleText.text = "enemy turn...";
        yield return new WaitForSeconds(2f);
    }


    public IEnumerator SetupAttack(string attackButtonName, string charName)
    {
        OnBattleStateInBetween?.Invoke(this, EventArgs.Empty);

        switch (charName)
        {
            case "Char1":
                activeChar = Char1;
                activeCharData = Char1Data;
                break;
            case "Char2":
                activeChar = Char2;
                activeCharData = Char2Data;
                break;
            case "Char3":
                activeChar = Char3;
                activeCharData = Char3Data;
                break;
            default:
                Debug.Log("Uh oh char not found");
                break;
        }

        switch (attackButtonName)
        {
            case "Attack1Button":
                attackID = 0;
                break;
            case "Attack2Button":
                attackID = 1;
                break;
            case "Attack3Button":
                attackID = 2;
                break;
            default:
                Debug.Log("oops attack not found");
                break;
        }

        activeChar.GetComponent<CharProfile>().MoveDown();

        if (activeCharData.attacks[attackID].attackTarget == AttackTarget.SingleOpponent)
        {
            OpponentTargetChoice();
        } else if (activeCharData.attacks[attackID].attackTarget == AttackTarget.SingleAlly)
        {
            AllyTargetChoice();
        } else if (activeCharData.attacks[attackID].attackTarget == AttackTarget.AllOpponents)
        {
            AttackAllOpponent();
        }

        //battleText.text = activeCharData.charName + " " + activeCharData.attacks[attackID].attackBlurb;
        yield return new WaitForSeconds(0f);
    }

    void OpponentTargetChoice()
    {
        OnBattleStateTargetEnemy?.Invoke(this, EventArgs.Empty);
        battleText.text = "Select an opponent to target";
    }

    void AllyTargetChoice()
    {
        OnBattleStateTargetAlly?.Invoke(this, EventArgs.Empty);
        battleText.text = "Select an ally to target";
    }

    public IEnumerator AttackSingleOpponent(GameObject target)
    {
        OnBattleStateInBetween?.Invoke(this, EventArgs.Empty);

        battleText.text = activeCharData.charName + " " + activeCharData.attacks[attackID].attackBlurb;
        yield return new WaitForSeconds(2f);

        int targetHP = target.GetComponent<UnitButton>().TakeDamage(activeCharData.attacks[attackID].attackDamage);
            
        battleText.text = target.GetComponent<UnitButton>().GetUnitName() + " took " + activeCharData.attacks[attackID].attackDamage + " damage!";
        yield return new WaitForSeconds(2f);


        if (target.GetComponent<UnitButton>().GetCurrentHP() <= 0)
        {
            battleText.text = target.GetComponent<UnitButton>().GetUnitName() + " was defeated!";
            yield return new WaitForSeconds(2f);
            target.GetComponent<UnitButton>().Die();
        }
        else 
        { 
            battleText.text = target.GetComponent<UnitButton>().GetUnitName() + " now has " + target.GetComponent<UnitButton>().GetCurrentHP() + " HP!";
            yield return new WaitForSeconds(2f);
        }


        if (Spawner.numOfEnemies <= 0)
        {
            OnBattleStateEnd?.Invoke(this, EventArgs.Empty);
            numOfBattles++;
            if (numOfBattles >= 3)
            {
                Debug.Log("the game should be over");
                SceneSwitcher.ToGameEnd();
            }
            else 
            { 
                Debug.Log("battle completed");
                SceneSwitcher.ToWolrdMap();
            }

        } else
        {
            SwitchTurn();
        }


    }

    public void AttackAllOpponent()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> targets = enemies.ToList();

        foreach (GameObject target in targets)
        {
            StartCoroutine(AttackSingleOpponent(target));
        }
    }

    public void SwitchTurn()
    {
        switch (activeChar.name)
        {
            case "Char1":
                StartCoroutine(PlayerTurn(Char2, Char2Data));
                break;
            case "Char2":
                StartCoroutine(PlayerTurn(Char3, Char3Data));
                break;
            case "Char3":
                StartCoroutine(PlayerTurn(Char1, Char1Data));
                break;
            default:
                Debug.Log("Ohhh nooo");
                break;
        }
    }
}


