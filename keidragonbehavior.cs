using UnityEngine;using System.Collections;
using System.Collections.Generic;

public class keidragonbehavior : MonoBehaviour
{
    navchaise navchaise;
 public float skyattackdis=6;
     public string skyrandomattackname;
    public spawncircle spawncircle;
    public GameObject buka;
    public GameObject magic;
     public GameObject magic1;
    public string randomattackname;
    public Effekseer.EffekseerEffectAsset snoweffect;
    public Effekseer.EffekseerEffectAsset[] starteffect;
    public List<GameObject> spawns;
GameObject[] bukas;
 Transform trans;
enemyhp enemyhp;
   Animator anim;
    void Awake()
    {
enemyhp=GetComponent<enemyhp>();
anim = GetComponent<Animator> ();
        navchaise=GetComponent<navchaise>();


        trans=transform;
keikei.Effspawn(starteffect,trans);
    }

      public void bukaadd(GameObject[] obj){
          foreach (var item in obj)
       {
           spawns.Add(item);
       }
     }
public void randomattack(){
 if (enemyhp.HP==0)
    {
        foreach (var item in spawns)
        {
            Destroy(item);
        }
        return;
    }

    if (keikei.kakuritu(30))
    {
        anim.Play(randomattackname,0,0);
    }else if(keikei.kakuritu(10))
    {
         bukas=  spawncircle.spawn(buka,4);
   
      bukaadd(bukas);
         
       }else if(keikei.kakuritu(5))
    {
keikei.Effspawn(snoweffect,trans);
      
          bukas = spawncircle.spawn(magic,30);
          bukaadd(bukas);
       }else if(keikei.kakuritu(10))
    {
         bukas= spawncircle.spawn(magic1,30);
         bukaadd(bukas);
       }

    if (!anim.GetBool("sky"))
    {
        if (keikei.kakuritu(5))
    {
        anim.SetBool("sky",true);
    }

    }
    

}
void OnCollisionEnter(Collision collisionInfo)
{if (collisionInfo.ptag()&&anim.GetBool("skyattack"))
{
     anim.SetBool("skyattack",false);
     


}
     
}

public void duringskyatttack(){
 if (enemyhp.HP==0)
    {
        return;
    }

if (keikei.kakuritu(30))
    {
        anim.SetBool("skyattack",false);
    }
}

public void skyrandomattack(){
 if (enemyhp.HP==0)
    {
        return;
    }
if (navchaise.meleedistance > skyattackdis*skyattackdis){  
            if (!anim.GetBool("skyattack"))
            {

if (keikei.kakuritu(30))
    {
        anim.SetBool("skyattack",true);
    }else if (keikei.kakuritu(50))
    {

         anim.Play(skyrandomattackname,0,0);
    }
    
    
    }else
    {
        
if (keikei.kakuritu(30))
    {
        anim.SetBool("skyattack",false);
    }
    }
    
    
    
    
     }else
    {
        if (keikei.kakuritu(8))
    {
        anim.SetBool("sky",false);

    }
    }
    


}
}