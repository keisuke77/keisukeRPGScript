using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using UnityEngine.EventSystems;
using DG.Tweening;
namespace GIE
{

   
public class Chest : MonoBehaviour
{
   public itemdrop itemdrop;
   public int mItemNumber;
   public string mItemName;
      public bool isOpen = false;
    GameObject obj;
    public Animator anim;
  public data data;
   public GetItemEffectType mGetItemEffectType = GetItemEffectType.Explostion_First;
   
  public bool threed;
  BaseEventData eventDatas;

  private void Start()
  {
      anim= GetComponent<Animator>();
  }
  
    IEnumerator Flashing(float count,float time){
    float i=0;
        while (count>i) { yield return new WaitForSeconds(time);
        
            i++;
                  gameObject.SetActive(!gameObject.activeSelf);
                 
            } 
      yield break;
        }

        
           
  public void OnClick3DObject( BaseEventData eventData )
        { 
        Debug.Log("USwidshiafoewjq ");

        
       StartCoroutine ("OpenChest");

              }

    public void Open(){
 StartCoroutine ("OpenChest");


    }
    
public void itemdrops(){
    if (threed)
            {
                 GetItemEffect_3D.mInstance.GetItem(mItemName, mItemNumber,transform.position, null);
         
            }else
            {
                  GetItemEffect.mInstance.GetItem(mItemName, mItemNumber,  transform.position
        , null, mGetItemEffectType);

            }
            


              
           data.money+=mItemNumber;

}


    public IEnumerator OpenChest()
    {if(isOpen==true)yield break;


         this.transform.DOShakePosition(duration: 1.0f, strength: 0.5f, vibrato: 10, randomness: 10,snapping:false);
        yield return new WaitForSeconds(1.0f);
        this.transform.DOShakeRotation(duration: 1.0f);
 yield return new WaitForSeconds(1.0f);
      
    
       
        
        isOpen = true;

       
       anim.Play("Open");
        GetComponent<AudioSource>().Play();
     
 yield return new WaitForSeconds(anim.GetAnimationClipLength("Open") );
if (itemdrop!=null)
            {
                gameObject.itemdroper(itemdrop);
                
            }

StartCoroutine (Flashing(10,1));
    
            
    }
}
}