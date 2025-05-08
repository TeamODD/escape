using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueList", menuName = "Scriptable Objects/DialogueList")]
public class DialogueList : ScriptableObject
{
    public List<string> MainDialogue=new List<string>();


}
