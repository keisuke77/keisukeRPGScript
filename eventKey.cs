using UnityEngine;

using UnityEngine.Events;
public class eventKey : MonoBehaviour
{

public KeyCode key;

public controll controll;
public UnityEvent eve;
    void Update()
    {
        if (key.keydown())
        {
            eve.Invoke();
        }
        if (keiinput.Instance.GetKey(controll))
        {
             eve.Invoke();
        }
    }
}