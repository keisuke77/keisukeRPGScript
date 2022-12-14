using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance : MonoBehaviour
{
    public Transform target;
    public bool playerdis;
    public float distances;
    // Start is called before the first frame update
    void Start()
    {if (playerdis)
    {
        target=keikei.player.transform;
    
    }
        }

    // Update is called once per frame
    void Update()
    {
        distances=Vector3.Distance(transform.position,target.position);
    }
}
