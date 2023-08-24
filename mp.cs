using UnityEngine;
using UnityEngine.UI;

public class mp : MonoBehaviour
{
    public float maxMP = 100;
    public float MP = 100;
    public Image mpimage;
    public float increaseTime = 15f;
    void Update()
    {
      
       MP+= maxMP*Time.deltaTime / increaseTime;
        MP = Mathf.Clamp(MP, 0, maxMP);
        if (mpimage != null)
        {
            mpimage.fillAmount = (float)MP / maxMP;
        }
    }
    public void Heal(float num)
    {
        MP += num;
        warning.instance?.message("気力が" + num + "回復した");
    }

    public bool mpuse(float value)
    {
        if (MP < value)
        {
               return false;
        }
        else
        {
            MP -= value;
            return true;
        }
    }
}
