using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
public class invokemanager : MonoBehaviour
{[System.Serializable]
    public class a{

        public UnityEvent eve;
        public float time;
    }
    public a[] invokes;
float totaltime;
public bool Auto;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {if (Auto)
    {
        Play();
    }
       
    }
    public void Play(){
         foreach (var item in invokes)
        {totaltime+=item.time;
             StartCoroutine(invo(item.eve,totaltime));
        }
    }

    IEnumerator invo(UnityEvent un,float t)
    {
        yield return new WaitForSeconds(t);
        un.Invoke();
        
    }
}