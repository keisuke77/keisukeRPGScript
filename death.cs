using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("deat",time);
    }

void deat()
{
    Destroy(gameObject);
}    // Update is called once per frame
    void Update()
    {
        
    }
}
