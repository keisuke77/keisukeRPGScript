using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using UnityEngine.EventSystems;

public class buttonstrong : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curve;
    Button button;
    bool once;
    public EventTrigger aa;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

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
