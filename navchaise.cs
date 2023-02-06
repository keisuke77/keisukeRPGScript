using UnityEngine;
        using UnityEngine.AI;
        using System.Collections;
        using UnityEngine.UI; 



[RequireComponent(typeof(NavMeshAgent))]    
[RequireComponent(typeof(enemyhp))]
[RequireComponent(typeof(Animancer.AnimancerComponent))]



public class navchaise : MonoBehaviour,IForceIdle
{
 public waza waza;
    // エフェクトを取得する。
    public UnityEngine.Events.UnityEvent discoverevent;
    public bool player;
    public bool firstatractcamera;
    public float cameradistance=9.8f;
     public float agentdestinationdis;
 public Sprite icon;
  public float meleedistance;
  public float patroldistance;
      public string firstanim;
    public float patrollspeed;
      public Image discoverimage;
       bool oncediscover;
            public Transform point;
           public float cantchasedis=20;
    public float speed;
            public NavMeshAgent agent;
Animator anim;
public bool chaising;
public string message;
basehp enemyhp;
bool once=false;
bool onces=false;
public bool alwayschaise;
public bool playerlook;
   public bool patrol;
  public Vector3 currentpatrollposition;
  bool meleeonce;
public float patrolnexttime=8;
float patrolnexttimes;
public int patrollarea=10;
public Vector3 mesPos;
public bool meleecamerachange;
public void Setwaza(waza wazas){

    waza=wazas;
}

public void AddForce(Vector3 direction){
agent.enabled=false;
if (GetComponent<Rigidbody>()!=null)
{
    GetComponent<Rigidbody>().AddForce(direction);
}  
agent.enabled=true;
}

public void pointupdate(){
if (player)
        {
         point=gameObject.NearserchTag("Enemy").root().transform;
        }else
        {
            point=gameObject.NearserchTag("Player").pclass().PlayerControll.transform;
           
        }

if (point.gameObject.cclass().anim.GetBool("dead"))
            {
                point=transform;
            }
           
         
}
int nowhp;
    // Start is called before the first frame update
    void Start()
    {
         if (player)
              {
                   alwayschaise=false;
gameObject.Childremovecomponentandattach<enemyattack,attackunitychan>();
gameObject.removecomponentandattach<enemyhp,hp>().HP=nowhp;
              }
agent = GetComponent<NavMeshAgent>();
anim = GetComponent<Animator> ();
enemyhp=GetComponent<enemyhp>().basehp;
nowhp=enemyhp.HP;
             

    }


public void randomposition(){
currentpatrollposition=transform.position+ keikei.randomvectornotY(patrollarea);
    agent.destination=currentpatrollposition;

}


public void newposition(){

if (once)
{
    agent.speed=speed;
    once=false;
}
pointupdate();



 SetDestination();
   
             
}

public float closedistancerate;
public void SetDestination(){
 agent.destination=point.position+(transform.position-point.position).normalized;
 
}

public void stop(){
    if (!once)
    {
speed=agent.speed;
 agent.speed=0;
once=true;
    }   
}


 void meleeattack(){
if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
return;
              
foreach (var item in waza.wazalist)
{
    if (item.wazachange!=null)
    {
        waza=item.wazachange;
    }
    
    if (keikei.kakuritu(item.kakuritu)&&!anim.GetBool(item.name)&&item.mindis*item.mindis<=agentdestinationdis&&agentdestinationdis<=item.maxdis*item.maxdis)
{
    anim.SetBool(item.name,true);
    anim.SetTrigger(item.name); 
   
    if (item.motions!=null)
    {
         item.motions.Play(gameObject);
   
    }
      break;
}

}
  

}

public void meleemode(){
 
         
if (agentdestinationdis<0.01f)
    {
        if (agentdestinationdis>waza.minwalk)
    {
         newposition();
    }
    }
   
    if (alwayschaise)
    {SetDestination();  }

       if (!meleeonce&&waza)
       {
            InvokeRepeating("meleeattack", 1, waza.interval);
meleeonce=true;
       }

if(!onces){ keikei.delaycall(firstdiscover,1f);

  onces=true;
    }


}




public void firstdiscover(){

   transform.LookAt(point);
   anim.SetBool(firstanim,true);
   
                if (discoverevent!=null)
                {discoverevent?.Invoke();
                    
                }

if (meleecamerachange)
{
    point.gameObject.pclass().meleecamera.Set(transform);
}

                 if (message!="")
                {
                    message.CreateMesImage(gameObject,mesPos);
                    
                    message m= point?.gameObject?.acessmessage();
                      
                    if (m!=null)
                      {
                         if (firstatractcamera)
                    {

                    m.gameObject.pclass().SetMessageAtractCamera(transform,message,null,false,cameradistance);
                    }else
                    {
                        m.SetMessagePanel(message,true,icon);
               
                    }
                      }
                   
                } 
}
public float patroltime;
public void patrolmode(){
 if (meleeonce)
       {agent.speed=patrollspeed;
          CancelInvoke();
meleeonce=false;
if (meleecamerachange)
{
    point.gameObject.pclass().meleecamera.Set(null);
}

       }
    patroltime-=Time.deltaTime;
 Vector3 Apos = transform.position;
      
patroldistance=agent.remainingDistance;
if (agent.remainingDistance<2||patroltime<0)
    {patroltime=patrolnexttime;
        randomposition();
    }
    
}
    // Update is called once per frame
    void FixedUpdate()
    {  if (enemyhp.HP==0)
    {
        return;
    }

if (point==null)
{
    pointupdate();
}
    
        if (agent.remainingDistance<waza.maxwalk||agent.remainingDistance>waza.minwalk)
        {
            
             anim.FloatTo("speed",1); 
              
        }else
        {
             anim.FloatTo("speed",0); 
                  
        }
        agentdestinationdis=(point.position-transform.position).sqrMagnitude;


        
       
  
         if(cantchasedis*cantchasedis<agentdestinationdis&agentdestinationdis<1000*1000){
            
          
             patrol=true;
         }else{
              patrol=false;
         }

         if (patrol)
         {
             patrolmode();
         }else
         {
             meleemode();
            
         }
            
                   
        
    }
}
