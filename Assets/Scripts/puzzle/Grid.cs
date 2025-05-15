using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private GameObject[,] cellVisuals;
    private Vector3 originPosition;

    private Transform parentTransform;
    private Sprite floorSprite;
    private Sprite wallSprite;
    private Sprite goalSprite;

    public Grid(int width, int height, float cellSize, Vector3 originPosition, Sprite floorSprite, Sprite wallSprite, Sprite goalSprite)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        this.floorSprite = floorSprite;
        this.wallSprite = wallSprite;
        this.goalSprite = goalSprite;

        gridArray = new int[width, height];
        cellVisuals = new GameObject[width, height];
        parentTransform = new GameObject("GridVisuals").transform;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 cellPos = GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f;

                GameObject cellGO = new GameObject($"Cell_{x}_{y}", typeof(SpriteRenderer));
                cellGO.transform.position = cellPos;
                // cellGO.transform.parent = parentTransform;
                // SpriteRenderer sr =  cellGO.GetComponent<SpriteRenderer>();
                // sr.sprite = floorSprite;
                // sr.transform.localPosition = new Vector3(0.8f, 0.8f, 1f);
                
                cellGO.transform.localScale = Vector3.one * (cellSize * 0.635f); // 크기 조절
                //cellGO.transform.parent = parentTransform;
                cellVisuals[x, y] = cellGO;

                SetValue(x, y, 0); // 초기값: floor
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            gridArray[x, y] = value;
            UpdateSprite(x, y);
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
            return gridArray[x, y];
        return 0;
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

    private void UpdateSprite(int x, int y)
    {
        SpriteRenderer sr = cellVisuals[x, y].GetComponent<SpriteRenderer>();
        switch (gridArray[x, y])
        {
            case 0:
                sr.sprite = floorSprite;
                sr.color = Color.white;
                break;
            case 2:
                sr.sprite = wallSprite;
                sr.color = Color.white;
                break;
            case 3:
                sr.sprite = goalSprite;
                sr.color = Color.white;
                break;
            default:
                sr.sprite = null;
                break;
        }
    }

    public void HighlightAvailableTiles(int x, int y)
    {
        ClearHighLights();
        Vector2Int[] directions = {
            Vector2Int.up, Vector2Int.down,
            Vector2Int.left, Vector2Int.right
        };

        foreach (var dir in directions)
        {
            int checkX = x - dir.x;
            int checkY = y - dir.y;
            if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
            {
                if (gridArray[checkX, checkY] != 2)
                {
                    SpriteRenderer sr = cellVisuals[checkX, checkY].GetComponent<SpriteRenderer>();
                    sr.color = Color.yellow;
                }
            }
        }
    }

    public void ClearHighLights()
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                UpdateSprite(x, y);
    }

    public float GetCellSize()
    {
        return cellSize;
    }
}
