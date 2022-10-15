using UnityEngine;using UnityEngine.UI;

public class shop : MonoBehaviour
{int a;
public static Sprite sprites;
public static GameObject opener;
public Transform sellitemlist;
public static Canvas canvas;
bool once;

    public static iteminventory shopinventory;
    public static string message;
    void Awake()
    {
     
      canvas=GetComponent<Canvas>();
      canvas.enabled=false;
      
    }
public void active()
{
  opener.playerstop();
  opener.acessmessage().SetMessagePanel(message,true);
GetComponent<Image>().sprite=sprites;
   foreach (var items in shopinventory.GetmyItemLists())
{
      sellitemlist.GetChild(a).GetComponent<itemsell>().itemset(items,a);
a++;
}
a=0;
}  

void Update()
{if (canvas.isActiveAndEnabled&&!once)
{active();
  once=true;
}
//時間経過でショップがフェードするため

if(once&&!canvas.isActiveAndEnabled)
{
  noactive();
  once=false;
}
  
}

public void returns(){


  canvas.fadeinout(false);
}
private void noactive() {
  
      
  Time.timeScale=1;
  opener.GetComponent<UnityChanControlScriptWithRgidBody>().stop=false;
}

}
 

