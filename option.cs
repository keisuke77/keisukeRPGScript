using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class option : MonoBehaviour
{
    public bool ios=false;
    
   public void iostrue(){
        ios=true;
        PlayerPrefs.SetInt("ios",1);
    }
    
   public void iosfalse(){
        ios=false;
        PlayerPrefs.SetInt("ios",0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
