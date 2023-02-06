using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autobuild : MonoBehaviour
{
    public GameObject block;
    private float count=0;
 
    // Update is called once per frame
    void Update()
    {
       transform.Translate(0,0,1f);
count=count+10*Random.value;
if (count>30)
{
    Instantiate(block,transform.position,Quaternion.identity);
    count=0;
}
    }
}
