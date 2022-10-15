using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using UI_InputSystem.Base;

   




public class keiinput : MonoBehaviour
{
    public bool attack;
    public bool attackduring;
    public bool attackup;
 public bool dash;
 public bool dashduring;public bool dashup;
public bool jump;
public bool Throw;public bool interaction;

public bool interactionduring;
public bool interactionup;
public bool add;public bool down;
public bool hissatu;
public bool decide;


public bool guard;public bool guardup;
public Button attackbutton;
public Button jumpbutton;
public Button throwbutton;
public Vector2 directionkey;

public inputsetting inputsetting;

public float time=0.1f;
WaitForSeconds wait;
public bool inputsystemnew;
public static keiinput Instance;
 
 public bool stop;

   void Awake()
   {
Instance=this;gameObject.pclass().keiinput=this;
   }

   public Vector2 GetDpad()
   {
    
    return directionkey;
      
   }
 public Vector2 GetRotate()
   {
    return new Vector3(inputsetting.rotatehorizonaxis.GetAxis(),inputsetting.rotateverticalaxis.GetAxis(),0);
   }

private void OnDisable()
{
      gameObject.GetComponent<keiinput>().enabled=true;
     
}
    // Start is called before the first frame update
    void Start()
    {
        if (stop)
        {return;
            
        }inputsetting=gameObject.acessdata().inputsetting;
 
         
        attackbutton?.onClick.AddListener(() => {attackupa();});
jumpbutton?.onClick.AddListener(() => {jumpa();});
throwbutton?.onClick.AddListener(() => {throwa();});
        wait=new WaitForSeconds(time);
    }IEnumerator functionName()
    {
        
        yield return null;
    }

public void attacka(){

        if (stop)
        {return;
            
        }
    StartCoroutine("attacks");
}
public void attackupa(){

        if (stop)
        {return;
            
        }
    StartCoroutine("attackups");
}
public void jumpa(){

        if (stop)
        {return;
            
        }
    StartCoroutine("jumps");
}
public void throwa(){

        if (stop)
        {return;
            
        }
    StartCoroutine("throws");
}

public IEnumerator attacks(){

attack =true;
yield return wait;
attack=false;
yield return null;
}
public IEnumerator attackups(){

attackup =true;
yield return wait;
attackup=false;
yield return null;
}
public IEnumerator jumps(){

jump =true;
yield return wait;
jump=false;
yield return null;
}
public IEnumerator throws(){

Throw =true;
yield return wait;
Throw=false;
yield return null;
}



public string[] ControllerConnectionNames;
    // Update is called once per frame

Vector3 TryGetDpad(){
 try
       {
          return new Vector3((float)inputsetting?.horizonaxis?.GetAxis(),(float)inputsetting?.verticalaxiss?.GetAxis(),0);

       }
       catch (System.Exception e)
       {
        
        return Vector2.zero;
       }
}

    void Update()
    {
        ControllerConnectionNames = Input.GetJoystickNames();

        if (stop)
        {return;
            
        }

       directionkey= TryGetDpad();
      

      if (directionkey==Vector2.zero)
 {
    directionkey=UIInputSystem.ME.GetAxis(JoyStickAction.Movement);
 }
        if (dash)
        {
            dashduring=true;
        }if (dashup)
        {
            dashduring=false;
        } if (interaction)
        {
            interactionduring=true;
        }if (interactionup)
        {
            interactionduring=false;
        } if (attack)
        {
            attackduring=true;
        }if (attackup)
        {
            attackduring=false;
    }  


Debug.Log(Input.inputString);
      interaction=inputsetting.interactionkey.keydown();
     interactionup=inputsetting.interactionkey.keyup();
       add=inputsetting.addkey.keydown();
       down=inputsetting.downkey.keydown();
       decide=inputsetting.decidekey.keydown();
       dash=inputsetting.dashkey.keydown(); 
       dashup=inputsetting.dashkey.keyup(); 
       attack= inputsetting.attackkey.keydown(); 
       attackup= inputsetting.attackkey.keyup();
       guard= inputsetting.guardkey.keydown();guardup= inputsetting.guardkey.keyup();
       Throw=inputsetting.throwkey.keydown();
       jump=inputsetting.jumpkey.keydown();   

       hissatu=inputsetting.hissatukey.keydown();
    
    }

}
