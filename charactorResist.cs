using UnityEngine;using UnityEditor;

public class charactorResist : MonoBehaviour
{
    
   public character character;

   public ChatCharactor ChatCharactor;

public void Set(){
   gameObject.root().GetComponent<charactorchange>().charactorchanger(character);
  
}
 
 
   void Awake()
   {
     
      
      if (gameObject.root().GetComponent<charactorchange>() !=null)
   {if (ChatCharactor!=null)
   {
       character.ChatCharactor=ChatCharactor;
 
   }
       gameObject.root().GetComponent<charactorchange>().characters.Add(character);
   }





   }
}