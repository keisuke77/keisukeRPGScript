using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
<<<<<<< HEAD
using UnityEditor;

using System.Linq;
using TMPro;
public class warning 
{
   public GameObject[] messages;
   public TextMeshProUGUI TextMeshProUGUI;
   public GameObject news;
   
public string newstext;
   public static warning instance;


public void warn(string text){
=======

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
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
message(text,1);


}
<<<<<<< HEAD
void SetUp()
{
  instance=this;
  messages=Resources.LoadAll("Message", typeof(GameObject))as GameObject[];

}



public GameObject obj;
public float Ypos;
public void message(string text,int number=0){

if (obj==null)
{
  obj= keikei.instantiate(messages[number],new Vector3(0,Ypos,0),Quaternion.identity);

}
 
  
if (obj.GetComponentInChildren<Text>()!=null)
{
  
obj.GetComponentInChildren<Text>().text+="\n"+text;

}else if(obj.GetComponentInChildren<TextMeshProUGUI>()!=null)
{  
obj.GetComponentsInChildren<TextMeshPro>().ToList().ForEach(n=>n.text+="\n"+text);
}






keikei.destroy(obj,4);

} 

public void newsadd(string text){
=======
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
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae


newstext+=text;
news.GetComponentInChildren<Text>().text=newstext;



} 

}