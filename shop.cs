using UnityEngine;using UnityEngine.UI;

using ItemSystem;
public class shop : MonoBehaviour
{int a;
public static Sprite sprites;
public static GameObject opener;
public Transform sellitemlist;
public static Canvas canvas;
public bool once;

    public static iteminventory shopinventory;
    public static string message;
    void Awake()
    {
      canvas=GetComponent<Canvas>();
      canvas.enabled=false;
    }
public void active()
{ 
  opener.root().playerstop();
  opener.acessmessage().SetMessagePanel(message,true);
GetComponent<Image>().sprite=sprites;
a=0;
   foreach (var items in shopinventory.GetmyItemLists())
{
      sellitemlist.GetChild(a).GetComponent<itemsell>().itemset(items,a);
a++;
}
}  

void Update()
{if (canvas.isActiveAndEnabled&&!once)
{
  once=true;
  active();
  
}
//時間経過でショップがフェードするため

if(once&&!canvas.isActiveAndEnabled)
{
  noactive();
  once=false;
}
  
}
void OnDisable()
{
  
}
public void returns(){


  canvas.fadeinout(false);
}
private void noactive() {    
  
  Time.timeScale=1;
   
  opener.pclass().playerMovePram.stop=false;
}

}
 

