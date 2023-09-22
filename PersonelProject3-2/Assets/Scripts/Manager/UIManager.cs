using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public enum ItemAction
{
    NONE,
    CANCEL,
    CONFIRM
}

public class UIManager : MonoBehaviour
{
    private const string KEY_NAME = "PlayerName";
    private const string KEY_JOB = "PlayerJob";
    public const string KEY = "ItemIndex";
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI _playerNameUI;
    [SerializeField] private TextMeshProUGUI _playerLevelUI;
    [SerializeField] private TextMeshProUGUI _playerGoldUI;
    [SerializeField] private TextMeshProUGUI[] _playerStatsUI;
    [SerializeField] private GameObject[] _equipFlags;
    [SerializeField] private GameObject _itemPopup;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _itemGridsTransform;
    public ItemAction itemAction = ItemAction.NONE;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _playerNameUI.text = PlayerPrefs.GetString(KEY_NAME);
        _playerGoldUI.text = _player.GetComponent<CharacterStatsHandler>().CurrentStats.gold.ToString();
        _playerLevelUI.text = _player.GetComponent<CharacterStatsHandler>().CurrentStats.level.ToString();
    }

    public void UpdatePlayerStatusUI()
    {
        CharacterStats currentStats = _player.GetComponent<CharacterStatsHandler>().CurrentStats;
        List<string> statStringList = new List<string>
        {
            currentStats.maxHealth.ToString(),
            currentStats.maxMana.ToString(),
            currentStats.battleSO.physicalAttack.ToString(),
            currentStats.battleSO.magicalAttack.ToString(),
            currentStats.battleSO.criticalRate.ToString(),
            currentStats.battleSO.criticalDamage.ToString(),
            currentStats.battleSO.physicalDefense.ToString(),
            currentStats.battleSO.magicalDefense.ToString(),
            currentStats.battleSO.avoidRate.ToString()
        };
        int i = 0;
        foreach (var stat in _playerStatsUI)
        {
            stat.text = statStringList[i];
            i++;
        }
    }

    public void LoadInventoryUI()
    {
        List<ItemStats> inventory = GameManager.Instance.inventory;
        for(int i = 0; i < inventory.Count; i++)
        {
            Transform itemGrid = _itemGridsTransform.GetChild(i);
            itemGrid.GetComponent<ItemGrid>().itemIndex = i;
            Image image = itemGrid.GetChild(0).GetComponent<Image>();
            image.sprite = inventory[i].itemSprite;
        }
    }

    public void ShowItemPopup(int index)
    {
        if (index >= GameManager.Instance.inventory.Count)
            return;
        _itemPopup.SetActive(true);

        switch (itemAction)
        {
            case ItemAction.NONE:
                PlayerPrefs.SetInt(KEY, index);
                break;
            case ItemAction.CANCEL:
                _itemPopup.SetActive(false);
                itemAction = ItemAction.NONE;
                return;
            case ItemAction.CONFIRM:
                CheckItemEquip(index);
                _itemPopup.SetActive(false);
                itemAction = ItemAction.NONE;
                return;

        }
    }

    public void CheckItemEquip(int index)
    {
        if (!(GameManager.Instance.inventory[index].isEquipped))
        {
            GameManager.Instance.inventory[index].isEquipped = true;
            _equipFlags[index].gameObject.SetActive(true);
        }
        else
        {
            GameManager.Instance.inventory[index].isEquipped = false;
            _equipFlags[index].gameObject.SetActive(false);
        }
    }

}
