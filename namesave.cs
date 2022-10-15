using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class namesave : MonoBehaviour
{
    public static string names;
    // Start is called before the first frame update
    void Start()
    {
         
    }
public void savename(string name){
if (PlayerPrefs.GetInt(name)==0)
{ 
PlayerPrefs.SetInt(name, 0);
names=name;
}else
{warning.message("既にその名前は存在します");
   
}

}
public void savename(InputField i){
    savename(i.text);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
