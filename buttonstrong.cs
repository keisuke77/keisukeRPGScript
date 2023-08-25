using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using UnityEngine.EventSystems;

public class buttonstrong : MonoBehaviour
<<<<<<< HEAD
{
    [SerializeField]
    AnimationCurve curve;
    Button button;
    bool once;
    public EventTrigger aa;

=======
{[SerializeField]
AnimationCurve curve;
 Button button;
 bool once;
 public EventTrigger aa;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

<<<<<<< HEAD
    public void Click()
    {
        if (button == null)
        {
            button.enabled = false;
        }
        if (aa != null)
        {
            aa.enabled = false;
        }

        transform.DOScale(1.1f, 0.5f).SetEase(curve).OnComplete(() => aa.enabled = true);
    }
}
=======
   public void Click()
    {if (button==null)
    {
        button.enabled=false;
       
    }if (aa!=null)
    {
        aa.enabled=false;
       
    }
    
         transform.DOScale(1.1f, 0.5f).SetEase(curve).OnComplete(() => aa.enabled=true);

       }
}
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
