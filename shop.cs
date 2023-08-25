using UnityEngine;using UnityEngine.UI;

<<<<<<< HEAD
using ItemSystem;
=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
public class shop : MonoBehaviour
{int a;
public static Sprite sprites;
public static GameObject opener;
public Transform sellitemlist;
public static Canvas canvas;
<<<<<<< HEAD
public bool once;
=======
bool once;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

    public static iteminventory shopinventory;
    public static string message;
    void Awake()
    {
<<<<<<< HEAD
      canvas=GetComponent<Canvas>();
      canvas.enabled=false;
    }
public void active()
{ 
  opener.root().playerstop();
  opener.acessmessage().SetMessagePanel(message,true);
GetComponent<Image>().sprite=sprites;
a=0;
=======
     
      canvas=GetComponent<Canvas>();
      canvas.enabled=false;
      
    }
public void active()
{
  opener.playerstop();
  opener.acessmessage().SetMessagePanel(message,true);
GetComponent<Image>().sprite=sprites;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
   foreach (var items in shopinventory.GetmyItemLists())
{
      sellitemlist.GetChild(a).GetComponent<itemsell>().itemset(items,a);
a++;
}
<<<<<<< HEAD
=======
a=0;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}  

void Update()
{if (canvas.isActiveAndEnabled&&!once)
<<<<<<< HEAD
{
  once=true;
  active();
  
=======
{active();
  once=true;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}
//時間経過でショップがフェードするため

if(once&&!canvas.isActiveAndEnabled)
{
  noactive();
  once=false;
}
  
}
<<<<<<< HEAD
void OnDisable()
{
  
}
=======

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
public void returns(){


  canvas.fadeinout(false);
}
<<<<<<< HEAD
private void noactive() {    
  
  Time.timeScale=1;
   
  opener.pclass().playerMovePram.stop=false;
=======
private void noactive() {
  
      
  Time.timeScale=1;
  opener.GetComponent<UnityChanControlScriptWithRgidBody>().stop=false;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}

}
 

