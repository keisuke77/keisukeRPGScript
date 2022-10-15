using System.Collections.Generic;
using UnityEngine;
 
public class jump : MonoBehaviour
{
    private Rigidbody rb;//  Rigidbodyを使うための変数
    public bool Grounded;//  地面に着地しているか判定する変数
    public float Jumppower=1;//  ジャンプ力
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//  rbにRigidbodyの値を代入する
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Grounded == true)//  もし、Groundedがtrueなら、
        {
            if (Input.GetKeyDown(KeyCode.Space))//  もし、スペースキーがおされたなら、  
            {
                Grounded = false;//  Groundedをfalseにする
                rb.AddForce(Vector3.up * Jumppower);//  上にJumpPower分力をかける
            }
        }
    }
 public void jumpexcute(){
     if (Grounded == true)//  もし、Groundedがtrueなら、
        {
 Grounded = false;//  Groundedをfalseにする
                rb.AddForce(Vector3.up * Jumppower);
        }
 }
    void OnCollisionEnter(Collision other)//  地面に触れた時の処理
    {
        if (other.gameObject.tag == "Ground"||other.gameObject.tag == "block")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            Grounded = true;//  Groundedをtrueにする
        }
    }
}