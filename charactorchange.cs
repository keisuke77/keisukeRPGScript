using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[System.Serializable]
public class character{
	public RuntimeAnimatorController anicon;
public string name;
public int power=3;
public GameObject bone;
public GameObject mesh;
public Avatar avatar;
public GameObject righthand;
public GameObject lefthand;
public GameObject rightfoot;
public GameObject leftfoot;
public transformdata weaponstransform;
public void Set(charactorchange charactorchange,character[] characters){

foreach (var characterss in characters)
	{
      characterss.bone.SetActive(false);
	characterss.mesh.SetActive(false);
      	}
			if (anicon!=null)
			{
				 charactorchange.anim.runtimeAnimatorController=anicon;
			}
	bone.SetActive(true);
	mesh.SetActive(true);
    charactorchange.anim.avatar=avatar;
    charactorchange.weapons.transform.parent=righthand.transform;
    keikei.transformenter(charactorchange.weapons.transform,weaponstransform);
}
   }

public enum charactername{
mario,miku,man,unitychan
}

public interface GetBodyPart
{
     GameObject GetRightHand();
	 GameObject GetLeftHand();
	GameObject GetLeftFoot();
	 GameObject GetRightFoot();
	
}

public class charactorchange : MonoBehaviour,GetBodyPart
{public GameObject footsmoke;
	public Dropdown DropDown;
data data;
   public GameObject weapons;
   public delegate void hides();
public Animator anim;
   public character[] characters;
    // Start is called before the first frame update
public Text text;
 public int active=0;
	//　メインカメラ
	public GameObject GetRightHand(){
		return characters[active].righthand;
	}public GameObject GetLeftHand(){
		return characters[active].lefthand;
	}public GameObject GetLeftFoot(){
		return characters[active].leftfoot;
	}public GameObject GetRightFoot(){
		return characters[active].rightfoot;
	}
/// <summary>
/// This function is called when the behaviour becomes disabled or inactive.
/// </summary>
void OnDisable()
{
	this.enabled=true;
}
	
public List<string> m_DropOptions;
			
	void Awake()
	{
		tempactive=-1;
		
		}
void Start()
{ data=gameObject.acessdata();
		active=data.charactor;
	
		if (anim==null)
{
    anim=GetComponent<Animator>();
}
        //DropDownの要素にリストを追加
       	foreach (character item in characters)
	{
	  item.rightfoot.collset(item.power);
	item.righthand.collset(item.power);
    item.lefthand.collset(item.power);
	item.leftfoot.collset(item.power);
	


m_DropOptions.Add(item.name);
  
	}
	if (DropDown!=null)
	{
		DropDown.ClearOptions();
 DropDown.AddOptions(m_DropOptions);
		
	}

		 
}




public void collidespawnSet(GameObject obj){

var a =obj.AddComponentIfnull<collidespawn>();
a.obj=footsmoke;
}

public void characterhide(){

		foreach (var characterss in characters)
	{

characterss.mesh.SetActive(false);

	}
}

public void charactorchanger(int num){
characters[Mathf.Abs(num)].Set(this,characters);
if (text!=null)
{
text.text=characters[Mathf.Abs(num)].name;
}
data.charactor=Mathf.Abs(num);
}


string temptext;
int tempactive=-1;
int hairetucheck;
	// Update is called once per frame
	void LateUpdate() { 
		
if (active!=tempactive)
{
	tempactive=active;
	charactorchanger(active%(characters.Length));
}
	
    
    
if (temptext!=DropDown.captionText.text)
{
	hairetucheck=0;
	temptext=DropDown.captionText.text;
	
foreach (var item in characters)
{
	hairetucheck++;
	if (item.name==DropDown.captionText.text)
{
active=	hairetucheck;
}
}

}
    	
		
		
	
		
						
	}
public void charactoradd(){
		active++;		
    }

public void charactordown(){
		active--;		
    }

  
	public void charactorchanges(int nums){
		active=nums;
			
    }
}
