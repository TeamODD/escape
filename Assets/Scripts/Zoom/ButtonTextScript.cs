using System;
using UnityEngine;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine.UI;

public class ButtonTextScript : MonoBehaviour
{

    public Text _text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(String input)
    {
        _text.text = input;
    }
    
}
