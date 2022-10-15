using System.Collections.Generic;
using UnityEngine;

public class particlecollider: MonoBehaviour
{
    [SerializeField]
    GameObject spawnobj;
     [SerializeField]
    GameObject spawnobj2;
    private gameover gameover;
    public GameObject parentEffect;
    public bool playerdamage=false;
    public bool enemydamage=false;
    public bool jumpeffect=true;
    public bool death=false; 
public Transform warpPos;
List<GameObject> spawns;
    public int damagepower=10;
public float explosionspeed=0;
     GameObject obj;
public bool objspawn=false;
public float effectpower=200;
public bool playerhitobjspawn=true;
public bool enemyhitobjspawn=false;
public bool hitobjspawn=false;
public bool childspawn;
private UnityChanControlScriptWithRgidBody unitychan;
    List<ParticleCollisionEvent> particleCollisionEventList = new List<ParticleCollisionEvent>();

 
    ParticleSystem _ParticleSystem;

    void Start()
    {  _ParticleSystem = this.gameObject.GetComponent<ParticleSystem>();
     
    }
 public void objspawns(GameObject other){
       _ParticleSystem.GetCollisionEvents(other, particleCollisionEventList);

 Vector3 collisionHitPos = particleCollisionEventList[0].intersection;
    
if (spawnobj!=null)
{ 
    spawns.Add(Instantiate(spawnobj,collisionHitPos,Quaternion.identity));

    
}if (spawnobj2!=null)
{
      spawns.Add(Instantiate(spawnobj2,collisionHitPos,Quaternion.identity));

}


if (childspawn)
{
    
foreach (var objss in spawns)
{
    objss.transform.position=Vector3.zero;
    objss.transform.SetParent(other.transform);

}

}

 }
    //パーティクルの当たった箇所でオブジェクト出現
    void OnParticleCollision(GameObject other)
    {
        
if (other.eroottag())
        {

  


if (enemydamage)
{
     var b = other.GetComponent<hpcore>();
b.damage(damagepower);

}


if (enemyhitobjspawn==true)
        {
         objspawns(other);
            Destroy(gameObject);
  
        }
 
        }
else if (other.gameObject.proottag())
        { 
            
            
            obj=other.gameObject.transform.root.gameObject;
              var hp = obj.GetComponent<hp>();
            var unitycon = obj
            .GetComponent<UnityChanControlScriptWithRgidBody>();
if (playerdamage)
{
hp.damage(damagepower);
}
if (parentEffect!=null)
{
  var e=  parentEffect.Instantiate(other.gameObject.transform);
e.transform.parent=other.gameObject.transform;
}
if (warpPos!=null)
{
    keikei.PlayerEnterTransform(obj,warpPos);
}
if(playerhitobjspawn==true){
 objspawns(other);
             Destroy(gameObject);
    

}

            if (jumpeffect)
            { // プレイヤーに風力与える
unitycon?.AddForce(Vector3.up*effectpower);
                     }
        

        

if (explosionspeed!=0)
{
 

        // 風速計算
        var velocity = (other.transform.position - transform.position).normalized * explosionspeed;
    // プレイヤーに風力与える
unitycon?.AddForce(velocity);


	  
	}
   
 
             
    
         }else if (hitobjspawn)
        {
           objspawns(other);
             Destroy(gameObject);
        }
}
}