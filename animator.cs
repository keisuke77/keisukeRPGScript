using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator : MonoBehaviour
{Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }
public void SetBoolTrue(string name){

anim.SetBool(name,true);

}
    
public void SetBoolfalse(string name){

anim.SetBool(name,false);

}
    // Update is called once per frame
    void Update()
    {
        
    }
}
