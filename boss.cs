using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public navchaise nav;
    public float randomq;
    public GameObject magic;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("updates",3);
    }

void updates(){

randomq=Random.value;
Invoke("updates",1);
}


}
