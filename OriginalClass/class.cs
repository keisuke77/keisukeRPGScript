using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

[System.Serializable]
public class keyduration
{
    public KeyCode key;
    public float duration = 0.1f;
    public bool able;
    public UnityEvent putkey;

    public void execute()
    {
        if (key != null)
        {
            if (!able && key.keydown())
            {
                able = true;
                putkey.Invoke();
                keikei.delaycall(() => able = false, duration);
            }
        }
    }
}


[System.Serializable]
public class eventKeyImage
{ //使うときはenableで起動
    public KeyCode key;
    public Image image;
    public Text text;
    public System.Action KeyDownCallback;
    public Ease EaseType;
    public float clickIconspeed = 1;

    bool active;

    public IEnumerator SetUp(System.Action KeyDownCallbacks=null)
    {
        
        EndImageEvent();
        if (KeyDownCallbacks!=null)
        {KeyDownCallback=KeyDownCallbacks;
            
        }
        active = true;
        if (image != null)
        {
            image.enabled = true;
            image.DOFade(0.0f, clickIconspeed).SetEase(this.EaseType).SetLoops(-1, LoopType.Yoyo);
        }
        if (key == null)
        {
            key = KeyCode.Space;
        }
        if (text != null)
        {
            text.enabled = true;
            text.text = key.ToString();
            text.DOFade(0.0f, clickIconspeed).SetEase(this.EaseType).SetLoops(-1, LoopType.Yoyo);

        }
        yield return new WaitUntil(() => key.keydown());
        KeyDownCallback();

        EndImageEvent();
        Debug.Log($"njnionijmouavyio");
        yield return null;
    }

     public void Off()=>EndImageEvent();
    

    public void EndImageEvent()
    {
        active = false;
        if (image != null)
        {
            if (DOTween.IsTweening(image))
            {
                image.DOKill();
            }
            image.enabled = false;
        }

        if (text != null)
        {
            if (DOTween.IsTweening(text))
            {
                text.DOKill();
            }
            text.enabled = false;
        }
    }
}






[System.Serializable]
public class IconGenerate {
    public Sprite talksprite;  
    public Vector3 ImagePos=new Vector3(0,1,0);
    public Vector3 Scale=new Vector3(1,1,1);
    SpriteRenderer TalkIcon;
    Vector3 orisize;
 
public void SetUp(GameObject obj){
    if (TalkIcon!=null)
    {
        keikei.Destroy(TalkIcon.gameObject);
    }
    
  TalkIcon = talksprite?.CreateImage(obj).GetComponent<SpriteRenderer>();
        TalkIcon.transform.localPosition = ImagePos;  
        TalkIcon.transform.localScale = Scale;
        orisize=TalkIcon.transform.localScale;
 TalkIcon.enabled=false;

}

public void On(){
        TalkIcon.enabled=true;
            TalkIcon.transform.DOScale(orisize,0.4f);
            TalkIcon.DOFade(1,0.2f);
  
}
public void Off(){
     TalkIcon.transform.DOScale(0,0.4f);
        TalkIcon.DOFade(0,0.4f).OnComplete(()=>
         TalkIcon.enabled=false
        );

}

}







[System.Serializable]
public class EffectAndParticle
{
    public GameObject Particle;
    public Effekseer.EffekseerEffectAsset Effect;
    public float duration = 0;
    public float delay = 0;
    Effekseer.EffekseerHandle handle;
    GameObject instance;
 public void Execute(Transform trans, Collider coll = null)
    {
        if (trans!=null)
        {
Execute(trans.position,coll);
        }
    }
    public void Execute(Vector3 pos, Collider coll = null)
    {
               
        keikei.delaycall(
            () =>
            {
                End();
                if (Particle != null)
                {
                    if (coll != null )
                    {
                        instance = Particle.Instantiate(coll.ClosestPointOnBounds(pos));
                    }
                    else 
                    {
                        instance = Particle.Instantiate(pos);
                    }
                }
                if (Effect != null)
                {
                    if (coll != null )
                    {
                        handle = Effect.Play(coll.ClosestPointOnBounds(pos));
                    }
                    else
                    {
                        handle = Effect.Play(pos);
                    }
                }
                if (duration > 0)
                {
                    keikei.delaycall(End, duration);
                }
            },
           Time.deltaTime+ delay
        );
    }

    public void End()
    {
      
            handle.Stop();
       
        
        if (instance != null)
        {
            keikei.destroy(instance);
        }
    }
}
