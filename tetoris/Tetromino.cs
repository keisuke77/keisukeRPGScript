
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float fallSpeed = 1;
    private float fallTimer;
    private TetrisManager tetrisManager;
    private bool isMoving;

    void Start()
    {
        tetrisManager = FindObjectOfType<TetrisManager>();
    }

    void Update()
    {
    if (isMoving)
    {
        HandleMovement();
        HandleRotation();
    
        fallTimer += Time.deltaTime;
        if (fallTimer >= fallSpeed)
        {
            if (tetrisManager.IsValidMove( Vector3.down, transform))
            {
                transform.position += Vector3.down;
            }
            else
            {
                tetrisManager.UpdateGrid(this);
                isMoving = false;
            }
            fallTimer = 0;
        }
    }
    }

    void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (tetrisManager.IsValidMove(Vector3.left, transform))
            {
                transform.position += Vector3.left;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (tetrisManager.IsValidMove( Vector3.right, transform))
            {
                transform.position += Vector3.right;
            }
        }
       else if (Input.GetKeyDown(KeyCode.DownArrow))
    {
 fallTimer = fallSpeed;
      down=true;
    }
    if (Input.GetKeyUp(KeyCode.DownArrow)){
down=false;
    }
    if (down)
    {time+=Time.deltaTime;

        if (time>duration)
        {Skip();
            time=0;
        }
    }else
    {
        time=0;
    }
    }
   void Skip(){
  while(tetrisManager.IsValidMove( Vector3.down, transform))
            {
                transform.position += Vector3.down;
            }
          tetrisManager.UpdateGrid(this);
                isMoving = false;
           
    }
bool down;
 float duration=0.5f;
float time;
  void HandleRotation()
{
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
        transform.Rotate(new Vector3(0, 0, 90));
        if (!tetrisManager.IsValidMove(Vector3.zero, transform))
        {
            // 境界チェックを追加
            bool reverted = false;
            if (transform.position.x < 0)
            {
                transform.position += new Vector3(1, 0, 0);
            }
            else if (transform.position.x >= tetrisManager.grid.GetLength(0))
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else
            {
                reverted = true;
            }

            if (reverted || !tetrisManager.IsValidMove(Vector3.zero, transform))
            {
                transform.Rotate(new Vector3(0, 0, -90));
            }
        }
    }
}
    public void StartMoving()
    {
        isMoving = true;
    }  public void StopMoving()
    {
        isMoving = false;
    }
}