using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{

    public Sprite selectimage;
    public Sprite defaultimage;
public Button[] buttons; 
public Transform parent;
public Color selectcolor;
public Color defaultcolor;
public int active;
   public keiinput keiinput;

private void Start() {
   keiinput=gameObject.pclass().keiinput;
    reset();
}
void reset(){
   if (parent!=null)
   { 
buttons=parent.GetComponentsInChildren<Button>();
   }
  foreach (var item in buttons)
    {
         item.GetComponent<Image>().color=defaultcolor;
      item.GetComponent<Image>().sprite=defaultimage;
       
    }
}
 void OnSelect()
    {
       reset();
     
       buttons[active].GetComponent<Image>().color=selectcolor;
         buttons[active].GetComponent<Image>().sprite=selectimage;
           }


      void OnClick()
    { 
         
         
            buttons[active].onClick.Invoke();
         }


public void add(){
++active;OnSelect();
	
}


public void set(int num){
active=num;
OnSelect();
	
}
public void down(){
active--;OnSelect();
}
    	void Update () {


if (keiinput.add)
{
	add();
}
if (keiinput.down)
{
	down();
}
if (keiinput.decide)
{
	OnClick();
} 





		if (active>=buttons.Length)
		{
			active=0;
	OnSelect();
		}	if (active<=-1)
		{
			active=buttons.Length-1;
		OnSelect();
		}
	
						
	}

}