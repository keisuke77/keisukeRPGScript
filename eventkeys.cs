using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;
public class eventkeys : MonoBehaviour
{

[System.Serializable] 
public class eventKey {
    
public KeyCode key;
public UnityEvent eve;

public controll controll;
public bool Up;
}

public List<eventKey> eventKeys;
    void Update()
    {
        foreach (var item in eventKeys)
        {if (!item.Up)
        {
             if (item.key.keydown())
        {if (item.eve!=null)
        {
            item.eve.Invoke();
        }
            
        }
        }else
        {
             if (item.key.keyup())
        {
          if (item.eve!=null)
        {
            item.eve.Invoke();
        }
            
        }
        }
         if (keiinput.Instance!=null){

             if (keiinput.Instance.GetKey(item.controll))
        {
            if (item.eve!=null)
        {
            item.eve.Invoke();
        }
            
        }
         }

        
           
        }
        
    }
}