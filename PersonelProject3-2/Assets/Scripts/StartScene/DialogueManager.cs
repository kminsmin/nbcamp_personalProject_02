using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;
    public bool _isEnd {get; private set;}
    [HideInInspector] public int dialogueIndex = 0;
    public Action<string> ShowNextText;
    [HideInInspector] public string[] texts;

    private void Awake()
    {
        ShowNextText += ChangeText;
    }
    private void Start()
    {
        texts = _dialogue.dialogue;
        NextTextReady();
    }

    private void Update()
    {
        if (_isEnd&&Input.GetKeyDown(KeyCode.Space))
        {
            _isEnd = false;
            try
            {
                ShowNextText?.Invoke(texts[dialogueIndex]);
            }
            catch (IndexOutOfRangeException e)
            {
                Debug.Log("End of Conversation");
                SceneManager.LoadScene(0);
            }
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
        switch(dialogueIndex)
        {
            case 3: 
                SSUIManager.instance.ActivatePlayerNamePanel();
                _isEnd = false;
                return;
            case 4: 
                SSUIManager.instance.ActivatePlayerNamePanel();
                _isEnd = false;
                return;
            case 6:
                SSUIManager.instance.ActivatePlayerChoicePanel();
                _isEnd = false;
                return;
            default: 
                break;
        }
        dialogueIndex++;
         _isEnd = true;
    }
}
