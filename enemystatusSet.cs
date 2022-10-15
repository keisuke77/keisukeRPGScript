using UnityEngine;

public class enemystatusSet : MonoBehaviour
{
    public enemystatus enemystatus;
enemyhp enemyhp;
navchaise navchaise;
enemyattack enemyattack;

    void Awake()
    {  
 GetComponent<enemyhp>().DamageMotion=enemystatus.DamageMotion;
 GetComponent<enemyhp>().BigDamageMotion=enemystatus.BigDamageMotion;
  GetComponent<navchaise>().Setwaza(enemystatus.waza);
  GetComponent<enemyhp>().HP=enemystatus.HP;
  GetComponent<enemyhp>().enemyname=enemystatus.name;
  GetComponent<enemyhp>().deathmessage=enemystatus.endmessage;
  GetComponent<enemyhp>().icon=enemystatus.icon;
  GetComponent<enemyhp>().exp=enemystatus.exp;
  GetComponent<enemyhp>().itemdrops=enemystatus.itemdrops;
  GetComponent<navchaise>().speed=enemystatus.speed;
  GetComponent<navchaise>().cantchasedis=enemystatus.patroldistance;
  GetComponent<navchaise>().patrollspeed=enemystatus.patrollspeed;
  GetComponent<navchaise>().message=enemystatus.discovermessage; 
  GetComponent<navchaise>().icon=enemystatus.icon;
  GetComponent<enemyattackcore>().basedamagevalue=enemystatus.power;
  GetComponent<Transform>().localScale=Vector3.one*enemystatus.scale;
    }
 
}