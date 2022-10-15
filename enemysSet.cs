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

 
  }