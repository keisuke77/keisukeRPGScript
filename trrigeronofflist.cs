using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trrigeronofflist : MonoBehaviour
{
    // Start is called before the first frame update
   public Collider[] objs;
   public int[] num;
    
private void Start() {
    alloff();
}
public void alloff(){
for (var i = 0; i < objs.Length; i++)
{
    objs[i].enabled=false;

}
     
}
public void allon(){
for (var i = 0; i < objs.Length; i++)
{
    objs[i].enabled=true;

}
     
}

public void ontriger(){
foreach (var item in num)
{
     objs[item].enabled=true;

}
   
    
}
<<<<<<< HEAD

public List<Collider> GetTriger(){
   var a=new List<Collider>();
=======
public List<Collider> a;

public List<Collider> GetTriger(){
    a=new List<Collider>();
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    
foreach (var item in num)
{
   a.Add(objs[item]);

}
   return a;
    
}

public void offtriger(){
foreach (var item in num)
{
     objs[item].enabled=false;
}
   
}

public void triger(int num,bool switchs){

    objs[num].enabled=switchs;
}
   
}
