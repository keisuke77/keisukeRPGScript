using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class namesave : MonoBehaviour
{
    public static string names;
  
public void savename(string name){
if (PlayerPrefs.GetInt(name)==0)
{ 
PlayerPrefs.SetInt(name, 0);
names=name;
}else
{warning.instance?.message("既にその名前は存在します");
   
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
