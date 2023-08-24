using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI_InputSystem.Base;

public class keiinput : Singleton<keiinput>
{
  
    public bool attack;
    public bool attackduring;
    public bool attackup;
    public bool dash;
    public bool dashduring;
    public bool dashup;
    public bool jump;  public bool jumpup;
    public bool Throw;
    public bool interaction;
    public bool interactionduring;
    public bool interactionup;
    public bool add;
    public bool down;
    public bool hissatu;
    public bool decide;

    public bool guard;
    public bool guardup;
    public Button attackbutton;
    public Button jumpbutton;
    public Button throwbutton;
    public Vector2 directionkey;
    public Vector2 rotationkey;
    public inputsetting inputsetting;
    public float time = 0.1f;
    WaitForSeconds wait;
    public bool inputsystemnew;
    public bool stop;



    void Awake()
    {
      if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
 
        DontDestroyOnLoad(gameObject);
 
         }

    public Vector2 GetDpad()
    {
        return directionkey;
    }

    public Vector2 GetRotate()
    {
        return new Vector3(
            inputsetting.rotatehorizonaxis.GetAxis(),
            inputsetting.rotateverticalaxis.GetAxis(),
            0
        );
    }

    private void OnDisable()
    {
        gameObject.GetComponent<keiinput>().enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (stop)
        {
            return;
        }
   
        attackbutton?.onClick.AddListener(() =>
        {
            attackupa();
        });
        jumpbutton?.onClick.AddListener(() =>
        {
            jumpa();
        });
        throwbutton?.onClick.AddListener(() =>
        {
            throwa();
        });
        wait = new WaitForSeconds(time);
    }

    IEnumerator functionName()
    {
        yield return null;
    }

    public void attacka()
    {
        if (stop)
        {
            return;
        }
        StartCoroutine("attacks");
    }

    public void attackupa()
    {
        if (stop)
        {
            return;
        }
        StartCoroutine("attackups");
    }

    public void jumpa()
    {
        if (stop)
        {
            return;
        }
        StartCoroutine("jumps");
    }

    public void throwa()
    {
        if (stop)
        {
            return;
        }
        StartCoroutine("throws");
    }

    public IEnumerator attacks()
    {
        attack = true;
        yield return wait;
        attack = false;
        yield return null;
    }

    public IEnumerator attackups()
    {
        attackup = true;
        yield return wait;
        attackup = false;
        yield return null;
    }

    public IEnumerator jumps()
    {
        jump = true;
        yield return wait;
        jump = false;
        yield return null;
    }

    public IEnumerator throws()
    {
        Throw = true;
        yield return wait;
        Throw = false;
        yield return null;
    }

    public string[] ControllerConnectionNames;

    // Update is called once per frame

   public Vector2 TryGetDpad()
    {
        try
        {
            return new Vector2(
                (float)inputsetting?.horizonaxis?.GetAxis(),
                (float)inputsetting?.verticalaxis?.GetAxis()
            );
        }
        catch (System.Exception e)
        {
            return Vector2.zero;
        }
    }
    public Vector2 TryGetRpad()
    {
        try
        {
            return new Vector2(
                (float)inputsetting?.rotatehorizonaxis?.GetAxis(),
                (float)inputsetting?.rotateverticalaxis?.GetAxis()
            );
        }
        catch (System.Exception e)
        {
            return Vector2.zero;
        }
    }

    public float GetAxis(controll input)
    {
        switch (input)
        {
            case controll.horizonaxis:
                return directionkey.x;
            case controll.verticalaxis:
                return directionkey.y;
            case controll.rotatehorizonaxis:
                return rotationkey.x;
            case controll.rotateverticalaxis:
                return rotationkey.y;
            default:
                return 0;
        }
    } public bool GetKey(controll input)
    {
        switch (input)
        {
            case controll.attackkey:
                return attack; 
                case controll.none:
                return false;
            case controll.dashkey:
                return dash;
            case controll.jumpkey:
                return jump;
            case controll.hissatukey:
                return hissatu; case controll.guardkey:
                return guard; case controll.throwkey:
                return Throw; case controll.interactionkey:
                return interaction; case controll.addkey:
                return add; case controll.downkey:
                return down; case controll.decidekey:
                return decide; 
                
                 case controll.attackkeyup:
                return attackup;
            case controll.dashkeyup:
                return dashup;
            case controll.jumpkeyup:
                return jumpup;
            case controll.guardkeyup:
                return guardup; case controll.interactionkeyup:
                return interactionup; 
            default:
                return false;
        }
    }
    void Update()
    {
        ControllerConnectionNames = Input.GetJoystickNames();

        if (stop)
        {
            return;
        }
    directionkey = TryGetDpad();
       rotationkey= TryGetRpad();
  
  if (UIInputSystem.ME != null){
    Vector2 Check=UIInputSystem.ME.GetAxis(JoyStickAction.Movement);
          if (Check != Vector2.zero)
        { directionkey=Check;
        }
        Check=UIInputSystem.ME.GetAxis(JoyStickAction.CameraLook);
          if (Check != Vector2.zero)
        { rotationkey=Check;
        }
     
            }


                 
        if (dash)
        {
            dashduring = true;
        }
        if (dashup)
        {
            dashduring = false;
        }
        if (interaction)
        {
            interactionduring = true;
        }
        if (interactionup)
        {
            interactionduring = false;
        }
        if (attack)
        {
            attackduring = true;
        }
        if (attackup)
        {
            attackduring = false;
        }

        interaction = inputsetting.interactionkey.keydown();
        interactionup = inputsetting.interactionkey.keyup();
        add = inputsetting.addkey.keydown();
        down = inputsetting.downkey.keydown();
        decide = inputsetting.decidekey.keydown();
        dash = inputsetting.dashkey.keydown();
        dashup = inputsetting.dashkey.keyup();
        attack = inputsetting.attackkey.keydown();
        attackup = inputsetting.attackkey.keyup();
        guard = inputsetting.guardkey.keydown();
        guardup = inputsetting.guardkey.keyup();
        Throw = inputsetting.throwkey.keydown();
        jump = inputsetting.jumpkey.keydown();
        jumpup=inputsetting.jumpkey.keyup();
        hissatu = inputsetting.hissatukey.keydown();
    }
}


[System.Serializable]
public class AnimBoolName
{
    public Animator Anim;
    public string attack;

    public string dash;

    public string jump;
    public string Throw;
    public string interaction;

    public string add;
    public string down;
    public string hissatu;
    public string decide;


    void Key(keiinput keiinput){

  

    }
  public void Update(keiinput keiinput)
{ 
    if (keiinput.attack)
    {
        Anim.SetTrigger(attack);
    }
    if (attack != "")
        Anim.SetBool(attack, keiinput.attackduring);
    
    if (dash != "")
        Anim.SetBool(dash, keiinput.dashduring);
    
    if (jump != "")
        Anim.SetBool(jump, keiinput.jump);
    
    if (Throw != "")
        Anim.SetBool(Throw, keiinput.Throw);
    
    if (interaction != "")
        Anim.SetBool(interaction, keiinput.interaction);
    
    if (add != "")
        Anim.SetBool(add, keiinput.add);
    
    if (down != "")
        Anim.SetBool(down, keiinput.down);
    
    if (hissatu != "")
        Anim.SetBool(hissatu, keiinput.hissatu);
    
    if (decide != "")
        Anim.SetBool(decide, keiinput.decide);
}


}
