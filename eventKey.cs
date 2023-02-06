using UnityEngine;

using UnityEngine.Events;
public class eventKey : MonoBehaviour
{
public KeyCode key;
    
    public UnityEvent eve;
    void Update()
    {
        if (key.keydown())
        {
            eve.Invoke();
        }
    }
}