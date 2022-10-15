using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class itemcurrent : MonoBehaviour
{public Itemkind Itemkind;
iteminventory playeriteminventory;
public UnityChanControlScriptWithRgidBody UnityChanControlScriptWithRgidBody;
public GameObject Player;

[SerializeField]
 Text text;
 public Animator anim;
 bool once1;
 Image image;
 data data;
 public movelift movelift;
 objectchange objchange;
 public bool changecamera;
  hp hp;
  mp mp;
  Itemkind noitem;
 
 public Text explain;
 public Text selectText;
 public Text numbertext;
 GameObject freeobj;
   Transform tran;
public static itemcurrent instance;
public Image resistanceimage;
public Image backresistanceimage;
itemmanage itemmanage;
public charges charges;
keiinput keiinput;
  
    void Awake()
    {
     	 gameObject.pclass().itemcurrent=this; 
           instance=this;
    }


    void Start()
    { keiinput=gameObject.pclass().keiinput;
    
      itemmanage=gameObject.pclass().itemmanage;
      
		  charges=new charges(gameObject);
	  
	 tran=gameObject.root().transform;
        noitem=keikei.noitem;
        data=gameObject.acessdata();  
 
        playeriteminventory=data.saveiteminventory;
    Player=gameObject.root();
        objchange= Player.GetComponent<objectchange>();
        UnityChanControlScriptWithRgidBody=Player.GetComponent<UnityChanControlScriptWithRgidBody>();
  image=GetComponent<Image>();

hp=Player.GetComponent<hp>();
itemmanage.imagecreate();  
 setitem(data.Itemkind);
    image.sprite=Itemkind?.GetIcon();
        
    mp=Player.GetComponent<mp>();
  
    }

  
public void returnitem(){ 
     itemmanage.additem(Itemkind,false);
     removeitem();
}

public void removeitem(){
        itemchange();
        Itemkind=noitem;
        GetComponent<Image>().sprite=Itemkind.GetIcon();
        resistanceimage.enabled=false;
        backresistanceimage.enabled=false;
}

public void itemchange(){
 objchange.objhide();
 UnityChanControlScriptWithRgidBody.defenceend();
}

public void numbertexts(){
if (Itemkind.GetKindOfItem().ToString()=="useWeapon"||Itemkind.GetKindOfItem().ToString()=="placeitem")
{
     keikei.itemnumtext(Itemkind,numbertext);
}else
{
    numbertext.text="";
}
}


public void itemused(){

if (Itemkind.GetKindOfItem().ToString()=="Weapon"){
removeitem();
}  
Itemkind.downnumber();
   
}


public void weapontriggerSet(){
gameObject.root().GetComponent<triggeronoff>().obj=objchange.Getobj().GetComponent<Collider>();  
}

public void setitem(Itemkind Itemkinds){
     itemchange();
     GetComponent<Image>().sprite=Itemkinds.GetIcon();
  if (Itemkind!=Itemkinds)
  { 
objchange.objhide();
  keikei.scalechange(GetComponent<RectTransform>());
  }
  if (playeriteminventory.additem(Itemkind,false))
  {
       itemmanage.imagecreate();
  }
    Itemkind=Itemkinds;

if (Itemkind.GetKindOfItem().ToString()=="Weapon"){
warning.message(Itemkind.GetItemName()+"を装備した");
Invoke("weapontriggerSet",1f);
resistanceimage.enabled=true;
backresistanceimage.enabled=true;
Player.EffspawnPlayer(Itemkind.weaponseteffect); 
}else
{
resistanceimage.enabled=false;
backresistanceimage.enabled=false;
}
}

public void informationtext(){
text.text=Itemkind.GetItemName()+"\n"+Itemkind.GetInformation();
}

public void removetext(){
text.text="";
}
   
  public void mahoueffect(){
     var w= Instantiate(Itemkind.Getmagiceffect(),Player.transform.position+Player.transform.forward*2,Player.transform.rotation);
          
                 w.transform.SetParent(Player.transform);
          
           itemused();
             }

  public void mahoueffectnotparent(){
     Instantiate(Itemkind.Getmagiceffect(),Player.transform.position+Player.transform.forward*2,Player.transform.rotation);
                       itemused();
             }

   public void itemdamage(int damage){
Itemkind.Resitance-=damage;
   }
  

    // Update is called once per frame
    void LateUpdate()
    {   
if (Itemkind==null)
{
   Itemkind=noitem;
}  
ItemFunction(); 
resistanceimage.fillAmount = (float)Itemkind.Resitance/Itemkind.oriResitance;
data.Itemkind=Itemkind;
numbertexts();

      
if (Itemkind.GetResistance()<=0&&Itemkind!=keikei.noitem)
{ 
     Itemkind.Resitance=Itemkind.oriResitance;
warning.message(Itemkind.GetItemName()+"が壊れた！");
     
     removeitem();
    
}

    
     if (Itemkind.Getnumber()==0&&Itemkind!=noitem)
	{
	
     removeitem();
          
     }

   
if (Itemkind.GetKindOfItem().ToString()=="placeitem"){


placeitem();
}

  
        
   
        
         }





 void ItemFunction(){


if (Itemkind.GetKindOfItem().ToString()!="Weapon")
{       
      UnityChanControlScriptWithRgidBody.freehandattack();
   
}
   
   
   
   if (Itemkind.GetItemName()=="プラスチック製の剣" )
   {
        objchange.changeint(2);
sword();
    }
    else if (Itemkind.GetItemName()=="ゴッドソード")
   {
        objchange.changeint(11);
sword();
    }

    else if (Itemkind.GetItemName()=="フレイムソード" )
   {
        objchange.changeint(9);
     
sword();
   }
  else if (Itemkind.GetItemName()=="魔法" )
   {
        if (keiinput.attack)
        {
           
           keikei.shake();
anim.Play("mahouanim",0);
        }
   }

else if (Itemkind.GetItemName()=="ハイパーキックブーツ" )
   {
        objchange.changeint(0);
if (keiinput.attack)
        {


             anim.SetTrigger("kick");
        }
  
   }else if (Itemkind.GetItemName()=="合金製ハンマー" )
   {
        objchange.changeint(5);
  attack("hammer");
   
itemthrow();
   }
 else if (Itemkind.GetItemName()=="たる爆弾" )
   {objchange.changeint(6);
    
itemthrow();
   
   }else if (Itemkind.GetItemName()=="鉄のピッケル" )
   {objchange.changeint(8);
    if (Input.GetKeyDown(KeyCode.Z))
        {

anim.SetBool("pickaxe",true);
   }
    
itemthrow();
    }else if (Itemkind.GetItemName()=="鉄の斧" )
   {objchange.changeint(12);
    if (keiinput.attack)
        {

anim.SetBool("axe",true);
   }
    
itemthrow();
    }
    else if (Itemkind.GetItemName()=="松明" )
   {objchange.changeint(7);
  
itemthrow();
   }else if (Itemkind.GetItemName()=="手裏剣" )
   {objchange.changeint(1);
 
itemthrow();
   }
   else if (Itemkind.GetItemName()=="弓矢" )
   {
        objchange.changeint(3);
  GameObject bow=objchange.objlist[3];


  arture(bow);

   }

else if (Itemkind.GetItemName()=="木の盾")
{once1=true;
    objchange.changeint(4);
  shield();
itemthrow();
}else if (Itemkind.GetItemName()=="リフレクトシールド")
{once1=true;
 hp.defence=10;

    objchange.changeint(10);

shield();
itemthrow();
}


 }




bool attack(string boolname){
if (keiinput.attack)
	{
	anim.SetBool(boolname, true);
     return true;
	}return false;
}
bool attackup(string boolname){
if (keiinput.attackup)
	{
	anim.SetBool(boolname, true); return true;
	
	}return false;
}
bool attack(string boolname,float value){
if (keiinput.attack&&mp.mpuse(value))
	{
	anim.SetBool(boolname, true); return true;
	}
      return false;
	
}


public Color emissioncolor;

public void placeitem(){
     if (keiinput.Throw)
     {
anim.Play("spawnobj",0);
Player.EffspawnPlayer(Itemkind.effect);
     }
}
public void sword(){
itemthrow();

anim.SetFloat("swordmode", 1);
charges.chargepower("sword");
 if (keiinput.hissatu)
        {
if (mp.mpuse(30))
{
      anim.SetBool("swordhissatu",true);
}
               }

}


bool bowcharge; 

public void arture(GameObject bow){


      var bowshot= bow.GetComponent<bowshot>();
      bowshot.basepower=Itemkind.GetPower();
        if (keiinput.attack)
        {
             
bowcharge=true;
anim.SetBool("bow",true);
bowshot.damagevalue=0;

        } else if (keiinput.attackup)
        {
          if (Itemkind.optionget()==1)
          {
            bowshot.danyaku=true;
          }else{
bowshot.danyaku=false;
          }
anim.SetBool("bow",false);
Itemkind.optionset(0);
bowcharge=false;
        }
 if (bowcharge)
        {
bowshot.damagevalue++;
   }
}

public void shield(){


   if (keiinput.attack)
        {
         UnityChanControlScriptWithRgidBody.defence(Itemkind.GetPower());


        } else if (keiinput.attackup)
        {
         UnityChanControlScriptWithRgidBody.defenceend();
          }
}

         public void itemthrow(){
if (keiinput.Throw)
{
     
if (Itemkind==noitem){
warning.message("投げるアイテムがない");
     return;
}
anim.SetBool("throw",true);
}
         }
      
}
