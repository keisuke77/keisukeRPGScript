using UnityEngine;using UnityEngine.UI;
using System;
[CreateAssetMenu(fileName = "RpgPlayerMotion", menuName = "RpgPlayerMotion")]
public class RpgPlayerMotion : motions
{
  public GameObject hitparticle;
  public motions missmotion;
  public string motionname;

    public void Play(GameObject player,GameObject enemy,MonoBehaviour mono){
AnimEffect(player);

bool missonce;
bool buttonspriteonce;
 
 keikei.delaycall(()=>
  StaticAsset.Instance.sprites[0].CreateImage(player),startdamagetime
);

 mono.delayAndwhilecall(()=>{

if (keiinput.Instance.attack)
{
if (enemy.GetComponent<enemyhp>().damage(damagevalue,false,player))
{
    hitparticle.Instantiate(enemy.transform);
}else
{missonce=true;
missmotion.Play(player);
}
    
}
 },startdamagetime,enddamagetime-startdamagetime);



    }


}