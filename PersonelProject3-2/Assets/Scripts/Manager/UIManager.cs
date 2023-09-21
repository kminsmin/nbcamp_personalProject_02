using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private const string KEY_NAME = "PlayerName";
    private const string KEY_JOB = "PlayerJob";
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI _playerNameUI;
    [SerializeField] private TextMeshProUGUI _playerLevelUI;
    [SerializeField] private TextMeshProUGUI _playerGoldUI;
    [SerializeField] private TextMeshProUGUI[] _playerStatsUI;
    [SerializeField] private GameObject _player;

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

}
