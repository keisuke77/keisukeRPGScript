using UnityEngine;

public class UIcameralook : MonoBehaviour
{Transform cam;
Transform trans;
     
     private void Start() {
          
           cam=Camera.main.transform;
            trans=transform;
     }
     
     void Update()
{
     trans.forward=cam.forward;
}
   
}