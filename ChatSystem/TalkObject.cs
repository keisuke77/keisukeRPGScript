using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TalkObject : MonoBehaviour
{
    public ChatData ChatData;
    public System.Action ChatEndCallBack;
    public System.Action ChatStartCallBack;
    public Sprite ChatIcon;
    public Vector3 IconPos;
    Image img;

    private void Start()
    {
        img = ChatIcon.CreateImage(gameObject).GetComponent<Image>();
        img.transform.localPosition = IconPos;
        img.enabled=false;
    }

    void OnTriggerEnter(Collider other) { 



    }
}
