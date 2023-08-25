using UnityEngine;using UnityEngine.UI;


<<<<<<< HEAD
using ItemSystem;
=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

[CreateAssetMenu(fileName = "shopset", menuName = "shop")]
public class shopset : ScriptableObject
{

public Sprite sprites;
    public iteminventory shopinventory;
    public string message;


    
  public void open(GameObject obj){
      shop.opener=obj;
      shop.sprites=sprites;
      shop.shopinventory=shopinventory;
      shop.message=message;
      shop.canvas.fadeinout(true);
      
  }
}
