using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class talk : MonoBehaviour
{Animator Animator;
public Button button;
public string messagetext;
public UnityEvent kaiwaendevents;
public Sprite defaultsprite;
public Sprite talksprite;
public bool talkable;
 keiinput keiinput;
Image defaultspriteImg;
public Vector3 ImagePos;
    // Start is called before the first frame update
    void Start()
    {
        Animator=GetComponent<Animator>();
        button=keikei.communicationbutton;
         defaultspriteImg= defaultsprite?.CreateImage(gameObject).GetComponent<Image>();
      defaultspriteImg.transform.localPosition=ImagePos;
    }

public void TalkEvent(GameObject obj){
 
         Animator.SetBool("communication",true);
         Animator.SetBool("talk",true);
         obj.pclass().playerMovePram.stop=true;
         obj.pclass().message?.SetMessagePanel(messagetext,false,null,()=>{
            
            obj.pclass().playerMovePram.stop=true;
            kaiwaendevents.Invoke();
            
            });

button.gameObject.SetActive(false);
}

void OnTriggerEnter(Collider collisionInfo)
{
    
    if(collisionInfo.gameObject.proottag()){
talkable=true;
keiinput= collisionInfo.gameObject.pclass().keiinput;
     defaultspriteImg.sprite=talksprite;
        button.gameObject.SetActive(true);
         button.GetComponent<Button>().onClick.AddListener(() => {
       TalkEvent(collisionInfo.gameObject);
return;
     });
  
}
    
}

/// <summary>
/// OnTriggerExit is called when the Collider other has stopped touching the trigger.
/// </summary>
/// <param name="other">The other Collider involved in this collision.</param>
private void OnTriggerExit(Collider collisionInfo)
{
    if(collisionInfo.gameObject.proottag()){
    talkable=false;
  defaultspriteImg.sprite=defaultsprite;
    button.GetComponent<Button>().onClick.RemoveAllListeners();
    button.gameObject.SetActive(false);
    
}}

    // Update is called once per frame
    void Update()
    {  
        transform.forward=-keiinput.gameObject.transform.forward;
         if (talkable)
        {
            if (keiinput.interaction)
            {
                TalkEvent(keiinput.gameObject);

            }
        }
    }
}
