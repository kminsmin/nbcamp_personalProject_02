using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStats { get; private set; }
    public List<ItemStats> statModifiers = new List<ItemStats>();

    private void Awake()
    {
        UpdateCharacterStats();
    }

    public void UpdateCharacterStats()
    {
        BattleSO battleSO = null;
        if (baseStats.battleSO != null)
        {
            battleSO = Instantiate(baseStats.battleSO);
        }

        CurrentStats = new CharacterStats { battleSO = battleSO };
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.maxMana = baseStats.maxMana;
        CurrentStats.level = baseStats.level;
        CurrentStats.gold = baseStats.gold;

        if(statModifiers.Count == 0) { return; }
        try
        {
            foreach (ItemStats itemStat in statModifiers)
            {
                switch (itemStat?.statsChangeType)
                {
                    case StatsChangeType.Add:
                        CurrentStats.battleSO.physicalAttack += itemStat.battleSO.physicalAttack;
                        CurrentStats.battleSO.magicalAttack += itemStat.battleSO.magicalAttack;
                        CurrentStats.battleSO.criticalRate += itemStat.battleSO.criticalRate;
                        CurrentStats.battleSO.criticalDamage += itemStat.battleSO.criticalDamage;
                        CurrentStats.battleSO.physicalDefense += itemStat.battleSO.physicalDefense;
                        CurrentStats.battleSO.magicalDefense += itemStat.battleSO.magicalDefense;
                        CurrentStats.battleSO.avoidRate += itemStat.battleSO.avoidRate;
                        break;
                    case StatsChangeType.Multiple:
                        CurrentStats.battleSO.physicalAttack *= itemStat.battleSO.physicalAttack;
                        CurrentStats.battleSO.magicalAttack *= itemStat.battleSO.magicalAttack;
                        CurrentStats.battleSO.criticalRate *= itemStat.battleSO.criticalRate;
                        CurrentStats.battleSO.criticalDamage *= itemStat.battleSO.criticalDamage;
                        CurrentStats.battleSO.physicalDefense *= itemStat.battleSO.physicalDefense;
                        CurrentStats.battleSO.magicalDefense *= itemStat.battleSO.magicalDefense;
                        CurrentStats.battleSO.avoidRate *= itemStat.battleSO.avoidRate;
                        break;
                    case StatsChangeType.Override:
                        CurrentStats.battleSO.physicalAttack = itemStat.battleSO.physicalAttack;
                        CurrentStats.battleSO.magicalAttack = itemStat.battleSO.magicalAttack;
                        CurrentStats.battleSO.criticalRate = itemStat.battleSO.criticalRate;
                        CurrentStats.battleSO.criticalDamage = itemStat.battleSO.criticalDamage;
                        CurrentStats.battleSO.physicalDefense = itemStat.battleSO.physicalDefense;
                        CurrentStats.battleSO.magicalDefense = itemStat.battleSO.magicalDefense;
                        CurrentStats.battleSO.avoidRate = itemStat.battleSO.avoidRate;
                        break;
                    default: break;

                }
            }
        }
        catch(Exception ex)
        {
            return;
        }
        


    }
}
