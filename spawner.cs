using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

    //生成するゲームオブジェクト
    public KeyCode key;
    public GameObject target;

public void spawn(GameObject obj){

Instantiate (target, transform.position+transform.forward*1+transform.up*6, transform.rotation);
            transform.SetParent(target.transform);
      
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
