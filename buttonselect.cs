using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class buttonselect : MonoBehaviour
{public Button[] buttons;
public keiinput keiinput;
public int num;
 Vector3 basescale;
    // Start is called before the first frame update
    void Start()
    {num=100000;
        basescale=buttons[0].transform.localScale;
    }

   void reset(){
foreach (var item in buttons)
{
   
    item.transform.DOScale(basescale,0.2f);
}

   }
   void select(){
    reset();
 
 buttons[num%buttons.Length].transform.DOScale(basescale*1.2f,0.2f);
   }


   void decide(){
 buttons[num%buttons.Length].onClick.Invoke();
 
foreach (var item in buttons)
{
    item.transform.DOScale(0,0.1f);
}
  }
    // Update is called once per frame
    void Update()
    {
        
if (keiinput.add)
{
	num++;
   select();
}
if (keiinput.decide)
{
	decide();
}
if (keiinput.down)
{num--;
	 select();
}
			
	}
    }

