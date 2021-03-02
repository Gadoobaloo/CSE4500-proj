using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit", fileName = "Unit")]
public class Unit : ScriptableObject
{
    [System.Serializable]
    public class Attack
    {
        public string attackName;
        public AttackTarget attackTarget;
        public string attackBlurb;
        public bool attackDoesHeal;
        public int attackDamage;

        public bool doesRecoil;
        public int recoilDamage;
        public string recoilBlurb;
    }

    public string charName;
    public int maxHP;
    public Sprite largeSpite;
    public Sprite smallSprite;
    public PlayType playType;
    public Environment charEnvironment;
    public int minSpawnRate;
    public int maxSpawnRate;

    public List<Attack> attacks = new List<Attack>();
}


