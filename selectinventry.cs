using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
namespace ItemSystem
{
    public class selectinventry : MonoBehaviour
    {
        public bool select;
        public uichangerselect uichangerselect;

        // Update is called once per frame
        void Update()
        {
            if (select)
            {
                uichangerselect.enabled = true;
                keiinput.Instance.stop = true;
            }
            else
            {
                uichangerselect.enabled = false;

                keiinput.Instance.stop = false;
            }
        }
=======
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
        
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    }
}
