using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.PostProcessing;

using UnityEngine.Events;

public class underwater : MonoBehaviour
{
    public bool iswater;
    public Camera camera;
    public UnityEvent enterevents;
    public UnityEvent exitevents;
bool once;
public PostProcessingProfile waterprofile;
PostProcessingProfile defaults;
public PostProcessingBehaviour PostProcessingBehaviour;
public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        anim=gameObject.cclass().anim;
=======
        anim=GetComponent<Animator>();
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
        
    }

void OnTriggerEnter(Collider other)
{if (other.gameObject.CompareTag("water"))
{
    iswater=true;
}
}
void OnTriggerExit(Collider other)
{if (other.gameObject.CompareTag("water"))
{
    iswater=false;
}
}

    // Update is called once per frame
    void Update()
    {
    
if (iswater)
{anim.SetBool("swimming",true);
 
if (!once)
{gameObject.GetComponent<IForceIdle>().AddForce(-Vector3.up);
    enterevents?.Invoke();
    camera.transform.position=gameObject.transform.position;
 defaults  =PostProcessingBehaviour.profile;
       PostProcessingBehaviour.profile=waterprofile;
   once=true;
}
}else
{
if (once)
{
    exitevents?.Invoke();
   camera.transform.position=gameObject.transform.position;
   once=false;
}
    
   anim.SetBool("swimming",false);
  PostProcessingBehaviour.profile=defaults;
}



        
    }
}
