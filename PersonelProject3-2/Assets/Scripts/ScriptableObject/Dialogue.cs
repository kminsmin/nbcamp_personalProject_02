using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultDialogueData", menuName = "DialogueData/StartScene/Default", order =0)]
public class Dialogue : ScriptableObject
{
    [TextArea]
    public string[] dialogue;
}
