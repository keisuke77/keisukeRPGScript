using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    Rigidbody rb;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
         }
public void knockbacks(float power){
gameObject.transform.Translate(-Vector3.forward*power);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
