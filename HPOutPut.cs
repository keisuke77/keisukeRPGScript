using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HPOutPut : MonoBehaviour
{
    public hpcore hpcore;
    public AnimationCurve Curve;
    int tempHP;
    public Applibot.DissolveImage dissolveImage;
 void Start() {
    tempHP=hpcore.HP;
}
    // Update is called once per frame
    void Update()
    {
        if(hpcore.HP!=tempHP){
DOTween.To 
(()=> tempHP,	//何に
	(x) => dissolveImage.SetAmount(Mathf.Abs((float)x/hpcore.maxHP-1)),	//何を
	hpcore.HP,		//どこまで(最終的な値)
	1		//どれくらいの時間
).SetEase(Curve);
              tempHP=hpcore.HP;
              
}
        }
        
    }

