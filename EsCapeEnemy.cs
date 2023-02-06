using UnityEngine;using UnityEngine.AI;
using System.Threading.Tasks;
using System;using System;
using Cysharp.Threading.Tasks;
public class EsCapeEnemy : MonoBehaviour
{
    public Transform[] EsCapePoint;
    public NavMeshAgent nav;
    float speed;
    Transform player;
    public Transform nowPoint;
    public float speedupdistance=10;
    public float speedmultpile=2;
    public float directionchangedistance=5;

    public float bebug;
void Start()
{
   player= gameObject.NearserchTag("Player").transform;
  
   if (nav==null)
   {
    nav=GetComponent<NavMeshAgent>();
   }
   speed=nav.speed;
   UpdatePoint();
}

void UpdatePoint(){
 EsCapePoint= EsCapePoint.Shuffle();
foreach (var item in EsCapePoint)
   {if (item==nowPoint)
   {
    continue;
   }
    float enemydis=(item.position-transform.position).sqrMagnitude;
    float playerdis=(item.position-player.position).sqrMagnitude;
    
    if (enemydis<playerdis)
    {
        nav.destination=item.position;
        nowPoint=item;
        break;
    }
     }
}

    void Update()
    {
    bebug=nav.remainingDistance;
        float dis=(player.position-transform.position).sqrMagnitude;
        if (dis<speedupdistance*speedupdistance)
        {
           nav.speed=speed*speedmultpile;  
           
           if (nav.remainingDistance<directionchangedistance)
        {
           UpdatePoint();
           

        }
   
        }else
        {
            nav.speed=speed;
        }
      
    }
}