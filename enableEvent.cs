using UnityEngine;

using UnityEngine.Events;
public class enableEvent : MonoBehaviour
{
private void OnEnable() {
    enaeve.Invoke();
}private void OnDisable() {
      disaeve.Invoke();
}
public UnityEvent enaeve;
public UnityEvent disaeve;
 
}