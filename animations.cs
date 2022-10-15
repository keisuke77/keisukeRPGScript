using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animation>();
    }
public void Play(string name){

    anim.Play(name);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
