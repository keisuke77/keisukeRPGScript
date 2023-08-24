using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaihi : MonoBehaviour
{
    // Start is called before the first frame update
    public hpcore hpcore;
    public mp mp;
    public controll input;
    [Range(0,2)]
    public float kaihiCoolDown,kaihiDuration;
    float time;
    public Animator anim;
[Range(0,1)]public float useDashGage;

void KaihiSuccees(){
    hpcore.OnDamageText("かいひ！");
}
public void kaihiExecute(float duration=0.5f){
hpcore.cooldown=true;
hpcore.cooldownHitAction+=KaihiSuccees;
keikei.delaycall(()=>{
hpcore.cooldown=false;
hpcore.cooldownHitAction-=KaihiSuccees;},duration);

            anim.SetTrigger("kaihi");
            
    
}
    // Update is called once per frame
    void Update()
    {time+=Time.deltaTime;
        if ((anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle")||anim.GetCurrentAnimatorStateInfo(0).IsTag("attack"))&&keiinput.Instance.GetKey(input)&&mp.mpuse(useDashGage*mp.maxMP)&&time>kaihiCoolDown)
        {
            kaihiExecute(kaihiDuration);
          time=0;
        }
    }
}
