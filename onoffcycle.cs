using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onoffcycle : MonoBehaviour
{
    
   public float time=100;
   public static bool reded=false;
   public bool onoff;
   public bool onoffpulse;
   public static bool staticonoffpulse;
    // Start is called before the first frame update
    void Start()
    {
        
    
StartCoroutine("on");
    }

IEnumerator on() {  
onoffpulse=true;
staticonoffpulse=true;
    onoff=true;
     reded=true;
     yield return new WaitForSeconds(time);
StartCoroutine("off");
}
IEnumerator off() {  
    onoff=false;
     reded=false;
     yield return new WaitForSeconds(time);
onoffpulse=false;staticonoffpulse=false;

 yield return new WaitForSeconds(0.1f);
StartCoroutine("on");
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
