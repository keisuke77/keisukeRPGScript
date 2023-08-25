using UnityEngine;using UnityEngine.Events;

public class deathevent : MonoBehaviour
{public UnityEvent events;
   private void OnDestroy()
   {events.Invoke();
       
   }
   
}