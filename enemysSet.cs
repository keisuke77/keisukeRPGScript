using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "status", menuName = "enemysSet")]
public class enemysSet : ScriptableObject
{
    [System.Serializable]
    public class enemy{

        public enemystatus enemystatus;
        public int number;
    }

    public List<enemy> enemys;

      public List<GameObject> spawn(Transform trans){
var objs=new List<GameObject>(30);
foreach (enemysSet.enemy item in enemys)
{
if(item.enemystatus!=null){
for (var i = 0; i < item.number; i++)
{
  objs.Add(item.enemystatus.spawn(trans)); 
}
}
}
  return objs;
     }


 
  }