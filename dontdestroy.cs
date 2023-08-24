
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{
  public static GameObject player;
    // Start is called before the first frame update
    void Start()
    {if (player==null)
    {
        player=gameObject;

    }else
    {
keikei.datatransform();
        
        Destroy(gameObject);
    }
        
         
    }

}
