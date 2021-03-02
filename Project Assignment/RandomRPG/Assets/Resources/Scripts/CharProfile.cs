using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharProfile : MonoBehaviour
{
    private Unit charData;
    private int id;

    public Image charProfileImage;
    public Text nameValueText;
    public Text healthValueText;
    public Text attack1Text;
    public Text attack2Text;
    public Text attack3Text;

    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        charProfileImage.GetComponent<Button>().interactable = false;

        switch (this.name)
        {
            case "Char1":
                id = 0;
                break;
            case "Char2":
                id = 1;
                break;
            case "Char3":
                id = 2;
                break;
            default:
                Debug.Log("CharProfile.cs cant find a good name");
                break;
        }

        
        if(GameObject.Find("BattleSystem") != null)
        {
            charData = GameInfo.GetProtagChoice(id);
        }
        
        if (charData != null)
        {
            currentHealth = charData.maxHP;

            charProfileImage.sprite = charData.smallSprite;
            nameValueText.text = charData.charName;
            healthValueText.text = currentHealth.ToString();
            attack1Text.text = charData.attacks[0].attackName;
            attack2Text.text = charData.attacks[1].attackName;
            attack3Text.text = charData.attacks[2].attackName;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveUp()
    {
        LeanTween.moveY(this.gameObject.GetComponent<RectTransform>(), -195, 0.1f);
    }

    public void MoveDown()
    {
        LeanTween.moveY(this.gameObject.GetComponent<RectTransform>(), -259, 0.1f);
    }

    public Unit GetCharData()
    {
        return charData;
    }

}
