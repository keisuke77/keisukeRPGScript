using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIExtensions;

 
public class hp : hpcore{ 
    Transform hpimagetrans;
    public flashscrean flashscrean;
    ShinyEffectForUGUI m_shiny;
    bool once;
     public itemdrop itemdrop;
    public float shakepower=1;
   public playerdeath playerdeath;
      public bool damageshake;
   		datamanage datamanage;
      public bool timeScale=true;
    // Start is called before the first frame update
    void Awake()
    {
        if (HP==0)
        {
         HP=maxHP;   
        }
    }     

  public void muteki(float time,System.Action ac=null){
nodamage=true;
keikei.delaycall(()=>{nodamage=false;ac();},time);
  }

    public override void SetUp(){
      
        hpImage=gameObject.FindAllChild("hpimage")?.GetComponentIfNotNull<Image>();
       hptext=gameObject.FindAllChild("hptext")?.GetComponentIfNotNull<Text>();
       datamanage=GetComponent<datamanage>();
      playerdeath=GetComponent<playerdeath>();
if (hpImage!=null)
{
hpimagetrans=hpImage.GetComponent<Transform>();
m_shiny=hpImage.gameObject.GetComponent<ShinyEffectForUGUI>();
}  
    }

public override void hpheal(int amount){
HP=HP+amount;
warning.message("HPが"+amount.ToString()+"回復した！");
GameObject obj;
obj=Instantiate(healparticle, transform.position, Quaternion.identity)as GameObject;
obj.transform.parent=transform;
}

public void hpitemheal(){
  
    hpheal(itemuse.instance.Itemkind.GetPower());
    itemuse.instance.itemused();
}


public override void OnDamage(int damage)
{
      
     if (damageshake)
     {
ShakeableTransform.m_shakeable.InduceStress((float)damage*shakepower);
     }if (flashscrean!=null)
     {
flashscrean?.damage();  
     } 
if (timeScale)
{
  Time.timeScale=0.2f;
  keikei.delaycall(()=>Time.timeScale=1f,0.2f);
}
     if (hpimagetrans!=null)
{
     keikei.uijump(hpimagetrans,damage*6);
     }

 
   if (HitParticle!=null)
     {
         Instantiate(HitParticle,transform.position,transform.rotation);
  
     } if (hiteffect!=null)
     {
        keikei.Effspawn(hiteffect,transform);
     }


     
    }
   


public override void OnDeath(){

      if (itemdrop!=null)
    {
    keikei.itemspawnexplosion(gameObject,itemdrop);
    }
   
    if (playerdeath!=null)
    {
        playerdeath.death();
    }

}
   
}
