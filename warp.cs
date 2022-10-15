using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    

public warpdata warpdata;
public bool once;
    // Start is called before the first frame update
  
void OnTriggerEnter(Collider other)
{if (other.gameObject.CompareTag("Player")&&!once)
{once=true;
    warpdata.warps(other.gameObject);
   }
    }

   
    // Update is called once per frame
  
}
