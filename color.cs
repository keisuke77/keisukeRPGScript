using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
   
   public GameObject gameObj = null;
 private string namee;
    public GameObject text;
     public GameObject unitycha;
    private string die = "は死にました";

 
     

    void Start()
    {  text = GameObject.Find("MessageUI");
        namee = gameObj.name;
        StartCoroutine("ChangeColor");
      unitycha = GameObject.Find("unitychan");
    }
void OnCollisionEnter(Collision col){
     
     if(col.gameObject.name == namee){
     string mes = col.gameObject.name;
        
        
        
            }
            if (col.gameObject.tag == "MoveStage") {
        transform.SetParent(col.transform);
    }
}


 
void OnCollisionExit(Collision col) {
    if (col.gameObject.tag == "MoveStage") {
        transform.SetParent(null);
    }
}

void Update(){
Rigidbody rb = GetComponent<Rigidbody>();
rb.velocity = new Vector3(3f, 0, 0);
}    
IEnumerator ChangeColor()
    {
        //赤色にする
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        //3秒停止
        yield return new WaitForSeconds(3);

        //青色にする
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

}