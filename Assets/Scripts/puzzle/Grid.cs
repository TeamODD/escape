using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.UI;

public class Grid
{

    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;
    private Vector3 originPosition;
    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        
        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];
        
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x,y]=UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y)+ new Vector3(cellSize,cellSize)*.5f,20, Color.white, TextAnchor.MiddleCenter); //텍스트를 쉽게 보여주는 에셋 사이즈도 바꿀수있음
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x, y+1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x+1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width,height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width,0), GetWorldPosition(width,height), Color.white, 100f);
    }
    
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y)* cellSize + originPosition;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }
    
    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)//값이 유효한지 확인
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x,y,value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height) //값이 유효한지 확인
        {
            return gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x,y);
    }

    public void HighlightAvailableTiles(int x, int y)
    {
        ClearHighLights();
        Vector2Int[] directions =
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };

        foreach (var dir in directions)
        {
            int checkX = x - dir.x;
            int checkY = y - dir.y;
            if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
            {
                if (gridArray[checkX, checkY] != 2)
                {
                    debugTextArray[checkX, checkY].color = Color.yellow;
                }
            }
        }
    }

    public void  ClearHighLights()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                debugTextArray[x, y].color = Color.white;
            }
        }
    }
}
