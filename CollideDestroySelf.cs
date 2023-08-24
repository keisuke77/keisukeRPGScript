using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDestroySelf : MonoBehaviour
{
  public string tags;
  public float DestroySpeed=0.2f;
    // Update is called once per frame
 
       void OnCollisionEnter(Collision collision)
    {
        
    if (collision.gameObject.tag == tags)
		{
			// 0.2秒後に消える
			Destroy(gameObject, DestroySpeed);
		}
        
    }
       
}
