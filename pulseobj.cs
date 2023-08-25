using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class pulseobj : MonoBehaviour
{public float time=1;
    private void OnEnable()
    {
        StartCoroutine("off");
    }
    IEnumerator off()
    {
         yield return new WaitForSeconds(time);
         gameObject.SetActive(false);
        yield return null;
    }
     
}