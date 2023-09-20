using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "StatData/PlayerAttacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float physicalAttack;
    public float magicalAttack;
    public float criticalRate;
    public float criticalDamage;
}
