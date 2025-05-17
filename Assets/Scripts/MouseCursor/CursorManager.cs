using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public List<Texture2D> cursorTextures;
    public static CursorManager Instance{get; private set;}

    private Vector2 cursorHotspot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    
    public void ChangeCursor(bool status)
    {
        if (status) //꿈
        {
            Cursor.SetCursor(cursorTextures[0], new Vector2(4, 4), CursorMode.Auto);
            Cursor.SetCursor(cursorTextures[0],cursorHotspot,CursorMode.Auto);
        }
        else //현실
        {
            Cursor.SetCursor(cursorTextures[1], new Vector2(4, 4), CursorMode.Auto);
            Cursor.SetCursor(cursorTextures[1],cursorHotspot,CursorMode.Auto);
        }
    }
}
