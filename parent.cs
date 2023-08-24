using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent : MonoBehaviour
{
    
    public Transform firstparent;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {keikei.delaycall(()=>transform.parent=firstparent,delay);
        
    }

}
