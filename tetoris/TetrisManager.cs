using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TetrisManager : MonoBehaviour
{
    public GameObject[] tetrominoPrefabs;
    public GameObject lineEffect;
    public Material ghostMat;
    public Transform[,] grid = new Transform[10, 20];
    public Text scoreText;
    private GameObject currentTetromino;
    private int score = 0;
    public Text gameOverText;
    public Text levelText;
    private int level = 1;
    private bool isGameOver = false;
    public Text holdText;
    private GameObject heldTetromino;
    private bool canHold = true;
private GameObject ghostTetromino;
public Color ghostTetrominoColor;
    void Start()
    {
        SpawnTetromino();
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            HoldTetromino();
        }

        scoreText.text = "Score: " + score;
        levelText.text = "Level: " + level;

        if (score >= level * 500)
        {
            level++;
            currentTetromino.GetComponent<Tetromino>().fallSpeed -= 0.1f;
        }
        UpdateGhostTetromino();
    }

    private void HoldTetromino()
    {
        if (!canHold) return;

        if (heldTetromino == null)
        {
            heldTetromino = tetrominoPrefabs[randomIndex];
            Destroy(currentTetromino);
            SpawnTetromino();
        }
        else
        {
            GameObject temp = heldTetromino;
            heldTetromino = tetrominoPrefabs[randomIndex];
            Destroy(currentTetromino);
            currentTetromino = Instantiate(temp, new Vector2(5, 19), Quaternion.identity);
        }

        holdText.text = "Hold: " + heldTetromino.name.Replace("(Clone)", "");
        canHold = false;
    }

    public void RestartGame()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }int randomIndex ;
    public void SpawnTetromino()
    {
        randomIndex = UnityEngine.Random.Range(0, tetrominoPrefabs.Length);
        currentTetromino = Instantiate(tetrominoPrefabs[randomIndex], new Vector2(5, 17), Quaternion.identity);
        currentTetromino.GetComponent<Tetromino>().StartMoving();
        
currentTetromino.ChangeChildColor(ColorExtensions.GetRandomColor());
        
    ghostTetromino = Instantiate(tetrominoPrefabs[randomIndex], new Vector2(5, 17), Quaternion.identity);
ghostTetromino.transform.ChangeChildMaterials(ghostMat);
ghostTetromino.ChangeChildColor(ghostTetrominoColor);


    OnTetrominoSpawned?.Invoke(currentTetromino.GetComponent<Tetromino>());
    }

    public bool IsValidMove(Vector3 position, Transform tetrominoTransform)
    {
        foreach (Transform child in tetrominoTransform)
        {
            int x = Mathf.RoundToInt(child.position.x+position.x);
            int y = Mathf.RoundToInt(child.position.y+position.y);

            if (x < 0 || x >= 10 || y < 0 || y >= 20)
            {
                Debug.Log("うごけないよ");
                return false;

            }

            if (grid[x, y] != null)
            { Debug.Log("うごけないよ");
                return false;
            }
        }
        Debug.Log("うごいた");
        return true;
    }
    
    private void UpdateGhostTetromino()
{
    Vector3 currentPosition = currentTetromino.transform.position;
    ghostTetromino.transform.position = currentPosition;
    ghostTetromino.transform.rotation = currentTetromino.transform.rotation;

    while (IsValidMove(Vector3.down, ghostTetromino.transform))
    {
        ghostTetromino.transform.position += new Vector3(0, -1, 0);
    }
}

    public void UpdateGrid(Tetromino tetromino)
    {


 
        foreach (Transform child in tetromino.transform)
        {
            int x = Mathf.RoundToInt(child.position.x);
                        int y = Mathf.RoundToInt(child.position.y);
Debug.Log(new Vector2(x,y));
            if (y < grid.GetLength(1))
            {
                grid[x, y] = child;
                tetromino.StopMoving();
            }
        }

        CheckLines();

        if (IsGameOver())
        {
            isGameOver = true;
            gameOverText.gameObject.SetActive(true);
            return;
        }
Destroy(ghostTetromino);
        SpawnTetromino();
    }

    private void CheckLines()
    {
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            if (IsLineComplete(y))
            {
                ClearLine(y);
                MoveLinesDown(y);
                score += 100;
            }
        }
    }
public delegate void TetrominoSpawned(Tetromino spawnedTetromino);
public event TetrominoSpawned OnTetrominoSpawned;


    private bool IsLineComplete(int y)
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    private void ClearLine(int y)
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            Instantiate(lineEffect,grid[x, y].gameObject.transform.position,Quaternion.identity);
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    private bool IsGameOver()
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            if (grid[x, grid.GetLength(1) - 1] != null)
            {
                return true;
            }
        }
        return false;
    }

    private void MoveLinesDown(int clearedLineY)
    {
        for (int y = clearedLineY + 1; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].position += Vector3.down;
                }
            }
        }
    }
}
