using UnityEngine;

public class cameraLook : MonoBehaviour
{
    public GameObject target;
    private void FixedUpdate()
    {
        gameObject.transform.LookAt(target.transform);
    }
}