using UnityEngine;

using UnityEngine.Events;

using UnityEngine.UI;


public class eventselect : MonoBehaviour
{
    [System.Serializable]
    public class eventselectdecide
{
    public UnityEvent select;
    public UnityEvent decide;
}
    public eventselectdecide[] eventselectdecides;
    public UnityEvent beforeselectevent;
   public keiinput keiinput;
public int num;
    private void Start()
    {num+=(eventselectdecides.Length*100000);
        keiinput=gameObject.pclass().keiinput;
    }
   
   void select(){
beforeselectevent.Invoke();
 eventselectdecides[num%eventselectdecides.Length].select.Invoke();
   }
   void decide(){

 eventselectdecides[num%eventselectdecides.Length].decide.Invoke();
   }
   
   void Update () {

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