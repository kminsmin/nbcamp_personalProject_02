using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;
    public bool _isEnd {get; private set;}
    private int _dialogueIndex = 0;
    public Action<string> ShowNextText;
    private string[] _texts;

    private void Awake()
    {
        ShowNextText += ChangeText;
    }
    private void Start()
    {
        _texts = _dialogue.dialogue;
        NextTextReady();
    }

    private void Update()
    {
        if (_isEnd&&Input.GetKeyDown(KeyCode.Space))
        {
            _isEnd = false;
            ShowNextText?.Invoke(_texts[_dialogueIndex]);
        }
    }

    private void ChangeText(string line)
    {
        string _line = line;
        char[] dialogueTexts = _line.ToCharArray();
        StartCoroutine(SSUIManager.instance.UpdateText(dialogueTexts));
    }

    public void NextTextReady()
    {
        switch(_dialogueIndex)
        {
            case 3: //TODO
                break;
            default: 
                break;
        }
        _dialogueIndex++;
        _isEnd = true;
    }
}
