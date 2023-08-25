using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

    //生成するゲームオブジェクト
    public KeyCode key;
    public GameObject target;
<<<<<<< HEAD
public float forwardcontroll,upwardcontroll;
public void spawn(GameObject obj){

Instantiate (obj, transform.position+transform.forward*forwardcontroll+transform.up*upwardcontroll, transform.rotation);
           
=======

public void spawn(GameObject obj){

Instantiate (target, transform.position+transform.forward*1+transform.up*6, transform.rotation);
            transform.SetParent(target.transform);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
      
}

public void spawn(){

  Instantiate (target, transform.position+transform.forward*1+transform.up*6, transform.rotation);
            transform.SetParent(target.transform);
      
}
    void Update(){
        //スペースを押したら
        if (key!=null&&Input.GetKeyDown (key)) {
          spawn(); 
         //Instantiate( 生成するオブジェクト,  場所, 回転 );  回転はそのままなら↓
            }
    }
}
