using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

using System.Collections;
[System.Serializable]
public class eventKeyImage 
{//使うときはenableで起動
public KeyCode key;
public Image image;
public Text text;
public System.Action eve;

    public Ease EaseType;
    public float clickIconspeed=1;   
    
public bool active;
  public IEnumerator SetUpImageEvent(){
    active=true;
    if (image!=null)
    {
         image.enabled=true; 
         image.DOFade(0.0f, clickIconspeed).SetEase(this.EaseType).SetLoops(-1, LoopType.Yoyo);
      
    }
        if (text!=null)
    {
        text.enabled=true;
        text.text=key.ToString();
         text.DOFade(0.0f, clickIconspeed).SetEase(this.EaseType).SetLoops(-1, LoopType.Yoyo);
    }
yield return new WaitUntil(() => key.keydown()); 
eve();
EndImageEvent();
Debug.Log($"njnionijmouavyio");
 yield return null;
    }

public void EndImageEvent(){
    
    active=false;
        if (image!=null)
    { if(DOTween.IsTweening(image))
        {
          image.DOKill();
        }  
        image.enabled=false;
    }

         if (text!=null)
    { 
         if(DOTween.IsTweening(text))
        {
          text.DOKill();
        }  
        text.enabled=false;
    }
}

   
}