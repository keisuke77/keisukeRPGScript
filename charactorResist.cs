using UnityEngine;

public class charactorResist : MonoBehaviour
{
    
   public character character;

   void Start()
   {if (gameObject.cclass().charactorchange!=null)
   {
    gameObject.cclass().charactorchange.characters.Add(character);
   }
   }
}