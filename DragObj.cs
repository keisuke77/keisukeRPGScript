using UnityEngine;
using UnityEngine.EventSystems;

using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using ItemSystem;


=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
public class DragObj : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private Vector2 prevPos;
    public Vector2 rootpos=new Vector3(800f,800f);
    public Collider2D Collider2D;bool once=true;
   itemmanage itemmanage;
   public iteminventory iteminventory;
  public List<Itemkind> myitemLists;
   void Start()
   { itemmanage=gameObject.pclass().itemmanage;
  
       myitemLists= iteminventory.myitemLists;
       rootpos=new Vector3(800f,800f);
       Collider2D=GetComponent<Collider2D>();
        }



private void OnTriggerEnter2D(Collider2D other)
{
    




if (once)
{


    if (other.gameObject.tag=="sell")
    {
<<<<<<< HEAD
        iteminventory.Remove(GetComponent<itemuse>()?.Itemkind);
=======
        iteminventory.Remove(GetComponent<itemuse>().Itemkind);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    }


    Debug.Log("nuduifewqernweuiaojeoiw3neujeaiojiw");
<<<<<<< HEAD
        if (other.gameObject.GetComponent<itemuse>()?.Itemkind!=null&&GetComponent<itemuse>()?.Itemkind!=null)
=======
        if (other.gameObject.GetComponent<itemuse>().Itemkind!=null&&GetComponent<itemuse>().Itemkind!=null)
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
        {myitemLists.replace<Itemkind>(other.gameObject.GetComponent<itemuse>().Itemkind,GetComponent<itemuse>().Itemkind);
       iteminventory.myitemLists=myitemLists;
       itemmanage.imagecreate();
            
        }
       
        
}
  
   }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置を記憶しておく
        prevPos = transform.localPosition;
        once=false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ドラッグ中は位置を更新する
        transform.localPosition+=(Vector3)eventData.delta*1.2f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {   // ドラッグ前の位置に戻す
     once=true;
        transform.localPosition = prevPos;
       

        
    }

}