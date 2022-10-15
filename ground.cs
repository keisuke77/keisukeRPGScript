using UnityEngine;
using UnityEngine.Events;

public class ground : MonoBehaviour {

    public bool Grounded=false;
    public bool nojump=false;
    public int count=0;
    public int checkspeed=30;
    public bool triger=true;
    public bool col =false;
     
void Update()
{
    count++;
    if (count>checkspeed)
    {
        Grounded=false;
    }

    if (count>40)
    {
        nojump=false;
    }
}
    //接地した場合の処理
    void OnTriggerStay(Collider other)//  地面に触れた時の処理
    {
        if (triger)
        {
        Debug.Log("bhjbkjlmk");
        if (other.tag == "unGround")
        {
            return;
        }
        if (other.tag == "Ground"||other.gameObject.tag == "block"||other.tag == "Untagged")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            count=0;
             nojump=true;

            Grounded = true;//  Groundedをtrueにする
        }
        }
        
       
    }

void OnCollisionStay(Collision other)//  地面に触れた時の処理
    {
        if (col)
        {
        Debug.Log("bhjbkjlmk");
        if (other.gameObject.tag == "unGround")
        {
            return;
        }
        if (other.gameObject.tag == "Ground"||other.gameObject.tag == "block"||other.gameObject.tag == "Untagged")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            count=0;
             nojump=true;

            Grounded = true;//  Groundedをtrueにする
        }
        }
        
       
   
    }
}
