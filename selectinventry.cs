using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectinventry : MonoBehaviour
{
public bool select;
public uichangerselect uichangerselect;
    keiinput keiinput;
    // Start is called before the first frame update
    void Start()
    {
         keiinput=gameObject.pclass().keiinput;
   
    }

    // Update is called once per frame
    void Update()
    {if (select)
    {uichangerselect.enabled=true;
        keiinput.stop=true;
        
    }else
    {uichangerselect.enabled=false;
     
        keiinput.stop=false;

    }
        
    }
}
