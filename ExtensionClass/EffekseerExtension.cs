using UnityEngine;
using Effekseer;

public static class EffekseerExtension
{public static Effekseer.EffekseerHandle handle;
   
   
     public static EffekseerHandle PlayEffect(this GameObject obj,EffekseerEffectAsset effect,bool parent=false,float duration=0){
if (effect==null||obj==null)
{
    return default(EffekseerHandle);
}

     if (parent)
{ if(obj.GetComponent<EffekseerEmitter>()!=null){
     obj.AddComponent(typeof(EffekseerEmitter));
      }
 handle= obj.GetComponentIfNotNull<EffekseerEmitter>().Play(effect);

}else
{
    handle=EffekseerSystem.PlayEffect(effect, obj.transform.position);
    handle.SetRotation(obj.transform.rotation);
}


if (duration>0)
{
 keikei.delaycall(()=>handle.Stop(),duration);
}
return handle;

  }
 



 

}