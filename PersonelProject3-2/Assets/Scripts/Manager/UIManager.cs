using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering;

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
    [SerializeField] private TextMeshProUGUI _itemActionText;
    [SerializeField] private TextMeshProUGUI _itemModText;
    [SerializeField] private TextMeshProUGUI _itemParameterText;
    [SerializeField] private Image _itemPopImage;
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
        _itemActionText.text = (GameManager.Instance.inventory[index].isEquipped) ? "장착 해제 하시겠습니까?" : "장착하시겠습니까?";
        _itemPopImage.sprite = GameManager.Instance.inventory[index].itemSprite;
        _itemModText.text = GameManager.Instance.inventory[index].modStat.ToString();
        ModStat modStat = GameManager.Instance.inventory[index].modStat;
        float modParameter = 0;
        BattleSO battleSO = GameManager.Instance.inventory[index].battleSO;
        switch (modStat)
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
        _itemParameterText.text = modParameter.ToString(); 

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
