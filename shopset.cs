using UnityEngine;using UnityEngine.UI;



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
