using UnityEngine;using UnityEngine.UI;
using System;
[CreateAssetMenu(fileName = "RpgPlayerMotion", menuName = "RpgPlayerMotion")]
public class RpgPlayerMotion : motions
{
  public GameObject hitparticle;
  public motions missmotion;
<<<<<<< HEAD
  public string motionname;
=======
public string motionname;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

    public void Play(GameObject player,GameObject enemy,MonoBehaviour mono){
AnimEffect(player);

bool missonce;
bool buttonspriteonce;
<<<<<<< HEAD
=======
keiinput keiinput=keiinput.Instance;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
 
 keikei.delaycall(()=>
  StaticAsset.Instance.sprites[0].CreateImage(player),startdamagetime
);

 mono.delayAndwhilecall(()=>{

<<<<<<< HEAD
if (keiinput.Instance.attack)
=======
if (keiinput.attack)
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
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