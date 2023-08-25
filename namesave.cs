using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class namesave : MonoBehaviour
{
    public static string names;
<<<<<<< HEAD
  
=======
    // Start is called before the first frame update
    void Start()
    {
         
    }
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
public void savename(string name){
if (PlayerPrefs.GetInt(name)==0)
{ 
PlayerPrefs.SetInt(name, 0);
names=name;
}else
<<<<<<< HEAD
{warning.instance?.message("既にその名前は存在します");
=======
{warning.message("既にその名前は存在します");
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
   
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
