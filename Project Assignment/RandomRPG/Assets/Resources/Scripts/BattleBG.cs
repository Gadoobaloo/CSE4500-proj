using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBG : MonoBehaviour
{
    private SpriteRenderer rend;
    static public Environment BattleEnvironment;

    private void Start()
    {
        rend = this.GetComponent<SpriteRenderer>();
        rend.sprite = Enviroments.EnvironmentToSprite(BattleEnvironment);
    }
}
