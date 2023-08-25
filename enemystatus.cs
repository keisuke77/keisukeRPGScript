using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "status", menuName = "enemystatus")]
public class enemystatus : ScriptableObject
{ public waza waza;
<<<<<<< HEAD
=======
public motions BigDamageMotion;
public motions DamageMotion;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    public int power=5;
    public string name;
    public itemdrops itemdrops;
   public int HP=100;
   public float speed=5;
   public float patrollspeed=3;
public string discovermessage="血祭りじゃあ";
public string endmessage="強い。あっぱれや";
public int exp=25;
public float scale=1;
public GameObject enemy;
public Sprite icon;
 public int patroldistance=23;
<<<<<<< HEAD



 
    public GameObject spawn(Transform trans){

    GameObject obj= keikei.instantiate(enemy,trans.position,trans.rotation);
    if ( obj.GetComponent<enemyclass>()==null)
    {
        obj.AddComponent(typeof(enemyclass));
    
    }
    obj.GetComponent<enemyclass>().enemystatus=this;
    return obj;
    } 

=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
  }