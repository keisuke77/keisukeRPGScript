using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyattack : MonoBehaviour
{
public int damagevalue=3;
public bool force;
public float forcepower;
public bool sequencehit;

enemyattackcore enemyattackcore;
[SerializeField, Range(0, 1)] private float CritRate = 0.1f;
		[SerializeField] private float CritMultiplier = 3f;
    // Start is called before the first frame update
   
   
    void Awake()
    {
  enemyattackcore=gameObject.rootaddcomponent<enemyattackcore>();
    }

 void OnParticleCollision(GameObject other)
 {

 if (other.proottag()&&other!=gameObject)
    { 
enemyattackcore.attackon(other.gameObject,damagevalue,force,CritRate,CritMultiplier,forcepower,sequencehit);
          }

 }


void OnTriggerEnter(Collider other)
{
    if (other.proottag()&&other.gameObject!=gameObject)
    { 
enemyattackcore.attackon(other.gameObject,damagevalue,force,CritRate,CritMultiplier,forcepower,sequencehit);
          }
}
}


