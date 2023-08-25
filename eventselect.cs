using UnityEngine;

using UnityEngine.Events;

using UnityEngine.UI;

<<<<<<< HEAD
=======

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
public class eventselect : MonoBehaviour
{
    [System.Serializable]
    public class eventselectdecide
<<<<<<< HEAD
    {
        public UnityEvent select;
        public UnityEvent decide;
    }

    public eventselectdecide[] eventselectdecides;
    public UnityEvent beforeselectevent;
    public int num;

    private void Start()
    {
        num += (eventselectdecides.Length * 100000);
    }

    void select()
    {
        beforeselectevent.Invoke();
        eventselectdecides[num % eventselectdecides.Length].select.Invoke();
    }

    void decide()
    {
        eventselectdecides[num % eventselectdecides.Length].decide.Invoke();
    }

    void Update()
    {
        if (keiinput.Instance.add)
        {
            num++;
            select();
        }
        if (keiinput.Instance.decide)
        {
            decide();
        }
        if (keiinput.Instance.down)
        {
            num--;
            select();
        }
    }
}
=======
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
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
