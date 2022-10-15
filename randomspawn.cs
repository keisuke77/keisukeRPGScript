using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspawn : MonoBehaviour
{
    public GameObject spawnobj;
    public GameObject spawnobj2;
    public float often=3;
    float time;
    public float looptime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    GameObject randomobj(){
        float random=Random.value;
if (random>0.5f)
{
    return spawnobj;
}else{
return spawnobj2;
}

    }

void spawn(){
Instantiate(randomobj(),transform.position+transform.forward ,Quaternion.identity);


}
void Update()
{
    time+=Time.deltaTime*often;
    if (time>looptime)
    {
        spawn();
        time=0;
    }
}


float random(){

   return Random.value*often;
}
    // Update is called once per frame
   
}
