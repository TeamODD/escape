using System;
using UnityEngine;
using CodeMonkey.Utils;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.Rendering;

public class Testing : MonoBehaviour
{
    private Grid grid;
    public GameObject ballObject;
    public Sprite floorSprite;
    public Sprite wallSprite;
    public Sprite goalSprite;
    
    private Vector2Int ballPosition;
    private bool isSelectingMove = false;
    private int currentPatternIndex = 0;
    
    private Vector2Int startBallPosition = new Vector2Int(0, 0);
    private int[][,] patterns;
    //private BallMover ballMover;
    private bool isMoving = false;
    private BallMover ballMover;

    public GameObject redObejct;
    public GameObject blueObejct;
    public GameObject purpleObject;
    private int puzzleState = 0;
    public void Start()
    {
        grid = new Grid(4,4,1.5f, new Vector3(-3,-3),floorSprite,wallSprite,goalSprite);//위치 셀크기 위치 정하셈
        patterns = new int[][,]
        {
            new int[,] {
                {0, 0, 2, 0},
                {0, 0, 2, 0},
                {2, 2, 2, 2},
                {0, 0, 2, 3}
            },
            new int[,] {
                {0, 2, 2, 2},
                {2, 0, 0, 2},
                {2, 0, 0, 2},
                {2, 2, 2, 3}
            },
            new int[,] {
                {0, 0, 2, 0},
                {0, 0, 2, 2},
                {2, 2, 0, 0},
                {0, 2, 0, 3}
            }
        };
        ApplyPattern(0);
        MoveBallToPosition(startBallPosition);
        ballMover = ballObject.GetComponent<BallMover>();
        redObejct.SetActive(true);
        blueObejct.SetActive(false);
        purpleObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = UtilsClass.GetMouseWorldPosition();
            int x, y;
            grid.GetXY(mouseWorldPos, out x, out y);

            if (!isSelectingMove)
            {
                //공을 클릭했는지 확인
                if (x == ballPosition.x && y == ballPosition.y)
                {
                    grid.HighlightAvailableTiles(ballPosition.x, ballPosition.y);
                    isSelectingMove = true;
                }
            }
            else
            {
                // 이동가능한 타일이면 공 이동
                if (IsAdjacent(ballPosition, new Vector2Int(x, y))&& grid.GetValue(x,y)!=2)
                {
                    MoveBallToPosition(new Vector2Int(x, y));
                    grid.ClearHighLights();
                    isSelectingMove = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentPatternIndex = (currentPatternIndex + 1) % patterns.Length;
            ApplyPattern(currentPatternIndex);
        }
    }

    private bool IsAdjacent(Vector2Int a, Vector2Int b)//두위치가 상하좌우 인전한지 확인
    {
        int dx = Mathf.Abs(a.x - b.x);
        int dy = Mathf.Abs(a.y - b.y);
        return (dx + dy == 1);
    }

    private void ApplyPattern(int index)
    {
        grid.ClearHighLights();
        isSelectingMove = false;
        int[,] pattern = patterns[index];

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                grid.SetValue(x, y, pattern[y, x]); // y,x 순서에 주의 (행렬)
            }
        }
        
        // 공이 벽 위에 있는지 확인
        if (pattern[ballPosition.y, ballPosition.x] == 2)
        {
            MoveBallToPosition(startBallPosition);
        }
        else
        {
            MoveBallToPosition(ballPosition);
        }
    }

    private void MoveBallToPosition(Vector2Int gridPos)
    {
        ballPosition = gridPos;
        Vector3 worldPos = grid.GetWorldPosition(gridPos.x, gridPos.y) + new Vector3(grid.GetCellSize(), grid.GetCellSize())*0.5f;
        worldPos.z = -5f;
        ballObject.transform.DOMove(worldPos,0.3f).SetEase(Ease.InOutSine).Play();
        if (grid.GetValue(gridPos.x, gridPos.y) == 3)
        {
            Debug.Log("골인입니다.");
        }
    }

    public void NextPattern()
    {
        currentPatternIndex = (currentPatternIndex + 1) % patterns.Length;
        ApplyPattern(currentPatternIndex);
        puzzleState = (puzzleState + 1) % 3;
        switch (puzzleState)
        {
            case 0:
                redObejct.SetActive(true);
                blueObejct.SetActive(false);
                purpleObject.SetActive(false);
                break;
            case 1:
                redObejct.SetActive(false);
                blueObejct.SetActive(true);
                purpleObject.SetActive(false);
                break;
            case 2:
                redObejct.SetActive(false);
                blueObejct.SetActive(false);
                purpleObject.SetActive(true);
                break;
        }
    }
}
