using UnityEngine;

public class enemyattackcore : MonoBehaviour
{
    
public int basedamagevalue;
public string enemyname;

public bool attack;

void Start()
{
        
 
}
public void attackon(GameObject other,float damagevalue,bool force,float CritRate,float CritMultiplier,float forcepower,bool sequencehit){

attack=true;
var crit = Random.value <= CritRate;
if (crit)
{
  warning.instance?.message(enemyname+"のクリティカル攻撃！");
}
			var damagevalues = crit == true ? (int)(damagevalue * CritMultiplier) : damagevalue;
			damagevalues+=basedamagevalue;
      if (GetComponent<Animator>()!=null)
      { Animator anim=GetComponent<Animator>();
anim.speed=0;  
keikei.delaycall(()=>anim.speed=1,0.1f);
      }
       if (other.pclass().hpcore.damage((int)damagevalues,crit,other.Collider(),sequencehit,gameObject))
      {
  if (force)
  {
other.gameObject.PlayerAddForce(transform.forward*forcepower);
  }
      }
 
	
}
}