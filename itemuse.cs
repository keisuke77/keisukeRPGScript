using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class itemuse : MonoBehaviour
{
   public Itemkind Itemkind;
    GameObject Player;
     iteminventory iteminventory;
   public int b;
   public itemcurrent itemcurrent;
public Text numbertext;
 Animator anim;
 public int debug;
 public static itemuse instance;
 public Image itemimage;
 public RectTransform rectTransform;
 public static bool itemusing;
 hp hp;
 itemmanage itemmanage;
 datamanage datamanage;
 public dashgage dashgage;
 UnityChanControlScriptWithRgidBody UnityChanControlScriptWithRgidBody;
    // Start is called before the first frame update
   void Awake()
   {hp=gameObject.root().GetComponent<hp>();
       itemimage=GetComponent<Image>();
      rectTransform=GetComponent<RectTransform>();
     numbertext=GetComponentInChildren<Text>();
        instance=this;
   }
void OnEnable()
{
  if (Itemkind==null)
   {
     itemimage.setA(0);
     numbertext.enabled=false;
   }
}
    void Start()
    {  Player=gameObject.root();
        itemmanage=gameObject.pclass().itemmanage;
        datamanage=gameObject.pclass().datamanage;
        iteminventory=gameObject.getinventory();
        UnityChanControlScriptWithRgidBody=Player.GetComponent<UnityChanControlScriptWithRgidBody>();
         itemcurrent=gameObject.pclass().itemcurrent;
        anim=Player.GetComponent<Animator>();

    }


public void uipop(){

keikei.uijump(rectTransform,50);
  
}

public void itemset(Itemkind a){

    Itemkind=a;
if (itemimage!=null)
{
  itemimage.sprite=a.GetIcon();
 itemimage.setA(255);
  
     numbertext.enabled=true;
    
}}

public void delateitem(){

Itemkind=null;
    
if (itemimage!=null)
{  itemimage.setA(0);
numbertext.enabled=false;
}
}


float cooltime;
public void itemused(){


if (Itemkind.GetKindOfItem().ToString()=="Weapon"||Itemkind.GetKindOfItem().ToString()=="useWeapon"||Itemkind.GetKindOfItem().ToString()=="placeitem")
{
 
    itemcurrent.setitem(Itemkind);
    
      
}else
{
itemusing=true;
cooltime=0;
Invoke("enduse",Itemkind.usetime);
  
 anim.gameObject.PlayEffect(Itemkind.effect,true);
      
}

 iteminventory.removeLists(Itemkind);
     
itemmanage.imagecreate();
}
public void enduse(){


itemusing=false;
}


public bool moucing;
void OnMouseEnter()
{
moucing=true;
}
void OnMouseExit()
{
   moucing=false;
}

public void equiped(){

instance.itemused();

}



public void itemsell(){

datamanage.addmoney(Itemkind.getplace());
Itemkind.Remove(gameObject);

}





public void itemuses(){
  
if (itemusing)
{warning.warn("?????????????????????????????????"+((float)(Itemkind.usetime-cooltime)).ToString()+"?????????????????????");
    
  return;
}
if (Itemkind.GetKindOfItem().ToString()=="Weapon"||Itemkind.GetKindOfItem().ToString()=="useWeapon"||Itemkind.GetKindOfItem().ToString()=="placeitem")
{ 
  
  if(Itemkind.GetItemName()==itemcurrent.Itemkind.GetItemName())
  {
    itemcurrent.returnitem();
    
     }else
  {
      instance=this;
  anim.SetBool("equip",true);
  }
}


switch (Itemkind.GetItemName())
{
  case "??????":if(hp.HP== hp.maxHP){warning.warn("HP???????????????????????????");
    break;}
     instance=this;
keikei.playeranim.SetTrigger("???");
        
    break; case "?????????":var firecircle= Instantiate(keikei.particles[9],keikei.player.transform.position,Quaternion.identity);
        firecircle.transform.parent=keikei.player.transform;
 itemused();
    
break; case "???????????????":

 instance=this;
keikei.playeranim.SetTrigger("charachange");
break; case "?????????????????????":
 instance=this;
keikei.playeranim.SetTrigger("big");
        
    break; case "????????????": if (itemcurrent.Itemkind.GetItemName()=="??????")
     {
if ( itemcurrent.Itemkind.optionget()==1)
{
    warning.warn("???????????????????????????");
    return;
}
       itemused();
       itemcurrent.Itemkind.optionset(1);
     }else{

       warning.warn("???????????????????????????????????????");
     }

    break; case "????????????????????????": UnityChanControlScriptWithRgidBody.movespeed=Itemkind.GetPower();
        
  itemused();
 
    break; case "??????":     
  itemused();
  
    break;
    case???"??????":
    if(dashgage.amount==1){warning.warn("?????????????????????????????????");break;}
    float a=(float)(Itemkind.GetPower()/100);
    dashgage.heal(a);
itemused();
break;

  default:
  if (Itemkind.GetKindOfItem().ToString()=="UseItem")
  {
  if (gameObject.pclass().itemuseplace?.Itemkind==Itemkind)
  {
    gameObject.pclass().itemuseplace.eve.Invoke();
  }else
  {
  warning.warn("????????????????????????????????????????????????");
    
  }
  }
  
    break;
}
           }
          

    // Update is called once per frame
    void Update()
    {
        cooltime+=Time.deltaTime;
        if (Itemkind!=null)
        {
keikei.itemnumtext(Itemkind,numbertext);
        }

        if (moucing)
        {
          itemcurrent.selectText.text=Itemkind.GetItemName()+Itemkind.GetInformation();
        }
    }
}
