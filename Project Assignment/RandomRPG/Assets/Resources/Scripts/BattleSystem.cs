using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    static public int numOfBattles;

    public event EventHandler OnBattleStateStart;

    public event EventHandler OnBattleStatePlayerTurn;

    public event EventHandler OnBattleStateEnemyTurn;

    public event EventHandler OnBattleStateInBetween;

    public event EventHandler OnBattleStateTargetEnemy;

    public event EventHandler OnBattleStateTargetAlly;

    public event EventHandler OnBattleStateEnd;

    public Text battleText;

    public AudioClip smallSound;
    public AudioClip bigSound;

    private AudioSource audioSource;

    public GameObject EnemyPanel;

    private GameObject Char1;
    private GameObject Char2;
    private GameObject Char3;

    private Unit Char1Data;
    private Unit Char2Data;
    private Unit Char3Data;

    private GameObject activeChar;
    private Unit activeCharData;
    private int attackID;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Char1 = GameObject.Find("Char1");
        Char2 = GameObject.Find("Char2");
        Char3 = GameObject.Find("Char3");

        Char1Data = GameInfo.protagChoices[0];
        Char2Data = GameInfo.protagChoices[1];
        Char3Data = GameInfo.protagChoices[2];

        StartCoroutine(BattleStart());
    }

    private IEnumerator BattleStart()
    {
        OnBattleStateStart?.Invoke(this, EventArgs.Empty);

        battleText.text = "Some enemies appeared!";
        yield return new WaitForSeconds(2f);

        if (Char1 != null && Char1Data != null)
        {
            PlayerTurn(Char1, Char1Data);
        }
        else
        {
            battleText.text = "something is still wrong...";
        }
    }

    private void PlayerTurn(GameObject nowChar, Unit nowCharData)
    {
        OnBattleStatePlayerTurn?.Invoke(this, EventArgs.Empty); //send ping to all subscribers on this list
        battleText.text = "What will " + nowCharData.charName + " do?";
        nowChar.GetComponent<CharProfile>().MoveUp();
    }

    private IEnumerator EnemyTurn()
    {
        OnBattleStateEnemyTurn?.Invoke(this, EventArgs.Empty);
        battleText.text = "enemy turn...";
        yield return new WaitForSeconds(2f);
    }

    public IEnumerator SetupAttack(string attackButtonName, string charName)
    {
        OnBattleStateInBetween?.Invoke(this, EventArgs.Empty);
        audioSource.PlayOneShot(smallSound, .8f);

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
                Debug.LogError("Uh oh char not found");
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
                Debug.LogError("oops attack not found");
                break;
        }

        activeChar.GetComponent<CharProfile>().MoveDown();

        if (activeCharData.attacks[attackID].attackTarget == AttackTarget.SingleOpponent)
        {
            OpponentTargetChoice();
        }
        else if (activeCharData.attacks[attackID].attackTarget == AttackTarget.SingleAlly)
        {
            AllyTargetChoice();
        }
        else if (activeCharData.attacks[attackID].attackTarget == AttackTarget.AllOpponents)
        {
            AttackAllOpponent();
        }

        yield return new WaitForSeconds(0f);
    }

    private void OpponentTargetChoice()
    {
        OnBattleStateTargetEnemy?.Invoke(this, EventArgs.Empty);
        battleText.text = "Select an opponent to target";
    }

    private void AllyTargetChoice()
    {
        OnBattleStateTargetAlly?.Invoke(this, EventArgs.Empty);
        battleText.text = "Select an ally to target";
    }

    public IEnumerator AttackSingleOpponent(GameObject target)
    {
        OnBattleStateInBetween?.Invoke(this, EventArgs.Empty);
        audioSource.PlayOneShot(bigSound, .8f);

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
        }
        else
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
                PlayerTurn(Char2, Char2Data);
                break;

            case "Char2":
                PlayerTurn(Char3, Char3Data);
                break;

            case "Char3":
                PlayerTurn(Char1, Char1Data);
                break;

            default:
                Debug.LogError("Ohhh nooo");
                break;
        }
    }
}