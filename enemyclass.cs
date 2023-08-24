using UnityEngine;

public class enemyclass : CharactorClass {
    public enemystatus enemystatus;
enemyhp enemyhp;
navchaise navchaise;

    void Awake()
    {  
  GetComponent<WazaManagement>().MainWaza=enemystatus.waza;
  GetComponent<basehp>().HP=enemystatus.HP;
  GetComponent<enemyhp>().enemyname=enemystatus.name;
  GetComponent<enemyhp>().exp=enemystatus.exp;
  GetComponent<enemyhp>().itemdrops=enemystatus.itemdrops;
  GetComponent<navchaise>().meleeSpeed=enemystatus.speed;
  GetComponent<navchaise>().cantchasedis=enemystatus.patroldistance;
  GetComponent<navchaise>().patrollspeed=enemystatus.patrollspeed;
  GetComponent<navchaise>().message=enemystatus.discovermessage; 
  GetComponent<navchaise>().icon=enemystatus.icon;
  GetComponent<attackcore>().basedamagevalue=enemystatus.power;
  GetComponent<attackcore>().enemyname=enemystatus.name.ToString();
  GetComponent<Transform>().localScale=Vector3.one*enemystatus.scale;
    }
}