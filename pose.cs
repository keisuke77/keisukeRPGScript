using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pose : MonoBehaviour
{float time;
public string posenames;
    // Start is called before the first frame update
    void Start()
    {
          }
public void posing(string posename){
keikei.playeranim.Play(posename);

time= keikei.playeranim.GetCurrentAnimatorStateInfo(0).length;
keikei.atractcamera(time,gameObject.transform,10);
while (time>0)
{   
    lookatcamera.lookcamera(gameObject);
        time-=Time.deltaTime; 
}
}public void posing(){
keikei.playeranim.Play(posenames);

time= keikei.playeranim.GetCurrentAnimatorStateInfo(0).length;
while (time>0)
{
    lookatcamera.lookcamera(gameObject);
        time-=Time.deltaTime; 
}
}
    // Update is called once per frame
    void Update()
    {
        
          }
}
