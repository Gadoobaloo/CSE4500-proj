using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [System.Serializable]
    public class Attack
    {
        public string attackName;
        public AttackTarget attackTarget;
        public string attackBlurb;
        public int attackDamage;
    }

    public string unitName;
    public PlayType unitType;
    public Enviroment unitEnvironment;
    public int maxHP;
    public int currentHP;

    public List<Attack> attacks = new List<Attack>();

}
