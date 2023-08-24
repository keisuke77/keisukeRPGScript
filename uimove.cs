using UnityEngine;
using DG.Tweening;

public class uimove : MonoBehaviour
{
     Transform trans;
    public Vector2 pos;
    public Vector2 from;
    public bool pause;
    public pauses pauses; 
public bool once;
    private void Awake()
    {
        trans=gameObject.transform;
        pos=trans.localPosition;
    }
    void OnEnable()
    {
        if (pause)
    {
        trans.DOKill();
trans.position = from;
   trans.DOLocalMove(pos, 0.5f).OnComplete(() => pauses.OnPause());
  
    }else
    {
         trans.DOKill();
trans.position = from;
   trans.DOLocalMove(pos, 0.5f);
  
    }
       
    }
    

public void disabled(){



}
public void end(){

      trans.DOKill();
   trans.DOMove(from, 0.5f).OnComplete(() => gameObject.SetActive(false));

}

    private void OnDisable() {

if (once)
{
    return;
}
gameObject.SetActive(true);

once=true;

 if (pause)
        {  pauses.OnResume();
}
        
            
        }
    }
     
