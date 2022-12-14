using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{


public int damagepower=10;
 public float jumpeffectpower=10; 
public void damage(GameObject obj){
if (obj.GetComponent<hpcore>()!=null)
{
    obj.GetComponent<hpcore>().damage(damagepower);
}
}

public void jumpForce(GameObject obj){
// プレイヤーに風力与える
if (obj.GetComponent<UnityChanControlScriptWithRgidBody>()!=null)
{
obj.GetComponent<UnityChanControlScriptWithRgidBody>().AddForce(Vector3.up*jumpeffectpower);
}
}


public void jumpgive(GameObject obj ,float power,float effectduration=0){

 float Jumppower =  obj.GetComponent<UnityChanControlScriptWithRgidBody>().jumpPower;
  obj.GetComponent<UnityChanControlScriptWithRgidBody>().jumpPower=power;
  
  if (effectduration>0)
  {
  keikei.delaycall(()=>jumpgive(obj,Jumppower),effectduration);
  }
}

}
