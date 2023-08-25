

using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;
using ItemSystem;
using System.Threading.Tasks;
public class keikei : MonoBehaviour
{ 
  public static interactionlist interactionlist;
   public static System.Action ac;
    public static ShakeableTransform m_shakeable;
    public static float navspeed;
      public static Transform charaLookAtPosition;
    public static Collider spherecheck;
public static Effekseer.EffekseerEffectAsset chargeeffect;
public static GameObject player;
public static AutoRotateCamera AutoRotateCamera;
public static Transform dokan;
public static Itemkind[] allitems;
public static GameObject treasure;
public static GameObject vanisheffect;
public static Animator playeranim; 
public static GameObject explosion;
public static Effekseer.EffekseerEffectAsset[] effects;
public static Effekseer.EffekseerHandle handle;
public static data playerdata;
public static float time;
public static GameObject camera;
public static GameObject starparticle;
public static GameObject[] particles;
public static Button itempickupbutton;
public static GameObject nowcamera;
public static Button communicationbutton;
public static iteminventory playeriteminventory;
public static List<Itemkind> myitemLists;
public static GameObject inventory;
public static message message;
public static Itemkind noitem;
public static List<GameObject> Destroyobjs;
public static hp hp;
public static float atractskiptime;
public static Camera cameramain;
public static Transform cameradefaultparent;
public static List<GameObject> Allplayer;
public static multcamera multcamera;
public enum bodypart
{
   no,righthand,lefthand,rightfoot,leftfoot,weapons
}
public static IEnumerator GetImageFromURL(string url, RawImage targetRawImage)
{
    using (WWW www = new WWW(url))
    {
        yield return www;
 
        if(targetRawImage != null)
            targetRawImage.texture = www.texture;
    }
 
    yield break;
}

public static void destroy(GameObject obj,float time){

Destroy(obj,time);
}
  public static void Destroys(Component com){

Destroy(com);
  } public static void Destroys(Behaviour com){

Destroy(com);
  }
 public static void Destroys(MonoBehaviour com){

Destroy(com);
  }


  




public static GameObject instantiate(GameObject obj,Vector3 pos,Quaternion rot){

 var o= Instantiate(obj,pos,rot);
  return o;
}
public static RaycastHit mousePositionObj(){
     if (Input.GetMouseButtonDown(0))
        {  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
      
            if (Physics.Raycast(ray, out hit))
            {Debug.Log(hit.collider.gameObject.name);
                return hit;
            }
           
        } return (RaycastHit)default;
}
public static GameObject instantiate(GameObject obj,Transform trans,bool parent=false){
GameObject o= Instantiate(obj,trans.position,trans.rotation);
if (parent)
{
  o.transform.parent=trans;
}
  return o;
}

   public static void itemspawnexplosion(GameObject obj,itemdrop itemdrop){

        obj.itemdroper(itemdrop);
        deathexplosion(obj);
    }
public static void datatransform(){

  
 PlayerEnterTransform(player,playerdata.pos,playerdata.rotation);
}
    


public static void itemnumtext(Itemkind Itemkind,Text numbertext){

   numbertext.text=(Itemkind.Getnumber()+1).ToString();
if (Itemkind==null)
{
  numbertext.text=null;
}
}
  public static void starvanish(GameObject obj){

Instantiate(starparticle,obj.transform.position,Quaternion.identity);
Destroy(obj);
  }


 public static Vector2 GetDpad()
{
    return new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
}
 
  public static void muteki(float time,System.Action act){
hp.nodamage=true;
ac=delegate(){act();
hp.nodamage=false;};
delaycall(ac,time);
  }
 public static void eternaldestroy(GameObject obj){

Destroyobjs.Add(obj);
   Destroy(obj);
 }





public static void PlayerEnterTransform(GameObject obj,Vector3 pos,Vector3 rotation){

if (obj.proottag())
{
  obj.GetComponentIfNotNull<CharacterController>().enabled=false;
}
obj.transform.position=pos;

obj.transform.rotation=Quaternion.Euler(rotation.x,rotation.y,rotation.z);


if (obj.proottag())
{
  obj.GetComponentIfNotNull<CharacterController>().enabled=true;
}
}

public static void PlayerEnterTransform(GameObject obj,Vector3 pos,Quaternion rotation){
  
  PlayerEnterTransform(obj,pos,rotation.eulerAngles);

}

public static void PlayerEnterTransform(GameObject obj,Transform trans){
  
  PlayerEnterTransform(obj,trans.position,trans.rotation.eulerAngles);

}


public static void transformenter(Transform trans,transformdata transformdata){

trans.localPosition=transformdata.pos;
trans.localRotation=transformdata.rotation;

}
public static void transformenter(Transform trans,Transform transformdata){

trans=transformdata;


}

public static void posing(string posename){
    float time;

playeranim.Play(posename);

time= playeranim.GetCurrentAnimatorStateInfo(0).length;
atractcamera(time,player.gameObject.transform,10);
while (time>0)
{
    lookatcamera.lookcamera(player);
        time-=Time.deltaTime; 
}
}

public static void posing(){
  posing("Getitem");
}





  public static void fadescene(string scenename){
    SceneManage.Instance.FadeInoutScene(scenename);
  } 
public static void uijump(Transform rectTransform,float power=50){  
  if (DOTween.IsTweening(rectTransform))  
  {
     rectTransform.DORestart();

  }else
  {
    rectTransform.DOLocalJump(
    rectTransform.localPosition, // 移動終了地点
    power,                    // ジャンプの高さ
    1,                     // ジャンプの総数
    1                 // 演出時間
);
  }
 
  }
public static void uiloopjump(Transform rectTransform,float power){  
  rectTransform.DOKill();
  rectTransform.DOLocalJump(
    rectTransform.localPosition, // 移動終了地点
    power,                    // ジャンプの高さ
    1,                     // ジャンプの総数
    1                 // 演出時間
).SetLoops(-1, LoopType.Yoyo);

}
 


  
 public static void destroy(GameObject obj){
  if (obj!=null)
  {
  Destroy(obj);
  }
  
  }
    
public static void playerstop(GameObject obj){
var playerMovePram= obj.GetComponentIfNotNull<playerMovePram>();
playerMovePram.stop=true;
}


public static void Allplayerstop(){
  
}

   public static void dissolvedeath(GameObject obj,System.Action action=null)
    {
   
     if (obj.GetComponentIfNotNull<U10PS_DissolveOverTime>()!=null)
     {
obj.GetComponentIfNotNull<U10PS_DissolveOverTime>().dissolvevanish(action);
     }else
     {
      action();
      Destroy(obj);
     }
    }

    
    public static void shake()
    {m_shakeable.InduceStress( 1 );
    }
    public static Effekseer.EffekseerHandle Effspawn(Effekseer.EffekseerEffectAsset effect,Transform trans){
    handle = Effekseer.EffekseerSystem.PlayEffect(effect, trans.position);
// transformの回転を設定する。
    handle.SetRotation(trans.rotation);
return handle;

    }  
      public static void Effspawn(Effekseer.EffekseerEffectAsset[] effect,Transform trans){

foreach (Effekseer.EffekseerEffectAsset item in effect)
{
  Effspawn(item,trans);
}

    }  
    public static void Effspawn(Effekseer.EffekseerEffectAsset effect,Transform trans,Quaternion rot){
handle = Effekseer.EffekseerSystem.PlayEffect(effect, trans.position);
    // transformの回転を設定する。
    handle.SetRotation(rot);


    } 
    
     
    

    public static void atractcameraend(){

Destroy(nowcamera);

    }
public static void atractcamera(float duration,Transform trans){

atractcameraspawn(trans);


nowcamera.transform.position+=trans.forward*9;
  ac=delegate(){
Destroy(nowcamera.gameObject,1f);
};

delaycall(ac,duration);

}

public static void atractcamera(float duration,Transform trans,Transform camerapos){

atractcameraspawn(trans,camerapos);


  ac=delegate(){
Destroy(nowcamera.gameObject,1f);
};

delaycall(ac,duration);

}


public static void atractcamera(float duration,Transform trans,float cameradistance){

atractcameraspawn(trans);

nowcamera.transform.position+=trans.forward*cameradistance;
 
  ac=delegate(){
Destroy(nowcamera.gameObject,1f);
};

delaycall(ac,duration);

}public static void atractcamera(float duration,Transform trans,Vector3 cameraoffset){
atractcameraspawn(trans);

nowcamera.transform.position+=cameraoffset;
 
  ac=delegate(){
Destroy(nowcamera.gameObject,1f);
};

delaycall(ac,duration);

}


public static void atractcameraspawn(Transform trans){

if (nowcamera!=null)
{
  Destroy(nowcamera);
}
atractskiptime=1.5f;
 var cam=Instantiate(camera,trans.position,Quaternion.identity);
 nowcamera=cam;
 Lookingtarget(cam.gameObject,trans.gameObject);
 aroundrotatingtarget(cam.gameObject,trans.gameObject,20f);
cam.GetComponent<Camera>().depth=99;
}

public static void atractcameraspawn(Transform trans,Transform camerapos){

if (nowcamera!=null)
{
  Destroy(nowcamera);
}
atractskiptime=1.5f;
 var cam=Instantiate(camera,camerapos.position,camerapos.rotation);
 nowcamera=cam;
 aroundrotatingtarget(cam.gameObject,trans.gameObject,20f);
cam.GetComponent<Camera>().depth=99;
}

public static void atractcamera(float duration,Transform trans,float cameradistance,Vector3 cameraoffset){

atractcameraspawn(trans);

 nowcamera.transform.position+=(trans.forward*cameradistance)+cameraoffset;
  ac=delegate(){
Destroy(nowcamera.gameObject,1f);
};

delaycall(ac,duration);

}

public static void atractcamera(float duration,Transform trans,float cameradistance,Vector3 cameraoffset,bool rotation){


 var cam=Instantiate(camera,trans.position+(trans.forward*cameradistance)+cameraoffset,Quaternion.identity);
 
 Lookingtarget(cam.gameObject,trans.gameObject);
 if (rotation)
 {
   
 aroundrotatingtarget(cam.gameObject,trans.gameObject,20f);
 
 }
cam.GetComponent<Camera>().depth=99;
  ac=delegate(){
Destroy(cam.gameObject,1f);
};

delaycall(ac,duration);
 
}

public static void dontrotateatractcamera(float duration,Transform trans,float cameradistance,Vector3 cameraoffset){


 var cam=Instantiate(camera,trans.position+(trans.forward*cameradistance)+cameraoffset,Quaternion.identity);
 
 Lookingtarget(cam.gameObject,trans.gameObject);
 
cam.GetComponent<Camera>().depth=99;
  ac=delegate(){
Destroy(cam.gameObject,1f);
};

delaycall(ac,duration);

}

public static void bothlook(GameObject obj1,GameObject obj2){

obj1.transform.forward=obj2.transform.position;
obj2.transform.forward=obj1.transform.position;
  
}



public static void atractcamera(float duration,Transform trans,Effekseer.EffekseerEffectAsset particle,float cameradistance){

atractcamera(duration,trans,particle,cameradistance,null);

}
public static void atractcamera(float duration,Transform trans,Effekseer.EffekseerEffectAsset particle,float cameradistance,System.Action action){

 Effspawn(particle,trans);

 atractcameraspawn(trans);
nowcamera.transform.position+=(trans.forward*cameradistance);
 
  ac=delegate(){action();
Destroy(nowcamera.gameObject,1f);
};

delaycall(ac,duration);

}

public static void atractcamera(float duration,Transform trans,Effekseer.EffekseerEffectAsset particle,Vector3 cameradistance){
atractcamera(duration,trans,particle,cameradistance);

}
public static void atractcamera(float duration,Transform trans,Effekseer.EffekseerEffectAsset particle,Vector3 cameradistance,System.Action action){

 Effspawn(particle,trans);

atractcameraspawn(trans);

nowcamera.transform.position+=cameradistance;
 
  ac=delegate(){action();
Destroy(nowcamera.gameObject,1f);
};

delaycall(ac,duration);

}




public static void bigspawn(GameObject bigstar,Transform bigstarspawnpos,GameObject bigstarparticle){

  var st=  Instantiate(bigstar,bigstarspawnpos.position,Quaternion.identity);
var eff=  Instantiate(bigstarparticle,bigstarspawnpos.position,Quaternion.identity);
eff.transform.SetParent(st.transform);
 var cam=Instantiate(camera,st.transform.position+(st.transform.forward*9),Quaternion.identity);
 
 Lookingtarget(cam.gameObject,st);
 aroundrotatingtarget(cam.gameObject,st,20f);
 
cam.GetComponent<Camera>().depth=99;
  ac=delegate(){
Destroy(cam.gameObject,1f);
bigstar.GetComponent<navchaise>().enabled=true;
};

bigstar.GetComponent<navchaise>().enabled=false;
bossappend(st,ac);

}public static void bigspawn(GameObject bigstar,Transform bigstarspawnpos,Effekseer.EffekseerEffectAsset particle){

  var st=  Instantiate(bigstar,bigstarspawnpos.position,Quaternion.identity);
Effspawn(particle,bigstarspawnpos);

 var cam=Instantiate(camera,st.transform.position+(st.transform.forward*9),Quaternion.identity);
 
 Lookingtarget(cam.gameObject,st);
 aroundrotatingtarget(cam.gameObject,st,20f);
 
cam.GetComponent<Camera>().depth=99;
  ac=delegate(){
Destroy(cam.gameObject,1f);
bigstar.GetComponent<navchaise>().enabled=true;
};

bigstar.GetComponent<navchaise>().enabled=false;
bossappend(st,ac);

}



public static void bigspawn(GameObject bigstar,Transform bigstarspawnpos,GameObject bigstarparticle,float cameradistance){

  var st=  Instantiate(bigstar,bigstarspawnpos.position,Quaternion.identity);
var eff=  Instantiate(bigstarparticle,bigstarspawnpos.position,Quaternion.identity);
eff.transform.SetParent(st.transform);
 var cam=Instantiate(camera,st.transform.position+(st.transform.forward*cameradistance),Quaternion.identity);
 
 Lookingtarget(cam.gameObject,st);
 aroundrotatingtarget(cam.gameObject,st,20f);
 
cam.GetComponent<Camera>().depth=99;
  ac=delegate(){
Destroy(cam.gameObject,1f);
bigstar.GetComponent<navchaise>().enabled=true;

};

bigstar.GetComponent<navchaise>().enabled=false;
bossappend(st,ac);

}




public static void colliderset(GameObject obj){

  if (obj.GetComponent<Collider>()!=null)
               {
                  Collider col= obj.GetComponent<Collider>();
                  col.enabled=true;
                  col.isTrigger=false;
               }else
               {obj.AddComponent<MeshCollider>();
                  Collider col= obj.GetComponent<Collider>();
                 col.enabled=true;
                  col.isTrigger=false;
             
               }
}

public static GameObject mobspawn(GameObject bigstar,Transform bigstarspawnpos,GameObject bigstarparticle,float cameradistance){

  var st=  Instantiate(bigstar,bigstarspawnpos.position,Quaternion.identity);
var eff=  Instantiate(bigstarparticle,bigstarspawnpos.position,Quaternion.identity);
eff.transform.SetParent(st.transform);
 var cam=Instantiate(camera,st.transform.position+(st.transform.forward*cameradistance),Quaternion.identity);
 
 Lookingtarget(cam.gameObject,st);
 
cam.GetComponent<Camera>().depth=99;
 System.Action ac=delegate(){
Destroy(cam.gameObject,0.3f);if (bigstar.GetComponent<navchaise>()!=null)
{
bigstar.GetComponent<navchaise>().enabled=true;
  
}

};
if (bigstar.GetComponent<navchaise>()!=null)
{
bigstar.GetComponent<navchaise>().enabled=false;
  
}
mobappend(st,ac);
return st;
}




public static void bigspawn(GameObject bigstar,Transform bigstarspawnpos,GameObject bigstarparticle,float cameradistance,Text text){
text.enabled=true;
  var st=  Instantiate(bigstar,bigstarspawnpos.position,Quaternion.identity);
var eff=  Instantiate(bigstarparticle,bigstarspawnpos.position,Quaternion.identity);
eff.transform.SetParent(st.transform);
 var cam=Instantiate(camera,st.transform.position+(st.transform.forward*cameradistance),Quaternion.identity);
 
 Lookingtarget(cam.gameObject,st);
 aroundrotatingtarget(cam.gameObject,st,20f);
 
cam.GetComponent<Camera>().depth=99;
  ac=delegate(){
Destroy(cam.gameObject,1f);
bigstar.GetComponent<navchaise>().enabled=true;
text.enabled=false;
};

bigstar.GetComponent<navchaise>().enabled=false;
bossappend(st,ac);

}
public static void shake(Transform _target){
 

_target.DOShakePosition(1f, 10f, 30, 1, false);

}
public static void scalechange(RectTransform _target){
 
    var sequence = DOTween.Sequence(); //Sequence生成
  sequence.Append(_target.DOScale(1f, 0.3f).SetRelative(true)
  ).Append(_target.DOScale(-1f, 0.3f).SetRelative(true)
 
  );
    
}
    public static void flowchartmessege(string sendMessage){


     
    }
    public static void deathcamera(GameObject obj){


        
var c=Instantiate(camera,obj.transform.position+(obj.transform.forward*10),Quaternion.identity);
c.transform.LookAt(obj.transform);

    }
public static void Lookingtarget(GameObject from ,GameObject to){


    
 var look =from.AddComponent(typeof(cameraLook))as cameraLook;
 look.target=to;
}
public static void aroundrotatingtarget(GameObject from ,GameObject to){


    
 var aroundrotate =from.AddComponent(typeof(aroundrotate))as aroundrotate;
 aroundrotate.target=to;
}

public static void aroundrotatingtarget(GameObject from ,GameObject to,float rotatespeed){


    
 var aroundrotate =from.AddComponent(typeof(aroundrotate))as aroundrotate;
 aroundrotate.speed=rotatespeed;
 aroundrotate.target=to;
}



public static void delaycall(System.Action action,float delay){
  
Task.Run(async () => {
  await Task.Delay((int)(delay*1000));
  Debug.Log("execute");action.Invoke();
});

DOVirtual.DelayedCall(delay, () => action(),false);
}



   
public static Vector3 randomvector()  // 目的地を生成、xとyのポジションをランダムに値を取得 
    {
   return randomvector(1); }
public static Vector3 randomvectornotY()  // 目的地を生成、xとyのポジションをランダムに値を取得 
    {
   return randomvectornotY(1);
    }
    public static Vector3 randomvector(int a)  // 目的地を生成、xとyのポジションをランダムに値を取得 
    {
    Vector3 randomPos = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
   randomPos*=a;
   return randomPos;
    } public static Vector3 randomvectornotY(int a)  // 目的地を生成、xとyのポジションをランダムに値を取得 
    {
    Vector3 randomPos = new Vector3(Random.Range(-a, a), 0, Random.Range(-a, a));
   return randomPos;
    }


public static RaycastHit raycast(){
  Ray ray = cameramain.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
      
            if (Physics.Raycast(ray, out hit))
            {
               return hit;
                  }
                  return hit;
}

    public static void countdown(float time, bool cooldown){

      if (time>0)
      {time-=Time.deltaTime;
      cooldown=false;
   
      }else
      {
        cooldown=true;
      }
    }
 public static void bossappend(GameObject a,System.Action action=null){
        var sequence = DOTween.Sequence(); //Sequence生成
    //Tweenをつなげる
    sequence.Append(a.transform.DOMoveY(10, 2).SetRelative(true))
    .Join((a.transform.DOMoveX(2, 1).SetRelative(true)) )  
             .Join(a.transform.DOScale(1, 1).SetRelative(true))
             .Join(a.transform.DORotate(new Vector3(0, 1000,0),1f)) 
         .Append(a.transform.DOMoveY(-10f, 2).SetRelative(true))
         .Join(a.transform.DORotate(new Vector3(0, -1000,0),1f)).AppendCallback(()=>
    {
action();
    });
    }
    
    public static void mobappend(GameObject a,System.Action action=null){
        var sequence = DOTween.Sequence(); //Sequence生成
    //Tweenをつなげる
    sequence.Append(a.transform.DOMoveY(10, 1).SetRelative(true))
           .Join(a.transform.DOScale(1, 1).SetRelative(true))
             .Join(a.transform.DORotate(new Vector3(0, 1000,0),1f)) 
         .Append(a.transform.DOMoveY(-10f, 1).SetRelative(true))
         .Join(a.transform.DORotate(new Vector3(0, -1000,0),1f)).AppendCallback(()=>
    {
action();
    });
    }

 public static void itemappend(GameObject a,Transform b,float power,float number=1){

for (int i = 0; i < number; i++)
{
  
itemappendRandom(instantiate(a,b),power); 
}

 }
  
     public static void itemappend(GameObject a,float power=1,System.Action action=null){
        var sequence = DOTween.Sequence(); //Sequence生成
    //Tweenをつなげる
    sequence.Append(a.transform.DOMoveY(6*power, 1).SetRelative(true))
    .Join((a.transform.DOMoveX(2*power, 1).SetRelative(true)) )  
             .Join(a.transform.DOScale(1, 1).SetRelative(true))
             .Join(a.transform.DORotate(new Vector3(0, 1000,0),1f)) 
         .Append(a.transform.DOMoveY(-5.5f*power, 2).SetRelative(true))
         .Join(a.transform.DORotate(new Vector3(0, -500,0),1f)).AppendCallback(()=>
    {
action();
    });
    } 
    
    
      public static void itemappendRandom(GameObject a,float power){
        var sequence = DOTween.Sequence();
       float randomtick=Random.value-0.5f;
         //Sequence生成
    //Tweenをつなげる
    sequence.Append(a.transform.DOMoveY(6, 1+randomtick).SetRelative(true))
    .Join((a.transform.DOMove(new Vector3(power*randomtick,6,power*randomtick) ,1+randomtick).SetRelative(true)) )  
             .Join(a.transform.DOScale(1, 1+randomtick).SetRelative(true))
             .Join(a.transform.DORotate(new Vector3(0, 1000+randomtick,0),1f)) 
         .Append(a.transform.DOMoveY(-5.5f, 2).SetRelative(true))
         .Join(a.transform.DORotate(new Vector3(0, -500,0),1f));
    } 
 
      
    
      
          
          
          public static void backforce(GameObject objss,float power=10){

Rigidbody rb=objss.GetComponentIfNotNull<Rigidbody>();
if (rb!=null)
{
rb.AddForce(-(objss.transform.forward*power),ForceMode.Impulse);
}   

    }

          
          public static void dotweenmove(GameObject target,Vector3 vec,float speed,AnimationCurve type){
       target.transform.DOMove(vec, speed).SetRelative(true).SetEase(type).SetLoops(-1, LoopType.Yoyo);
    }
    public static void fadedeathchildall(GameObject a){
 
        foreach (Transform child in a.transform)
        {
          var mat= child.GetComponent<Renderer>().material;
 var sequence = DOTween.Sequence(); //Sequence生成
    //Tweenをつなげる
    sequence.Append(mat.DOFade(0.0F, 1f)).AppendCallback(()=>
    {
Destroy(child.gameObject);
    });

        }
           }
           
       public static void fadedeathchildall(GameObject a,float duration){
 
        foreach (Transform child in a.transform)
        {
          keikei.fadedeath(child.gameObject,duration);
        }
           }
           
       public static void fadedeath(GameObject a,float num=1){
 
    var fader=  a.AddComponentIfnull<fader>()as fader;
         fader.isFadeOut=true;
         Destroy(a,3);
        
           }
     
 public static void playerset()
{
    playeranim=player.GetComponent<Animator>();
   
}
   
public static void rotate(GameObject target){
target.transform.DORotate(
    new Vector3(450, 450, 0), // 終了時のRotation
    1f                     // 演出時間
).SetLoops(-1, LoopType.Incremental);

}

public static void knockback(GameObject a,float power){
var rb=a.GetComponent<Rigidbody>();
Vector3 velocitys =rb.velocity;
rb.AddForce(-velocitys*power,ForceMode.Impulse);
}
    public static void explosionget(GameObject exp){
explosion=exp;

    }
public static bool kakuritu(int often){
 var b=(int)UnityEngine.Random.Range(100,0);
          
 if (often>b)
            { return true;
            }else
            {
                return false;
            }

}


public static void deathexplosion(GameObject target,GameObject explosions){
 var a= Instantiate(explosions,target.transform.position,Quaternion.identity);
Destroy(target);
  Destroy(a,2);
    }
public static void Shot(GameObject shoter,GameObject shottarget,int damagevalue,float speed){
        
          GameObject bullet = Instantiate(shottarget,shoter.transform.position, shoter.transform.root.gameObject.transform.rotation);
         damagevalue=Mathf.Clamp(damagevalue,1,200);
        bullet.AddComponent(typeof(enemydamage));
 
        var a= bullet.GetComponent<enemydamage>();
             a.damagevalue=damagevalue;

                Rigidbody ballRigidbody = bullet.GetComponent<Rigidbody>();
                    ballRigidbody.AddForce(shoter.transform.root.gameObject.transform.forward*speed*damagevalue,ForceMode.Impulse);
                
          
        
    }
public static void Shot(GameObject shoter,GameObject shottarget,float speed){
        
          GameObject bullet = Instantiate(shottarget,shoter.transform.position, shoter.transform.root.gameObject.transform.rotation);
                Rigidbody ballRigidbody = bullet.GetComponent<Rigidbody>();
                    ballRigidbody.AddForce(shoter.transform.root.gameObject.transform.forward*speed,ForceMode.Impulse);
        
    }
public static void Shot(GameObject shoter,GameObject shottarget){
        
          GameObject bullet = Instantiate(shottarget,shoter.transform.position, shoter.transform.root.gameObject.transform.rotation);
                Rigidbody ballRigidbody = bullet.GetComponent<Rigidbody>();
                    ballRigidbody.AddForce(shoter.transform.root.gameObject.transform.forward*10,ForceMode.Impulse);
        
    } 
public static void forwardforce(GameObject shoter,GameObject shottarget){
        
                 Rigidbody ballRigidbody = shoter.GetComponent<Rigidbody>();
                    ballRigidbody.AddForce(shoter.transform.root.gameObject.transform.forward*10,ForceMode.Impulse);
        
    } 
    
    
    public static void Shot(GameObject shoter,GameObject shottarget,int damagevalue,bool danyaku,float speed,Vector3 controll){
        
          GameObject bullet = Instantiate(shottarget,shoter.transform.position+controll, shoter.transform.root.gameObject.transform.rotation);
         damagevalue=Mathf.Clamp(damagevalue,1,200);
        bullet.AddComponent(typeof(enemydamage));
        if (danyaku)
        {
             bullet.AddComponent(typeof(rigidexplosion));
        }
        if (damagevalue!=0)
        {
           var a= bullet.GetComponentIfNotNull<enemydamage>();
             a.damagevalue=damagevalue;

        }else
        {
          damagevalue=1;
        }
        if (speed==0)
        {
          speed=1;
        }
       
                Rigidbody ballRigidbody = bullet.GetComponent<Rigidbody>();
                    ballRigidbody.AddForce(shoter.transform.root.gameObject.transform.forward*speed*damagevalue,ForceMode.Impulse);         
    }

public static void Shot(GameObject shoter,GameObject shottarget,int damagevalue,bool danyaku,float speed){
         Shot(shoter,shottarget,damagevalue,danyaku,speed,Vector3.zero);
    }
public static void Shot(GameObject shoter,GameObject shottarget,int damagevalue,float speed,Vector3 controll){
         Shot(shoter,shottarget,damagevalue,false,speed,controll);
    }
public static void Shot(GameObject shoter,GameObject shottarget,float speed,Vector3 controll){
              Shot(shoter,shottarget,0,false,speed,controll);
    }
public static void Shot(GameObject shoter,GameObject shottarget,Vector3 controll){
         Shot(shoter,shottarget,0,controll);
    }

public static void deathexplosion(GameObject target){
 var a= Instantiate(explosion,target.transform.position,Quaternion.identity);
Destroy(target);
  Destroy(a,2);
    }

}