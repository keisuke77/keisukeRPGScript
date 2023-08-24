using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class AIPlayer : MonoBehaviour
{
    public TetrisManager tetrisManager;
    private Tetromino currentTetromino;

    void Start()
    {
        tetrisManager.OnTetrominoSpawned += HandleTetrominoSpawned;
    }

    private void HandleTetrominoSpawned(Tetromino spawnedTetromino)
    {
        currentTetromino = spawnedTetromino;
        StartCoroutine(MakeOptimalMove());
    }

private int EvaluateBoard()
{
    int holePenalty = CountHoles();
    int maxHeight = CalculateMaxHeight();
    int averageHeight = CalculateAverageHeight();
    int linesCleared = CountCompleteLines();
    int bumpiness = CalculateBumpiness();

     // 各要素の重み付けを調整して、最適なスコアを見つけます。
    int score = -holePenalty * 6 - maxHeight * 1 - averageHeight * 3 + linesCleared * 8 - bumpiness * 4;
     return score;
}
private int CountHoles()
{
    int holes = 0;

    for (int x = 0; x < grid.GetLength(0); x++)
    {
        bool blockFound = false;
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            if (grid[x, y] != null)
            {
                blockFound = true;
            }
            else if (blockFound)
            {
                holes++;
            }
        }
    }

    return holes;
}

private int CalculateMaxHeight()
{
    int maxHeight = 0;

    for (int x = 0; x < grid.GetLength(0); x++)
    {
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            if (grid[x, y] != null)
            {
                int height = grid.GetLength(1) - y;
                maxHeight = Mathf.Max(maxHeight, height);
                break;
            }
        }
    }

    return maxHeight;
}

private int CalculateAverageHeight()
{
    int totalHeight = 0;
    int columns = 0;

    for (int x = 0; x < grid.GetLength(0); x++)
    {
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            if (grid[x, y] != null)
            {
                totalHeight += grid.GetLength(1) - y;
                columns++;
                break;
            }
        }
    }

    return columns > 0 ? totalHeight / columns : 0;
}

private int CountCompleteLines()
{
    int completeLines = 0;

    for (int y = 0; y < grid.GetLength(1); y++)
    {
        bool isLineComplete = true;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            if (grid[x, y] == null)
            {
                isLineComplete = false;
                break;
            }
        }

        if (isLineComplete)
        {
            completeLines++;
        }
    }

    return completeLines;
}

private int CalculateBumpiness()
{
    int bumpiness = 0;

    for (int x = 0; x < grid.GetLength(0) - 1; x++)
    {
        int columnHeight1 = 0;
        int columnHeight2 = 0;

        for (int y = 0; y < grid.GetLength(1); y++)
        {
            if (grid[x, y] != null)
            {
                columnHeight1 = grid.GetLength(1) - y;
                break;
            }
        }

        for (int y = 0; y < grid.GetLength(1); y++)
        {
            if (grid[x + 1, y] != null)
            {
                columnHeight2 = grid.GetLength(1) - y;
                break;
            }
        }

        bumpiness += Mathf.Abs(columnHeight1 - columnHeight2);
    }

    return bumpiness;
}

    public Transform[,] grid = new Transform[10, 20];
  public void UpdateGrid(Tetromino tetromino)
    {


 
        foreach (Transform child in tetromino.transform)
        {
            int x = Mathf.RoundToInt(child.position.x);
                        int y = Mathf.RoundToInt(child.position.y);
            if (y < grid.GetLength(1))
            {
                grid[x, y] = child;
            }
        }
        }
    public void RemoveGrid(Tetromino tetromino)
    {


 
        foreach (Transform child in tetromino.transform)
        {
            int x = Mathf.RoundToInt(child.position.x);
                        int y = Mathf.RoundToInt(child.position.y);
            if (y < grid.GetLength(1))
            {
                grid[x, y] = null;
            }
        }
        }
  
    private IEnumerator MakeOptimalMove()
    {
      
    int bestScore = int.MinValue;
    Vector3 bestPosition = Vector3.zero;
    int bestRotation = 0;
grid=tetrisManager.grid;
currentTetromino.StopMoving();
    for (int rotation = 0; rotation < 4; rotation++)
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            Vector3 position = new Vector3(x, currentTetromino.transform.position.y, 0);
            currentTetromino.transform.position = position;
            currentTetromino.transform.Rotate(new Vector3(0, 0, 90 * rotation));

while (tetrisManager.IsValidMove(Vector3.down, currentTetromino.transform))
{
    currentTetromino.transform.position+=Vector3.down;
}
UpdateGrid(currentTetromino);
          
                int score = EvaluateBoard();
                RemoveGrid(currentTetromino);
Debug.Log(score);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestPosition = position;
                    bestRotation = rotation;
                }
            

            currentTetromino.transform.Rotate(new Vector3(0, 0, -90 * rotation));
        }
    }

    currentTetromino.transform.position = bestPosition;
    currentTetromino.transform.Rotate(new Vector3(0, 0, 90 * bestRotation));

    while (tetrisManager.IsValidMove(Vector3.down, currentTetromino.transform))
    {
        currentTetromino.transform.position += Vector3.down;
        yield return new WaitForSeconds(0.1f);
    }

    tetrisManager.UpdateGrid(currentTetromino);
    currentTetromino.GetComponent<Tetromino>().StartMoving();
}
}