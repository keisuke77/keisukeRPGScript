using UnityEngine;
using UnityEngine.Events;

public class DestroyEvent : MonoBehaviour
{
    public UnityEvent events;

    private void OnDestroy()
    {
        events.Invoke();
    }
}
