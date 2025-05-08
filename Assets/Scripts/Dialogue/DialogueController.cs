using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    private Text _text; // 메인 텍스트 
   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "hello"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private bool _checkIsFlowDialogue()
    {
        return false;
    }

    public void PrintDialogue()
    {
        Debug.Log("textprint");
    }
}
