using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
private void OnEnable()
{
    
    Time.timeScale=0;
}
private void OnDisable()
{
    
    Time.timeScale=1;
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
