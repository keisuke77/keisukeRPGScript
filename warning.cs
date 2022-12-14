using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

using System.Linq;
using TMPro;
public class warning : MonoBehaviour
{
   public static GameObject[] messages;
   public TextMeshProUGUI TextMeshProUGUI;
   public static GameObject news;
   
public static string newstext;
   

public static void warn(string text){
message(text,1);


}
public static GameObject obj;
public static float Ypos;
public static void message(string text,int number=0){

if (obj==null)
{
  obj= Instantiate(messages[number],new Vector3(0,Ypos,0),Quaternion.identity);

}
 
  
if (obj.GetComponentInChildren<Text>()!=null)
{
  
obj.GetComponentInChildren<Text>().text+="\n"+text;

}else if(obj.GetComponentInChildren<TextMeshProUGUI>()!=null)
{  
obj.GetComponentsInChildren<TextMeshPro>().ToList().ForEach(n=>n.text+="\n"+text);
}






Destroy(obj,4);

} 

public static void newsadd(string text){


newstext+=text;
news.GetComponentInChildren<Text>().text=newstext;



} 

}