using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class uicontroller : MonoBehaviour
{


     public enum UIkind
    {
        pop,scalechange,rotate,buttonscalechange,move
    }
    public UIkind UIKind;

public Vector3 vector;
public bool loop;
    Vector3 oripos;
    public bool Awakestart;
 RectTransform my;
 public float time=1;
 public float hight=50;

void OnEnable()
{ if (Awakestart)
        {
        execute(loop);
        }
    
}
void Awake()
{
    oripos=transform.position;
}
void OnDisable()
{
    transform.position=oripos;
}

    // Start is called before the first frame update
    void Start()
    {my=GetComponent<RectTransform>();
       if (Awakestart)
        {
        execute(loop);
        }
    }

    
public void execute(){
switch (UIKind)
{
    case UIkind.pop:  my.DOJumpAnchorPos(
    my.position, // 移動終了地点
    hight,                    // ジャンプの高さ
    1,                     // ジャンプの総数
    time                 // 演出時間
);
        break;
        case UIkind.scalechange:

        my.DOScale (
    Vector3.one,　　//終了時点のScale
    time 　　　　　　//時間
    );
        break; 
        case UIkind.move:

        my.DOAnchorPos(
    vector,　　//終了時点のScale
    time 　　　　　　//時間
    ).SetEase(Ease.OutBounce);
        break;
        case UIkind.rotate:
 my.DOLocalRotate(vector * 360f,time, RotateMode.FastBeyond360);
 
        
        break;
        case UIkind.buttonscalechange:

        my.DOScale (
    vector+Vector3.one,　　//終了時点のScale
    time 　　　　　　//時間
    ).OnComplete(() => my.DORewind());
        break;
       
    default:
        break;
}

  
}

public void execute(bool loop){
if (!loop)
{
    execute();
    return;
}


switch (UIKind)
{
    case UIkind.pop:  my.DOJumpAnchorPos(
    my.position, // 移動終了地点
    hight,                    // ジャンプの高さ
    1,                     // ジャンプの総数
    time                 // 演出時間
).SetLoops(-1, LoopType.Yoyo);
        break;
          case UIkind.move:

        my.DOAnchorPos (
    vector,　　//終了時点のScale
    time 　　　　　　//時間
    ).SetLoops(1, LoopType.Yoyo);
        break;
        case UIkind.scalechange:

        my.DOScale (
    vector+Vector3.one,　　//終了時点のScale
    time 　　　　　　//時間
    ).SetLoops(-1, LoopType.Yoyo);
        break;
        case UIkind.rotate:
 my.DOLocalRotate(vector * 360, time, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart);
 
        
        break;case UIkind.buttonscalechange:

        my.DOScale (
   vector+Vector3.one,　　//終了時点のScale
    time 　　　　　　//時間
    ).SetLoops(1, LoopType.Yoyo);
        break;
      
    default:
        break;
}

  
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
