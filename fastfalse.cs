using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastfalse : MonoBehaviour
{bool once=false;
    // Start is called before the first frame update
    void Start()
    {if (!once)
    {once=true;
         gameObject.SetActive(false);
  
    }
         }

    // Update is called once per frame
    void Update()
    {
        
    }
}
