using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uichanger : MonoBehaviour
{

 public int active=0;

 public Button processors;
 public Button unprocessors;
 public KeyCode addkey;
 public KeyCode downkey;

	//　メインカメラ
	
	[SerializeField]
    private GameObject[] UIlist;
	



int i;
public void activeonly(GameObject obj){
	
	foreach (var item in UIlist)
	{if (obj==item)
		{
			set(i);
		}i++;
		
	}
i=0;
}
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
{
	UIchanger(); 

}
public void add(){
++active;
UIchanger();
}


public void set(int num){
active=num;
UIchanger();
}
public void down(){
active--;
UIchanger();
}
public void changeonly(){
UIchanger();


}

void UIchanger(){

	foreach (var UIs in UIlist)
	{
		UIs.SetActiveIfNotNull(false);
	}	
UIlist[active].SetActiveIfNotNull(true);
}


	// Update is called once per frame
	void Update () {

if (Input.GetKeyDown(addkey))
{
	add();
}
if (Input.GetKeyDown(downkey))
{
	down();
}

		if (active==UIlist.Length)
		{
			active=0;
	UIchanger();
		}	if (active==-1)
		{
			active=UIlist.Length-1;
		UIchanger();
		}
	
						
	}


  
}
