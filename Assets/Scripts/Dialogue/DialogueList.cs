using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueList", menuName = "Scriptable Objects/DialogueList")]
public class DialogueList : MonoBehaviour
{
    public List<string> mainDialogue=new List<string>(); //플로우에 따른 대사 
    public List<string> subDialogue=new List<string>(); //일반 상호작용에대한 대사

}
