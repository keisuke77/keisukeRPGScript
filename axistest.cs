using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axistest : MonoBehaviour
{
    public float h;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {h = Input.GetAxis ("Horizontal");
        
    }
}
