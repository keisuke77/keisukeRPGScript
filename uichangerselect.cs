using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< HEAD
namespace ItemSystem
{
  
public class uichangerselect : MonoBehaviour
{
//アイテムを選ぶ四角い奴
=======
public class uichangerselect : MonoBehaviour
{

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
 public int active=0;
public uichanger uichanger;
 public Button processors;
 public Button unprocessors;
<<<<<<< HEAD
public Text text;
	
	[SerializeField]
    private GameObject[] UIlist;
=======
 public KeyCode addkey;
 public KeyCode downkey;
public KeyCode decidekey;
public Text text;
itemcurrent itemcurrent;
	//　メインカメラ
	
	[SerializeField]
    private GameObject[] UIlist;
	keiinput keiinput;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
void Awake()
{
    if (processors!=null)
    {
<<<<<<< HEAD
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
=======
processors.onClick.AddListener(() => {add();});
        
    }if (unprocessors!=null)
    {
        
unprocessors.onClick.AddListener(() => {down();});
    }
    
   itemcurrent=gameObject.pclass().itemcurrent;
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


if (UIlist[active].transform.parent.gameObject.GetComponent<itemuse>().Itemkind)
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
{
	
text.text=UIlist[active].transform.parent.gameObject.GetComponent<itemuse>().Itemkind.GetItemName();

}else
{active=oriactive;

 keikei.uijump(UIlist[active].transform,50);
	return;
}
<<<<<<< HEAD

=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
oriactive=active;

		foreach (var UIs in UIlist)
	{
		UIs.SetActiveIfNotNull(false);
	}	
<<<<<<< HEAD
=======

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
UIlist[active].SetActiveIfNotNull(true);


var parentobj=UIlist[active].transform.parent.gameObject.transform.parent.gameObject;
<<<<<<< HEAD
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
=======
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
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
