using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
