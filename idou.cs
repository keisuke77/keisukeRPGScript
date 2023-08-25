using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idou : MonoBehaviour
<<<<<<< HEAD
{
=======
 {

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    //重力等の変更ができるようにパブリック変数とする
    public float gravity;
    public float speed;
    public float jumpSpeed;
    public float rotateSpeed;

    //外部から値が変わらないようにPrivateで定義
    private CharacterController characterController;
    private Animator animator;
    private Vector3 moveDirection = Vector3.zero;
<<<<<<< HEAD
    private bool okkey;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //rayを使用した接地判定
        if (CheckGrounded() == true)
        {
            //前進処理
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection.z = speed;
            }
            else
            {
=======
private bool okkey;
	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
        
        //rayを使用した接地判定
        if(CheckGrounded() == true){

            //前進処理
            if(Input.GetKey(KeyCode.UpArrow)){
                moveDirection.z = speed;
            }
            else{
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
                moveDirection.z = 0;
            }

            //方向転換
            //方向キーのどちらも押されている時
<<<<<<< HEAD
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                //向きを変えない
            }
            //左方向キーが押されている時
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, rotateSpeed * -1, 0);
            }
            //右方向キーが押されている時
            else if (Input.GetKey(KeyCode.RightArrow))
            {
=======
            if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)){
                //向きを変えない
            }
            //左方向キーが押されている時
            else if(Input.GetKey(KeyCode.LeftArrow)){
                transform.Rotate(0 ,rotateSpeed * -1 ,0);
            }
            //右方向キーが押されている時
            else if(Input.GetKey(KeyCode.RightArrow)){
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
                transform.Rotate(0, rotateSpeed, 0);
            }

            //jump
<<<<<<< HEAD
            if (Input.GetKeyDown(KeyCode.Space))
            {
=======
            if(Input.GetKeyDown(KeyCode.Space)){
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
                moveDirection.y = jumpSpeed;
            }

            //重力を発生させる
            moveDirection.y -= gravity * Time.deltaTime;

            //移動の実行
            Vector3 globalDirection = transform.TransformDirection(moveDirection);
            characterController.Move(globalDirection * Time.deltaTime);

            //速度が０以上の時、Runを実行する
<<<<<<< HEAD
            animator.SetBool("Run", moveDirection.z > 0.0f);
        }
    }

    //rayを使用した接地判定メソッド
    public bool CheckGrounded()
    {
        var controller = GetComponent<CharacterController>();
        //CharacterControlle.IsGroundedがtrueならRaycastを使わずに判定終了
        if (controller.isGrounded)
        {
            return true;
        }
        //初期位置と向き
        var ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);

=======
            animator.SetBool("Run",moveDirection.z > 0.0f);
        }
	}

    //rayを使用した接地判定メソッド
    public bool CheckGrounded(){
var controller = GetComponent<CharacterController>();
    //CharacterControlle.IsGroundedがtrueならRaycastを使わずに判定終了
    if (controller.isGrounded) { return true; }
        //初期位置と向き
        var ray = new Ray(transform.position + Vector3.up * 0.1f , Vector3.down);
 
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
        //rayの探索範囲
        var tolerance = 0.3f;

        //rayのHit判定
        //第一引数：飛ばすRay
        //第二引数：Rayの最大距離
<<<<<<< HEAD
        return Physics.Raycast(ray, tolerance);
    }
}
=======
        return Physics.Raycast(ray,tolerance);
    }

}
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
