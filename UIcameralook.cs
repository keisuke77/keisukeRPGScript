using UnityEngine;

public class UIcameralook : MonoBehaviour
{Transform cam;
Transform trans;
     
<<<<<<< HEAD
     void Start() {
=======
     private void Start() {
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
          
           cam=Camera.main.transform;
            trans=transform;
     }
     
     void Update()
{
     trans.forward=cam.forward;
}
   
}