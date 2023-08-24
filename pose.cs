using UnityEngine;
using DG.Tweening;
using System;

public class pose : MonoBehaviour {
    
[Header("動きを止める　メニューを動かす際のkeycodeは自分で指定")]public GameObject Player;
[Header("演出用ライトセットしなくてもどっちでもよい")]
public Light light;


float orivalue;
public bool TimeScaleStop;
private void Awake() {
         if (light!=null)
        {
        orivalue=light.intensity;

        }
   
}
    private void OnEnable() {
        if (TimeScaleStop)
        {
            Time.timeScale=0;
        }
        if (light!=null)
        {
            
  DOTween.To(() =>light.intensity, (x) => light.intensity=x, 60000, 0.4f);
     
        }
        Player.SetActive(false);
 
   var navchaises=GameObjectExtension.GetComponentsInActiveScene<navchaise>(false);
         if (navchaises!=null)
         {
              PoseEnd=null;
        foreach (var item in  navchaises)
        {
            
        item.Stop();
        PoseEnd+=item.ReStart;
      
        }
         }

    }
public Action PoseEnd;
    private void OnDisable() {
        Player.SetActive(true);
 
           if (TimeScaleStop)
        {
            Time.timeScale=1;
        }if (light!=null)
        {
             DOTween.To(() =>light.intensity, (x) => light.intensity=x, orivalue, 0.4f);
        }
       
       
   keiinput.Instance.stop=false;  
   if(PoseEnd!=null)PoseEnd();
    
    }
}