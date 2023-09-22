using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModStat
{
    ATK,
    MAG,
    DEF,
    MDF,
    CRI,
    CRDMG,
    AVD
}
public class ItemStats : MonoBehaviour
{
    public bool isEquipped = false;
    public ModStat modStat;
    public float modParameter;
    public StatsChangeType statsChangeType;
    public BattleSO battleSO;
    public Sprite itemSprite;


    private void Start()
    {
        switch(modStat)
        {
            case ModStat.ATK:
                modParameter = battleSO.physicalAttack;
                break;
            case ModStat.MAG:
                modParameter = battleSO.magicalAttack;
                break;
            case ModStat.DEF:
                modParameter = battleSO.physicalDefense;
                break;
            case ModStat.MDF:
                modParameter = battleSO.magicalDefense;
                break;
            case ModStat.CRI:
                modParameter = battleSO.criticalRate;
                break;
            case ModStat.CRDMG:
                modParameter = battleSO.criticalDamage;
                break;
            case ModStat.AVD:
                modParameter = battleSO.avoidRate;
                break;
        }
    }
}
