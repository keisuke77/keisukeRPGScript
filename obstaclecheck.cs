using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclecheck : MonoBehaviour
{
    public camerachange camerachange;
    public Transform Target;
    private RaycastHit hit;
    public distance distancek;
    public GameObject tes;
    int a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          var diff = Target.position - transform.position;
            var distance = diff.magnitude;
            var direction = diff.normalized;

            if(Physics.Raycast(transform.position, direction, out hit, distancek.distances))
            {if (hit.transform.gameObject!=Target.gameObject&&hit.transform.gameObject.name!="Terrain")
            {
               tes=hit.transform.gameObject;
camerachange.active=4; 
            }else {camerachange.active=0;
            }}
            
    }
}
