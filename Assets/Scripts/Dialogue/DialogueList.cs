using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


public class DialogueList : MonoBehaviour
{
    private List<List<string>> mainDialogues=new List<List<string>>(); //플로우에 따른 대사 
    private List<List<string>> subDialogues=new List<List<string>>(); //일반 상호작용에대한 대사


    public void Start()
    {
        List<string> main0 = new List<string> {"hello first text"};
        List<string> main1 = new List<string> {"hello first text","Its second"};
    
        mainDialogues.Add(main0);
        mainDialogues.Add(main1);
        
        
        List<string> sub0 = new List<string> {"hello first text","Its second"};
        List<string> sub1 = new List<string> {"hello first text","Its second"};
        
        subDialogues.Add(sub0);
        subDialogues.Add(sub1);
    }


    
    
}
