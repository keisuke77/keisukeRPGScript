using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetspawneffect : MonoBehaviour
{
    navchaise navchaise;
      [System.Serializable]
    public class targeteffect{ public Transform target;
    
   public bodypart part;
    public Effekseer.EffekseerEffectAsset effect=null;
    public Vector3 rot;
    public bool parent;
    public GameObject particle;
    public int ondamage;
    public int squenceinterval;
    public int forcepower;

    }
   public targeteffect[] targeteffects;
  public GameObject[] box;
    // Start is called before the first frame update
    void Start()
    {
        box=new GameObject[targeteffects.Length];
        navchaise=GetComponent<navchaise>();
    }

    public void Play(int i){

effekseerspawn(i);
    } public void Stop(int i){

effekseerstop(i);

}

public void effekseerspawn(int i){
    var a=targeteffects[i];

if(a.effect)
{
    if (a.target!=null)
      {
        a.target.gameObject.effecseer(a.effect,a.parent).SetRotation(Quaternion.Euler(a.rot));
      }else
      {
        a.part.Getbodypart().effecseer(a.effect,a.parent).SetRotation(Quaternion.Euler(a.rot));
      }
}
    

if (a.particle)
{
if (a.target)
      { 
          box[i]=keikei.instantiate(a.particle,a.target,a.parent);
        }else
      {
 box[i]=keikei.instantiate(a.particle,a.part.Getbodypart().transform,a.parent);
     

            }
if (a.forcepower>0)
{   Rigidbody ballRigidbody = box[i].GetComponent<Rigidbody>();
                
                    ballRigidbody.AddForce(transform.forward*a.forcepower,ForceMode.Impulse);
            
}
if (a.ondamage!=0)
{


  if (navchaise!=null)
  {
    if (navchaise.player)
  {box[i].ForceChildremovecomponentandattach<playerdamage,enemyattack>();
    
 box[i].AddComponent(typeof(enemyattack));
 
 box[i].GetComponent<enemyattack>().damagevalue=a.ondamage;
  }
  }
  else
  {
    
 box[i].AddComponent(typeof(playerdamage));

 box[i].GetComponent<playerdamage>().damagevalue=a.ondamage;
  }
}
   
}
    
}

public void effekseerstop(int i){
    var a=targeteffects[i];
    
      if (a.effect)
    {
         a.target.gameObject.effecseerstop();
  
    } Destroy(box[i]);
  
    
}



    // Update is called once per frame
    void Update()
    {
        
    }
}
