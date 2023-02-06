using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemSystem
{
  
public class uichangerselect : MonoBehaviour
{
//アイテムを選ぶ四角い奴
 public int active=0;
public uichanger uichanger;
 public Button processors;
 public Button unprocessors;
 public KeyCode addkey;
 public KeyCode downkey;
public KeyCode decidekey;
public Text text;
	//　メインカメラ
	
	[SerializeField]
    private GameObject[] UIlist;
	keiinput keiinput;
void Awake()
{
    if (processors!=null)
    {
processors.onClick.AddListener(() => {add();});
        
    }if (unprocessors!=null)
    {
        
unprocessors.onClick.AddListener(() => {down();});
    }
    
}
void Start()
{ keiinput=gameObject.pclass().keiinput;
  
temp=UIlist[active].transform.parent.gameObject.transform.parent.gameObject;
 setup();
}
public void add(){
++active;setup();
}
public void down(){
active--;setup();
}
public void changeonly(){
UIchanger();


}
int oriactive;
void UIchanger(){

//アイテムが変更されたときテキストの更新
if (UIlist[active].transform.parent.gameObject.GetComponent<itemuse>().Itemkind!=null)
{
	
text.text=UIlist[active].transform.parent.gameObject.GetComponent<itemuse>().Itemkind.GetItemName();

}else
{active=oriactive;

 keikei.uijump(UIlist[active].transform,50);
	return;
}
oriactive=active;

		foreach (var UIs in UIlist)
	{
		UIs.SetActiveIfNotNull(false);
	}	
UIlist[active].SetActiveIfNotNull(true);


var parentobj=UIlist[active].transform.parent.gameObject.transform.parent.gameObject;
if (parentobj!=temp){
uichanger.activeonly(parentobj);
}temp=parentobj;
}
GameObject temp;
void grandUichanger(){

    
		foreach (var UIs in UIlist)
	{
		
		UIs.transform.parent.transform.parent.gameObject.SetActiveIfNotNull(false);
	}	

UIlist[active].transform.parent.transform.parent.gameObject.SetActiveIfNotNull(true);
}
public void decide(){


    UIlist[active].transform.parent.gameObject.GetComponent<itemuse>().itemuses();
}
	// Update is called once per frame
	void Update () {

if (keiinput.add)
{
	add();
}
if (keiinput.decide)
{
	decide();
}
if (keiinput.down)
{
	down();
}

						
	}

public void setup(){
	if (active==UIlist.Length)
		{
			active=0;
	
		}	if (active==-1)
		{
			active=UIlist.Length-1;
		
		}
		UIchanger();
	

}
  
}
}