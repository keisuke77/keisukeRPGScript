using UnityEngine;


public class AnimBoolSet : MonoBehaviour{
    public AnimBoolName AnimBoolName;
    keiinput keiinput;
    public bool Stop;
    void Start()
    {
        AnimBoolName.Anim=GetComponent<Animator>();
        keiinput=keiinput.Instance;
    }
    void Update()
    {if (!Stop)
    {
           AnimBoolName.Update(keiinput);
    }
        }
}