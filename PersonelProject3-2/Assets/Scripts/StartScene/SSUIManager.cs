using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SSUIManager : MonoBehaviour
{
    public static SSUIManager instance;
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private TextMeshProUGUI _dialogueText;
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
}
