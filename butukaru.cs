using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butukaru : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 
       void OnCollisionEnter(Collision collision)
    {
        
 
 
       	if (collision.gameObject.tag == "Player")
		{
			// 0.2秒後に消える
			Destroy(gameObject, 0.2f);
		}
        
    }
       
}
