using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<ItemStats> inventory = new List<ItemStats>();
    [SerializeField] private GameObject _player;
    private List<ItemStats> equippedList;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        equippedList = _player.GetComponent<CharacterStatsHandler>().statModifiers;
    }

    public void EquipItem(ItemStats item)
    {
        equippedList.Add(item);
        _player.GetComponent<CharacterStatsHandler>().UpdateCharacterStats();
    }

    public void UnequipAllItems()
    {
        equippedList?.Clear();
        _player.GetComponent<CharacterStatsHandler>().UpdateCharacterStats();
    }
}
