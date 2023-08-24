using UnityEngine;

using UnityEngine.Events;

public class StartEvent : MonoBehaviour {
    public UnityEvent Eve;
    public float delay;
    private void Awake() {
        keikei.delaycall(()=>Eve.Invoke(),delay);
    }
}