using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracut : MonoBehaviour
{

public Transform aircamera;
Transform Player;
public distance dis;
public float maxdis=20;
    // Start is called before the first frame update
    void Start()
    {Player=GameObject.Find("unitychan").transform;
        
        
    }
public void cutcamera()
{
transform.parent=null;

}
public void setcamera(){

transform.parent=Player;
transform.position=aircamera.position;transform.rotation=aircamera.rotation;transform.localScale=aircamera.localScale;
}
    // Update is called once per frame
    void Update()
    {if (dis.distances>maxdis)
    {setcamera();
        
    }
     if (Input.GetKeyDown(KeyCode.F))
     {
         cutcamera();
     }   
    }
}
