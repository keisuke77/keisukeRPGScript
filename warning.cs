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
   
public static void message(string text){
message(text,0);


}
public static void warn(string text){
message(text,1);


}
public static GameObject obj;
public static float Ypos;
public static void message(string text,int number){

if (obj)
{
  Ypos+=100;
}else
{
  Ypos=0;
}
  obj= Instantiate(messages[number],messages[number].transform.position+new Vector3(0,Ypos,0),Quaternion.identity);

  
obj.GetComponentsInChildren<TextMeshPro>().ToList().ForEach(n=>n.SetText(text));




if (obj.GetComponentInChildren<Text>()!=null)
{
  
obj.GetComponentInChildren<Text>().text=text;

}else if(obj.GetComponentInChildren<TextMeshProUGUI>()!=null)
{


  

}
Destroy(obj,4);

} 

public static void newsadd(string text){


newstext+=text;
news.GetComponentInChildren<Text>().text=newstext;



} 

}