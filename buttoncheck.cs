using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttoncheck : MonoBehaviour
{
    public bool jump=false;
    // Start is called before the first frame update
   void Start()
    {
        
    }
public void on(){
     jump=true;
}
    // Update is called once per frame
    void Update()
    {
        if (jump)
        {
            jump=false;
        }
    }
}
