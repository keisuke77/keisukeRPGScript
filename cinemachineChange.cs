using UnityEngine;
using Cinemachine;
public class cinemachineChange : MonoBehaviour
{
     public CinemachineVirtualCamera _virtualCamera;
     public int INpriorty;
     public int Outpriorty;
     public float distance;
     public Transform target;
     void Update()
     {
        
            _virtualCamera.Priority =
            ((target.position-transform.position).sqrMagnitude>distance*distance)?
            Outpriorty:
            INpriorty;

     }
}