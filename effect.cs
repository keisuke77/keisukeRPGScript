using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{


    
public DamageInfo damageInfo;
 public float jumpeffectpower=10; 
public void damage(GameObject obj){obj.Damage(damageInfo,false);
}

public void jumpForce(GameObject obj){
// プレイヤーに風力与える

obj.PlayerAddForce(Vector3.up*jumpeffectpower);

}


public void jumpgive(GameObject obj ,float power,float effectduration=0){

 float Jumppower =  obj.pclass().playerMovePram.jumpPower;
  obj.pclass().playerMovePram.jumpPower=power;
  
  if (effectduration>0)
  {
  keikei.delaycall(()=>jumpgive(obj,Jumppower),effectduration);
  }
}

}
