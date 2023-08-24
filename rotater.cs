using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater : MonoBehaviour
{
    public float maxPitch=60;
    public float speed=1;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x= x-Input.GetAxis("Mouse X");
             y=Mathf.Clamp(y, -maxPitch, maxPitch);
y=y-Input.GetAxis("Mouse Y");

        transform.rotation = Quaternion.Euler(y*speed, -x*speed, 0);
    }
}
