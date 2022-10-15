using UnityEngine;using UnityEngine.UI;

public class mp : MonoBehaviour
{
      public float maxMP = 100;
public float MP = 100;
     public Image mpimage; 
     public float mphealspeed=1;
     
void Update()
{MP+=(Time.deltaTime*mphealspeed);
    MP = Mathf.Clamp(MP ,0,maxMP);
   if (mpimage!=null)
   {
       mpimage.fillAmount = (float)MP/maxMP;
   }
}
public bool mpuse(float value){
if (MP<value)
{
    warning.warn("mpが足りません");
    return false;
}else
{
    MP-=value;
    return true;
}

}

}