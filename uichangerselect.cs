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
public Text text;
	
	[SerializeField]
    private GameObject[] UIlist;
void Awake()
{
    if (processors!=null)
    {
processors.AddAction(add);
        
    }if (unprocessors!=null)
    {      
unprocessors.AddAction(down);
    }
    
}
void Start()
{ 
BeforeParentUIGroup=UIlist[active].transform.parent.gameObject.transform.parent.gameObject;
UIchanger();
}
public void add(){
++active;
UIchanger();
}
public void down(){
active--;
UIchanger();
}

int oriactive;


void UIchanger(){

if (active==UIlist.Length)
		{
			active=0;
	
		}	
		if (active==-1)
		{
			active=UIlist.Length-1;
		
		}

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
if (parentobj!=BeforeParentUIGroup){
uichanger.activeonly(parentobj);
}
BeforeParentUIGroup=parentobj;

}
GameObject BeforeParentUIGroup;
void grandUichanger(){
foreach (var UIs in UIlist)
	{
		UIs.transform.parent.transform.parent.gameObject.SetActiveIfNotNull(false);
	}	
UIlist[active].transform.parent.transform.parent.gameObject.SetActiveIfNotNull(true);
}

public void decide()=> UIlist[active].transform.parent.gameObject.GetComponent<itemuse>().itemuses();


	// Update is called once per frame
	void Update () {

if (keiinput.Instance.add)
{
	add();
}
if (keiinput.Instance.decide)
{
	decide();
}
if (keiinput.Instance.down)
{
	down();
}
						
	}

  
}
}