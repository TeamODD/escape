using System;
using UnityEngine;
using CodeMonkey.Utils;
using System.Collections.Generic;
using DG.Tweening;
using Mono.Cecil.Cil;
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
    public RealityBoxScript RealityBoxScript;
    private Vector2Int ballPosition;
    private bool isSelectingMove = false;
    public AudioClip moveSound;
    public AudioClip goalSource;
    
    private Vector2Int startBallPosition = new Vector2Int(0, 0);
    private int[][,] patterns;
    //private BallMover ballMover;
    private bool isMoving = true;
    private BallMover ballMover;

    public GameObject redObejct;
    public GameObject blueObejct;
    public GameObject purpleObject;
    public int puzzleState = 0;
    public int currentPatternIndex = 0;
    public void Start()
    {
        grid = new Grid(4,4,1.5f, new Vector3(-3,-1.8f),floorSprite,wallSprite,goalSprite);//위치 셀크기 위치 정하셈
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

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     currentPatternIndex = (currentPatternIndex + 1) % patterns.Length;
        //     ApplyPattern(currentPatternIndex);
        // }
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
        
        //bool isInsideGrid = ballPosition.x >= 0 && ballPosition.x < 4 && ballPosition.y >= 0 && ballPosition.y < 4;
        MoveBallToPosition(ballPosition);
    }

    private void MoveBallToPosition(Vector2Int gridPos)
    {
        if (!grid.IsValidPosition(gridPos.x, gridPos.y))
        {
            return;
        }
        ballPosition = gridPos;
        Vector3 worldPos = grid.GetWorldPosition(gridPos.x, gridPos.y) + new Vector3(grid.GetCellSize(), grid.GetCellSize())*0.5f;
        worldPos.z = -5f;
        ballObject.transform.DOMove(worldPos,0.3f).SetEase(Ease.InOutSine).Play();
        if (isMoving)//스위치가 꺼져있으면
        {
            SoundControllerScript.Instance.StartEffectBgm(moveSound);
        }
        if (grid.GetValue(gridPos.x, gridPos.y) == 3)//막야 도착했다면
        {
            RealityBoxScript.BoxSolve();
            SoundControllerScript.Instance.StartEffectBgm(goalSource);
        }
    }

    public void NextPattern()
    {
        currentPatternIndex = (currentPatternIndex + 1) % patterns.Length;
        puzzleState = puzzleState% 3;
        ApplyPattern(puzzleState);
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

    public void SwitchGridStatus(bool input)
    {
        if (grid == null) return;
        
        if (!input)
        {
            isMoving = false;
            grid.HideGridVisuals();
        }
        else {
            isMoving = true;
            if (patterns[currentPatternIndex][ballPosition.y, ballPosition.x] == 2)
            {
                
                MoveBallToPosition(startBallPosition);
            }
            grid.ShowGridVisuals();
        }
    }
}
