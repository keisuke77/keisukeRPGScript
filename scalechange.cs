using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalechange : MonoBehaviour
{
public GameObject[] objs;
    public float scale;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void scaleup(int i){
objs[i].scalechange(scale,speed);

}
public void scaledown(int i){
objs[i].scalechange(1/scale,speed);

}

    // Update is called once per frame
    void Update()
    {
        
    }
}
