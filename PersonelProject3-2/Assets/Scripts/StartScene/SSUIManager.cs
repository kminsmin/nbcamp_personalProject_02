using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SSUIManager : MonoBehaviour
{
    public static SSUIManager instance;
    private const string KEY_NAME = "PlayerName";
    private const string KEY_JOB = "PlayerJob";
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private GameObject _playerChoicePanel;
    [SerializeField] private GameObject _playerNamePanel;
    [SerializeField] private  float textInterval;

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator UpdateText(char[] letters)
    {
        string textBuffer = null;
        int i = 0;
        float time = 0;
        
        while (i < letters.Length)
        {
            if (time <= 0)
            {
                textBuffer += letters[i];
                _dialogueText.text = textBuffer;
                time += textInterval;
                i++;
            }
            else
            {
                time -= Time.deltaTime;
                yield return null;
            }
                
        }
        _dialogueManager.NextTextReady();
    }

    public void ActivatePlayerNamePanel()
    {
        _playerNamePanel.SetActive(true);
    }

    public void DeactivatePlayerNamePanel()
    {
        string playerName = _nameText.text;
        _playerNamePanel.SetActive(false);
        if (playerName.Length > 1)
        {
            PlayerPrefs.SetString(KEY_NAME, playerName);
            _dialogueManager.dialogueIndex = 5;
            _dialogueManager.ShowNextText?.Invoke(_dialogueManager.texts[_dialogueManager.dialogueIndex]);
        }
        else
        {
            _dialogueManager.dialogueIndex = 4;
            _dialogueManager.ShowNextText?.Invoke(_dialogueManager.texts[_dialogueManager.dialogueIndex]);
        }
    }

    public void ActivatePlayerChoicePanel()
    {
        _playerChoicePanel.SetActive(true);
    }

    public void ChooseWarrior()
    {
        _playerChoicePanel.SetActive(false);
        PlayerPrefs.SetInt(KEY_JOB, 0);
        _dialogueManager.dialogueIndex = 7;
        _dialogueManager.ShowNextText?.Invoke(_dialogueManager.texts[_dialogueManager.dialogueIndex]);
    }

    public void ChooseThief()
    {
        _playerChoicePanel.SetActive(false);
        PlayerPrefs.SetInt(KEY_JOB, 1);
        _dialogueManager.dialogueIndex = 7;
        _dialogueManager.ShowNextText?.Invoke(_dialogueManager.texts[_dialogueManager.dialogueIndex]);
    }

    public void ChooseArcher()
    {
        _playerChoicePanel.SetActive(false);
        PlayerPrefs.SetInt(KEY_JOB, 2);
        _dialogueManager.dialogueIndex = 7;
        _dialogueManager.ShowNextText?.Invoke(_dialogueManager.texts[_dialogueManager.dialogueIndex]);
    }

    public void ChooseMagician()
    {
        _playerChoicePanel.SetActive(false);
        PlayerPrefs.SetInt(KEY_JOB, 3);
        _dialogueManager.dialogueIndex = 7;
        _dialogueManager.ShowNextText?.Invoke(_dialogueManager.texts[_dialogueManager.dialogueIndex]);
    }
}
