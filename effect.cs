using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    private float Jumppower;

  
public void jumpgive(GameObject obj ,float power,float effectduration){

  Jumppower =  obj.GetComponent<UnityChanControlScriptWithRgidBody>().jumpPower;
  obj.GetComponent<UnityChanControlScriptWithRgidBody>().jumpPower=power;
  
   StartCoroutine(stopeffect(obj,effectduration));
}

IEnumerator stopeffect(GameObject obj ,float delay) {  
     Debug.Log("deb");
     yield return new WaitForSeconds(delay);
     Debug.Log("defyhb");
     obj.GetComponent<UnityChanControlScriptWithRgidBody>().jumpPower=Jumppower;

}
    // Update is called once per frame
    void Update()
    {
        
    }
}
