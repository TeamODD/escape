using System;
using UnityEngine;
using CodeMonkey.Utils;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class Testing : MonoBehaviour
{
    private Grid grid;
    private Vector2Int ballPosition;
    private bool isSelectingMove = false;
    private int currentPatternIndex = 0;
    
    private Vector2Int startBallPosition = new Vector2Int(0, 0);
    
    private int[][,] patterns;
    public void Start()
    {
        grid = new Grid(4,4,10f, new Vector3(-10,-10));//위치 셀크기 위치 정하셈
        patterns = new int[][,]
        {
            new int[,] {
                {0, 0, 2, 0},
                {0, 0, 2, 0},
                {2, 2, 2, 0},
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
                    //공위치 초기화
                    grid.SetValue(ballPosition.x, ballPosition.y,0);// 이전거 지우고
                    ballPosition = new Vector2Int(x, y);
                    grid.SetValue(ballPosition.x, ballPosition.y,1);// 새위치 표시
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
            ballPosition = startBallPosition;
        }

        // 공 위치 덮어쓰기
        grid.SetValue(ballPosition.x, ballPosition.y, 1);
    }
    
}
