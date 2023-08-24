using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moucecamera : MonoBehaviour
{
    public float mouse_y_delta;
public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse_y_delta = Input.GetAxis("Mouse Y");
        var angels=camera.transform.rotation.eulerAngles;
        angels.x+=mouse_y_delta;
       angels.x=Mathf.Clamp( angels.x,-20 ,30) ;
        camera.transform.rotation=Quaternion.Euler(angels);
    }
}
