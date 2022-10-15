using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dashgage : MonoBehaviour
{public Image image;
public float amount;
public float decreasetime=10;
public float increasetime=15;
keiinput keiinput;
public UnityChanControlScriptWithRgidBody UnityChanControlScriptWithRgidBody;
public Coffee.UIExtensions.ShinyEffectForUGUI ShinyEffectForUGUI;
    // Start is called before the first frame update
    void Start()
    {keiinput=gameObject.pclass().keiinput;
		
        if (!image)
        {
            image=GetComponent<Image>();
        }
       ShinyEffectForUGUI= image.gameObject.AddComponentIfnull<Coffee.UIExtensions.ShinyEffectForUGUI>();

    }
public void heal(float num){

 amount+=num;
 warning.message("気力が"+num+"回復した");
  ShinyEffectForUGUI.Play();
}
    // Update is called once per frame
    void Update()
    {
         if (keiinput.dashduring&&UnityChanControlScriptWithRgidBody.v>0)
        {
            amount-=(Time.deltaTime/decreasetime);
        }else
        {
             amount+=(Time.deltaTime/increasetime);
        }
 amount=Mathf.Clamp(amount,0,1);
      
        if (amount==0)
        {
            UnityChanControlScriptWithRgidBody.anim.SetTrigger("tired");
        }
        if(amount==1)
        {
            image.gameObject.transform.parent.gameObject.SetActive(false);
        }else{
             image.gameObject.transform.parent.gameObject.SetActive(true);
         }
   image.fillAmount=amount; }
}
