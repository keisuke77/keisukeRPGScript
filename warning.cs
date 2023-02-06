using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

using System.Linq;
using TMPro;
public class warning : MonoBehaviour
{
   public GameObject[] messages;
   public TextMeshProUGUI TextMeshProUGUI;
   public GameObject news;
   
public string newstext;
   public static warning instance;

public void warn(string text){
message(text,1);


}
void Awake()
{
  instance=this;
}
public GameObject obj;
public float Ypos;
public void message(string text,int number=0){

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

public void newsadd(string text){


newstext+=text;
news.GetComponentInChildren<Text>().text=newstext;



} 

}