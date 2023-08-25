using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class interactionlist : MonoBehaviour
{
public Button[] buttons;
public List<Button> buttonlist;
public int count;
public int childCount;
public GameObject panel;
 bool once=true;
 public static interactionlist Instance;
<<<<<<< HEAD
 
void Awake()
{
    Instance=this;
=======
 void Awake()
 {
    Instance=this;
      
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
 }
    // Start is called before the first frame update
    void Start()
    { 
       gameObject.pclass().interactionlist=this;
       
        childCount=panel.transform.childCount;
        buttons=new Button[20];
        for (var i = 0; i < childCount; i++)
    {
buttons[i]=panel.transform.GetChild(i).GetComponent<Button>();
buttons[i].gameObject.SetActive(false);
    }
        Setbutton();
    }

public int createinteraction(string text,System.Action action){
if (count<childCount)
{if (buttonlist.Contains(buttons[count]))
{
    count++;
}
    buttonlist.Add(buttons[count]);
buttons[count].gameObject.SetActive(true);
buttons[count].onClick.AddListener(() => {action();});
  
buttons[count].gameObject.transform.GetChild(0).GetComponent<Text>().text=text;
if (count==childCount-1)
{
      count++;
   Setbutton();
return childCount-1;
}else
{
    count++;
   Setbutton();
return count-1;
}
   
}
return count;
}

public void Setbutton(){

 if (buttonlist.Count==0)
    {count=0;
          panel.SetActive(false);
        once=false;
    }else if(!once)
    {
        once=true;
         panel.SetActive(true);
         if(panel.GetComponent<uimove>()==null){
panel.AddComponent(typeof(uimove));
         }
    }


    if (count==childCount)
    {
        count=0;
    }
}

public void Alldeleteinteraction(){
for (var i = 0; i < childCount; i++)
{
    deleteinteraction(i);
}
}


public void deleteinteraction(int num){

 buttonlist.Remove(buttons[num]);
buttons[num].gameObject.SetActive(false);
buttons[num].onClick.RemoveAllListeners();
buttons[num].gameObject.transform.GetChild(0).GetComponent<Text>().text="";
 Setbutton();
}
}
