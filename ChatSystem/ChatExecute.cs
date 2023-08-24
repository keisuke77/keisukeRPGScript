using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChatExecute : MonoBehaviour
{
    public ChatData ChatData;
    public message message;
    public bool Autostart;
    public static ChatExecute instance;
    public int interval=2;
    
    System.Action EndCallBack;
    void Start()
    {
        instance = this;
        if (Autostart)
        {
            Play();
        }
    }

    public void Play()
    {
        Execute(ChatData);
    }

    public void Execute(ChatData ChatData, System.Action EndCall = null)
    {
       StartCoroutine(Execute(ChatData.phases, 0, EndCall));
    }
  public void Executes(List<phase> phases, int num = 0, System.Action EndCall = null)
    {
StartCoroutine(Execute(phases, num, EndCall));
  
    }
    public IEnumerator Execute(List<phase> phases, int num = 0, System.Action EndCall = null)
    {
    
        if (EndCall!=null)
        {
            EndCallBack=EndCall;
        }
Debug.Log("num"+num+"Count"+phases.Count);
        if (num >= phases.Count)
        {
            if(EndCallBack!=null){
            EndCallBack();
        EndCallBack=null;
        
        }
               yield break;
        }

        var phase = phases[num];
        System.Action Action;

        if (phase.SelectionPhases.Count > 1)
        {
            Action = () =>
            {     message.StopUodate=true;
                SelectCreate(phase.SelectionPhases);
                message.isMessageing=true;
            };
        }
        else
        {
            Action = () => StartCoroutine(this.Execute(phases, num + 1));
        }
 yield return new WaitForSeconds(Time.deltaTime);
        message.SetMessagePanel(
            phase.message,
            false,
            phase.ChatCharactor?.icon,
            Action,
            phase.ChatCharactor?.name
        );
        yield return null;
    }

    public GameObject TwoSelectObj;
    public GameObject ThreeSelectObj;
    public GameObject fourSelectObj;

    public void SelectCreate(List<SelectionPhase> SelectionPhases)
    {
        GameObject instance = null;
        int n = 0;
        switch (SelectionPhases.Count)
        {
            case 2:
                instance = Instantiate(TwoSelectObj, transform.position, transform.rotation);
                break;
            case 3:
                instance = Instantiate(ThreeSelectObj, transform.position, transform.rotation);
                break;
            case 4:
                instance = Instantiate(fourSelectObj, transform.position, transform.rotation);
                break;
            default:
                break;
        }
        instance.transform.parent = message.gameObject.transform;
        n = 0;
        foreach (var item in instance.GetComponentsInChildren<Text>())
        {
            item.text = SelectionPhases[n].text;
            n++;
        }
        n = 0;
        foreach (var item in instance.GetComponentsInChildren<Button>())
        {
            var phases = SelectionPhases[n].phases;
            item.onClick.AddListener(() =>
            {  message.isMessageing=false;
            
            Executes(phases, 0);
 Destroy(instance);
 
        message.StopUodate=false;
          
                   });
            n++;
        }
    }
}
