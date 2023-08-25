using UnityEngine;
using UnityEngine.Events;
<<<<<<< HEAD
using ItemSystem;
=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
public class itemuseplace : MonoBehaviour
{
   public Itemkind Itemkind;
   public UnityEvent Action;
   [HideInInspector]
   public UnityEvent eve;
   public UnityEvent colleve;
public GameObject img;
    string mes;
    void Start()
    {mes=Itemkind.GetItemName()+"をここで使いますか？";
        eve.AddListener(()=>{
            mes.yesno(()=>Action.Invoke());
            
            });
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.proottag())
        {collisionInfo.gameObject.pclass().itemuseplace=this;
            colleve.Invoke();
            if (img==null)
            {
                   img= Itemkind.GetIcon().CreateImage(collisionInfo.gameObject,Vector3.up*2).gameObject;
     
            }
           }
    } 
    
     void OnTriggerExit(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.proottag())
        {
           collisionInfo.gameObject.pclass().itemuseplace=null;
         Destroy(img);
             }
    }

}