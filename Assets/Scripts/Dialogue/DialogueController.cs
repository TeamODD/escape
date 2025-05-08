using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogueText;
    public GameObject dialogueCanvas;
    public float typeingSpped=0.15f;
    
        
    private Text _text; // 메인 텍스트 
    private DialogueList _dialogueList;
    private Coroutine _typingCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text = dialogueText.GetComponent<Text>();
        _dialogueList = GetComponent<DialogueList>();
        
        //dialogueCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // 숫자 키보드 '2' 키 (키패드 아님)
        {
            Debug.Log("input testing key");
            PrintDialogue(-1);
        }
    }


   

    public void PrintDialogue(int flowIndex) // 음수라면 서브 독백 
    {
        Debug.Log("script print");
        _switchDialogueCanvas(true);
        string text="";
        if (flowIndex>=0) 
        {
            //text = _dialogueList.mainDialogue[flowIndex];
        }
        else
        {
            //text = _dialogueList.subDialogue[0];
            //서브에서 랜덤하게 출력 
        }
        StartTyping(text);
    }

    public void executeLoopText(int Count)
    {
        
    }

    public void StartTyping(string text) // 타이핑 애니메이션
    {
        if (_typingCoroutine != null)
        {
            StopCoroutine((_typingCoroutine));
        }

        _typingCoroutine = StartCoroutine(_typingText(text));
    }

    private IEnumerator _typingText(string fullText)
    {
        _text.text = "";
        foreach (char c in fullText)
        {
            _text.text += c;
            yield return new WaitForSeconds(typeingSpped);
        }

        _typingCoroutine=null;
    }

    private void _switchDialogueCanvas(bool type)
    {
        dialogueCanvas.SetActive(type);
    }
    
    
}
