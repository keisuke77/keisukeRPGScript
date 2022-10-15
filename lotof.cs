using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lotof : MonoBehaviour
{
    public int length ;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < length; i++)
        {
            
            for (var y = 0; y < length; y++)
            {
                for (var z = 0; z < length; z++)
                {
                    Instantiate(obj,obj.transform.position+new Vector3(i,y,z),Quaternion.identity);
    
                }
            }
            
                }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
