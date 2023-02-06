using UnityEngine;

public class humamoidAnim : MonoBehaviour
{
    bool inJumping;
    SimpleAnimation simpleAnimation;
    void Start()
    {
        simpleAnimation=GetComponent<SimpleAnimation>();
    }
    void Update()
    {
        
    
//前後方向キーを押したとき
if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow))
{
    //ジャンプ中のとき
    if (inJumping)
    {
        //ジャンプアニメーションを再生
        simpleAnimation.CrossFade("Jump", 0.1f);
    }
    //ダッシュキー押下時
    else if (Input.GetKey(KeyCode.LeftShift))
        //ダッシュアニメーションを再生
        simpleAnimation.CrossFade("Sprint", 0.1f);
    else
    {
        //ジャンプ中
        if (inJumping)
            //ジャンプアニメーションを再生
            simpleAnimation.CrossFade("Jump", 0.1f);
        else
            //移動アニメーションを再生
            simpleAnimation.CrossFade("Run", 0.1f);
    }
 
}
//スペースキー押下時
else if (Input.GetKey(KeyCode.Space))
{
    //ジャンプアニメーションを再生
    simpleAnimation.CrossFade("Jump", 0.1f);
    inJumping = true;
}
else//それ以外
{
    if (inJumping) { }//ジャンプ中はそのまま
    else//それ以外
    {
        //デフォルトアニメーションを再生
        simpleAnimation.Play("Default");
    }
}
    }
}