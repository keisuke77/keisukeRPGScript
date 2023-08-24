using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(enemyhp))]
public class navchaise : MonoBehaviour, IForceIdle
{
    public UnityEngine.Events.UnityEvent discoverevent;

    [Header("Debug用　実際の追いかけるポイントとの距離　AgentDestinationはポイントと重ならないようにずらしてあるからこれとは違う")]
    public float agentdestinationdis;
    

    public float patrollspeed = 2;
    public float meleeSpeed = 4;

    public Transform point;
    public float cantchasedis = 20;

    public string message;
    public bool alwayschaise;

    public bool patrol;

public bool lookat;
    public float patrolnexttime = 8;

    public int patrollarea = 10;

    public string ChaiseTag = "Player";
    public float minwalk = 1;
    private NavMeshAgent agent;

    public Vector3 mesPos;
    public Sprite icon;


    public bool RandomPatroll;

   public float EnterPatrolRandomTimeMin = 5f;  // The minimum time for patrol mode in seconds
public float EnterPatrolRandomTimeMax = 10f; // The maximum time for patrol mode in seconds
   public float EnterMeleeRandomTimeMin = 5f;  // The minimum time for patrol mode in seconds
public float EnterMeleeRandomTimeMax = 10f; // The maximum time for patrol mode in seconds
private float nextChangeTime = 0f; // The time until the next patrol



    basehp basehp;
    Animator anim;
    bool onces = false;
    bool meleeonce;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        basehp = GetComponent<basehp>();
    }

    public void AddForce(Vector3 direction)
    {
        agent.enabled = false;
        if (GetComponent<Rigidbody>() != null)
        {
            GetComponent<Rigidbody>().AddForce(direction);
        }
        agent.enabled = true;
    }

    public void pointupdate()
    {
        point = gameObject.NearserchTag(ChaiseTag).root().transform;

        if (point == null)
        {
            point = transform;
        }
    }

    public void randomposition()
    {
        agent.destination = transform.position + keikei.randomvectornotY(patrollarea);
    }

    public void newposition()
    {
        pointupdate();

        SetDestination();
    }

    public float closedistancerate = 1;

    public void SetDestination()
    {
        agent.destination =
            point.position + ((transform.position - point.position).normalized * closedistancerate);
    }

 

    public void meleemode()
    { 
        //navmeshに設定されている目的値の距離
        //実際の目的値との距離
        if (agentdestinationdis > minwalk * minwalk)
        {
            agent.speed = meleeSpeed;
        

            newposition();
        }
        else
        {
         
            agent.speed = 0;
        }    
        if (lookat)
        {
                 transform.DOLookAt(point.localPosition, 1f);
 
   
        }
          if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
     {
                agent.speed = 0;
         }

        if (alwayschaise)
        {
            SetDestination();
        }

        if (!meleeonce )
        {
            newposition();
            agent.speed = meleeSpeed;
            meleeonce = true;
        }

        if (!onces)
        {
            keikei.delaycall(firstdiscover, 1f);
            onces = true;
        }
    }

    public void firstdiscover()
    {
       transform.DOLookAt(point.localPosition, 1f);
    if (discoverevent != null)
        {
            discoverevent?.Invoke();
        }

        if (message != "")
        {
            message.CreateMesImage(gameObject, mesPos);
            ChatExecute.instance?.message.SetMessagePanel(message, true, icon);
        }
    }

    float patroltime;

    //ポイントはつかわない。ポイント使うとagentdestinationdisの値が変わってmeleemodeになるから
    public void patrolmode()
    {
        if (meleeonce)
        {
            agent.speed = patrollspeed;
            meleeonce = false;
        }
        patroltime -= Time.deltaTime;
        Vector3 Apos = transform.position;

        if (agent.remainingDistance < 2 || patroltime < 0)
        {
            patroltime = patrolnexttime;
            randomposition();
        }
    }

public void Stop(){

if(anim!=null){
    anim.enabled=false;
}    
if (agent!=null)
{
      agent.enabled=false;
}
  
}
public void ReStart(){

if(anim!=null){
    anim.enabled=true;
}    
if (agent!=null)
{
      agent.enabled=true;
}
}

bool meleepatrol;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (basehp.HP == 0)
        {
            anim.FloatTo("speed", 0);
            agent.speed = 0;
            return;
        }

        if (point == null)
        {
            pointupdate();
        }
if (agent.velocity.sqrMagnitude>1)
{
     anim.FloatTo("speed", 1);
}else
{
      anim.FloatTo("speed", 0);
      
}
    
    
    nextChangeTime -= Time.deltaTime;

if (RandomPatroll)
{
     if (nextChangeTime <= 0f)
    {if (meleepatrol)
    {
          meleepatrol = false;
        // Reset the timer
        nextChangeTime = Random.Range(EnterPatrolRandomTimeMin, EnterPatrolRandomTimeMax);

    }else
    {
            meleepatrol = true;
        // Reset the timer
        nextChangeTime = Random.Range(EnterMeleeRandomTimeMin,EnterMeleeRandomTimeMax);
    }
      }
}else
{
     meleepatrol = false;
}
    // If it's time for the next patrol, go into patrol mode
   

        agentdestinationdis = (point.position - transform.position).sqrMagnitude;

        if (cantchasedis * cantchasedis < agentdestinationdis)
        {
            patrol = true;
        }
        else
        {
            if (meleepatrol)
        {
         patrol = true;
        }   
        else
        {
              patrol = false;
        }
       
        }

        if (patrol)
        {
            patrolmode();
        }
        else
        {
            meleemode();
        }
    }
}
