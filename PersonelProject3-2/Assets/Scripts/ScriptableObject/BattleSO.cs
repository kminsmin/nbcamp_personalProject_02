using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "StatData/PlayerAttacks/Default", order = 0)]
public class BattleSO : ScriptableObject
{
    [Header("Attack Info")]
    public float physicalAttack;
    public float magicalAttack;
    public float criticalRate;
    public float criticalDamage;

    [Header("Defense Info")]
    public float physicalDefense;
    public float magicalDefense;
    public float avoidRate;
}
