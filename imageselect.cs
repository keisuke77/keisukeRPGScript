using UnityEngine;

using UnityEngine.Events;

using UnityEngine.UI;

using DG.Tweening;
<<<<<<< HEAD

public class imageselect : MonoBehaviour
{
    public int num;
    public Material selectmaterial;


    public System.Action decideaction;
    public Color SelectColor;
    public spriteevent[] spriteevents;
    public UnityEvent afterevents;
[Range(-3,3)]public float SelectBigScale=1f;
[Range(-3,3)]public float DecidePunchPower=0.1f;
public Vector2 outlineSize;
public KeyCode AddKey;
public KeyCode DownKey;

public KeyCode DecideKey;
public Color OutlineColor;
    [System.Serializable]
    public class spriteevent
    {
        [HideInInspector]
        public Material defaultmatearial;

        [HideInInspector]
        public Color defaultcolor;

        public Image sprite;
        public Text text;
        public UnityEvent events;
        public System.Action decideaction;
        public System.Action Selectaction;
        [HideInInspector]
        public Outline outline;
        [HideInInspector]
        public Vector3 defaultscale;
    }

    void Start()
    {

        
        num += (spriteevents.Length * 100000);


        foreach (var item in spriteevents)
        {
          if(item.sprite!=null){

               item.defaultscale = item.sprite.transform.localScale;
               item.outline= item.sprite.gameObject.AddComponentIfnull<Outline>()as Outline;
               item.defaultmatearial = item.sprite.material;
               item.defaultcolor = item.sprite.color;
      
          }
           if(item.text!=null){ 
            item.defaultscale = item.text.transform.localScale;
            item.outline= item.text.gameObject.AddComponentIfnull<Outline>()as Outline;
            item.defaultmatearial = item.text.material;
            item.defaultcolor = item.text.color;
    
           }
      
           item.outline.effectColor=OutlineColor;
           item.outline.effectDistance=outlineSize;
               }
    }

    void materialreset()
    {
        foreach (var item in spriteevents)
        {

             if (item.sprite!=null)
        {
            item.sprite.material = item.defaultmatearial;
            item.sprite.color = item.defaultcolor;
            item.sprite.gameObject.transform.DOScale(item.defaultscale, 0.2f);
        }
            if (item.text!=null)
        {
            item.text.material = item.defaultmatearial;
            item.text.color = item.defaultcolor;
            item.text.gameObject.transform.DOScale(item.defaultscale, 0.2f);
    
        }

            item.outline.enabled=false;
        }
    }

    


    void select()
    {
        materialreset();

        if (CurrentSpriteEvent.sprite!=null)
        {
        CurrentSpriteEvent.sprite.color = SelectColor;
        CurrentSpriteEvent.sprite.material = selectmaterial;
        CurrentSpriteEvent.sprite.gameObject.transform.DOScale(
        CurrentSpriteEvent.defaultscale *SelectBigScale,
            0.2f
        );
        }
         if (CurrentSpriteEvent.text!=null)
        {
        CurrentSpriteEvent.text.color = SelectColor;
        CurrentSpriteEvent.text.material = selectmaterial;
        CurrentSpriteEvent.text.gameObject.transform.DOScale(
        CurrentSpriteEvent.defaultscale *SelectBigScale,
            0.2f
        );
        }
       
 CurrentSpriteEvent.outline.enabled=true;
            if (CurrentSpriteEvent.Selectaction!=null)
         {
              CurrentSpriteEvent.Selectaction();
         }
     
    }

    bool once;



   public void decide()
    {
        if (once)
        {
            return;
        }
        once = true;   
         if (CurrentSpriteEvent.sprite!=null)
        {

    CurrentSpriteEvent.sprite.gameObject.transform.DOPunchScale(Vector3.one * DecidePunchPower, 0.5f, 2, DecidePunchPower).OnComplete(()=>
  once=false
  );
  
 if (CurrentSpriteEvent.sprite.gameObject.GetComponent<Button>()!=null)
 {
    CurrentSpriteEvent.sprite.gameObject.GetComponent<Button>().onClick.Invoke();
 }

        } 
           if (CurrentSpriteEvent.text!=null)
        {

    CurrentSpriteEvent.text.gameObject.transform.DOPunchScale(Vector3.one * DecidePunchPower, 0.5f, 2, DecidePunchPower).OnComplete(()=>
  once=false
  );
  
  }


    CurrentSpriteEvent.events?.Invoke();
   
if (CurrentSpriteEvent.decideaction!=null)
{
    CurrentSpriteEvent.decideaction(); 
}

if (decideaction!=null)
{
      decideaction();
}

       

          afterevents?.Invoke();
    }
public spriteevent CurrentSpriteEvent;

    void Update()
    {
        
        CurrentSpriteEvent=spriteevents[num % spriteevents.Length];

        if (AddKey.keydown())
        {
            num++;
             CurrentSpriteEvent=spriteevents[num % spriteevents.Length];

            select();
        }
        if (DecideKey.keydown())
        { CurrentSpriteEvent=spriteevents[num % spriteevents.Length];

            decide();
        }
        if (DownKey.keydown())
        {
            num--;
             CurrentSpriteEvent=spriteevents[num % spriteevents.Length];

            select();
        }
    }
=======
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
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}
