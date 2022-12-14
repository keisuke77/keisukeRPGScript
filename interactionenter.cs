using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;



public class interactionenter : MonoBehaviour
{
public bool cooldown;
float cooldowntime=1;
public bool once;
int count;
public interaction firstinteraction;
[HideInInspector]
public interaction nowinteraction;

void Start()
{nowinteraction=firstinteraction;
cooldowntime=1;
}





    private void OnTriggerStay(Collider other)
    {  
       if (cooldowntime>0)return;
   
      if(other.gameObject.root().CompareTag("Player")&&!gameObject.transform.root.gameObject.CompareTag("Player")){

   nowinteraction.createinteraction(this,other.gameObject); 
   once=true;
   cooldowntime=1f;
    
    }
    
    }




void OnDestroy()
    {if (once)
    {
       nowinteraction?.deleteinteraction();

    }
        
    }



    private void Update()
    {
       if (cooldowntime>0)
      {cooldowntime-=Time.deltaTime;
      cooldown=false;
   
      }else if(once)
      { 
        once=false;
        nowinteraction.deleteinteraction();

      }  
      
      }
}