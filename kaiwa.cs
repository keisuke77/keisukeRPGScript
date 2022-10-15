using UnityEngine;
using UnityEngine.Events;

public class kaiwa : MonoBehaviour
{
public string messagetext;
SpriteRenderer spriteRenderer;
public bool cooldown;
public Animation animation;
public float cooldowntime;
public bool autoprocess;
public UnityEvent kaiwaendevents;
keiinput keiinput;
void Start()
{ keiinput=gameObject.pclass().keiinput;
   
    spriteRenderer=GetComponent<SpriteRenderer>();
}
    private void OnTriggerStay(Collider other)
    {   if (other.proottag()){

     
      if(keiinput.interaction&&keikei.message.isEndMessage&&cooldown)
        {if (messagetext!="")
        { message.events=kaiwaendevents;
        
             keikei.message.SetMessagePanel(messagetext,autoprocess);
           
           
        }
              
            cooldowntime=10;

            if (animation!=null)
            {
                animation.Play("kaiwa");
            
            }
            
        }
           
    }}
    private void Update()
    {
       if (cooldowntime>0)
      {cooldowntime-=Time.deltaTime;
      cooldown=false;
   
      }else
      {
        cooldown=true;
      }  
      
      }
void OnTriggerExit(Collider other)
{       
    if (other.gameObject.CompareTag("Player")){
 spriteRenderer.enabled=false;
 
    }

}
}