using UnityEngine;

using UnityEngine.Events;

using UnityEngine.UI;

using DG.Tweening;
public class imageselect : MonoBehaviour
{public int num;
public Material selectmaterial;
public keiinput keiinput;

public Color SelectColor;
public spriteevent[] spriteevents;
public UnityEvent afterevents;



[System.Serializable]
public class spriteevent{

  [HideInInspector]
  public RPGCharactor BattleSelectChara;

  public GameObject RpgGameobject;
  [HideInInspector]
public Material defaultmatearial;

  [HideInInspector]
public Color defaultcolor;
public Image sprite;
public UnityEvent events;
public System.Action decideaction;
public System.Action Selectaction;


  [HideInInspector]
public Vector3 defaultscale;
}

    
    
     void Start()
    {
       num+=(spriteevents.Length*100000);
    if (keiinput==null)
    {
        
        keiinput=keiinput.Instance;

    }   
    if (keiinput.enabled==false)
    {
        keiinput.enabled=true;
    }
    
foreach (var item in spriteevents)
{item.defaultscale=item.sprite.transform.localScale;
     
    item.defaultmatearial=item.sprite.material; 
    item.defaultcolor=item.sprite.color;
}

     }


   void reset(){
foreach (var item in spriteevents)
{
    item.sprite.material=item.defaultmatearial;
    item.sprite.color=item.defaultcolor;
    item.sprite.gameObject.transform.DOScale(item.defaultscale,0.2f);
}

   }
   void select(){
    reset();
 spriteevents[num%spriteevents.Length].sprite.material=selectmaterial;
 
 spriteevents[num%spriteevents.Length].Selectaction();
 spriteevents[num%spriteevents.Length].sprite.color=SelectColor;
 
 spriteevents[num%spriteevents.Length].sprite.gameObject.transform.DOScale(spriteevents[num%spriteevents.Length].defaultscale*1.2f,0.2f);
   }

bool once;
   void decide(){
    
    if (once)
   {
    return;
   }
    once=true;
    spriteevents[num%spriteevents.Length].decideaction();
 
 
foreach (var item in spriteevents)
{
    item.sprite.gameObject.transform.DOScale(0,0.1f);
}

spriteevents[num%spriteevents.Length].events?.Invoke(); 
afterevents?.Invoke();
  }
   
   void Update () {

if (keiinput.add)
{
	num++;
   select();
}
if (keiinput.decide)
{
	decide();
}
if (keiinput.down)
{num--;
	 select();
}
			
	}
}
