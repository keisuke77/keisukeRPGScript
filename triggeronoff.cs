using System.Collections;
using System.Collections.Generic;
using UnityEngine;








public class triggeronoff : MonoBehaviour
{
    // Start is called before the first frame update
   public Collider obj;
   



public void off(Collider a){
a.enabled=false;
}

    public void trigerswich(bool a){
if (obj!=null)
{
        obj.enabled=a;
}

}


public void onobjtriger(GameObject aa){
aa.GetComponent<Collider>().enabled=true;
   
    
}
public void offobjtriger(GameObject aa){
aa.GetComponent<Collider>().enabled=false;
   
    
}
public void ontriger(){

    obj.enabled=true;
    
}public void offtriger(){

    obj.enabled=false;
    
}

}
