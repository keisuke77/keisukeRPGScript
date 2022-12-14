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
  warning.message(enemyname+"のクリティカル攻撃！");
}
			var damagevalues = crit == true ? (int)(damagevalue * CritMultiplier) : damagevalue;
			damagevalues+=basedamagevalue;
      
      
      if (other.root().GetComponent<hpcore>().damage((int)damagevalues,crit,other.Collider(),sequencehit))
      {
  if (force)
  {
other.root().GetComponent<IForceIdle>().AddForce(transform.forward*forcepower);
  }
      }
 
	
}
}