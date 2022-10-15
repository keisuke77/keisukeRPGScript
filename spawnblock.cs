using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnblock : MonoBehaviour
{
    public int xlength=3;
    public int ylength=3;
    public int zlength=3;
    public Transform parent;
    public GameObject block;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < xlength; x++)
        {
            for (int y = 0; y < ylength; y++)
            {for (int z = 0; z < zlength; z++)
            {
                GameObject instance = Instantiate(block, new Vector3(x,y,z),transform.rotation);
          instance.transform.SetParent(parent);
         
          var rigid = instance.GetComponent<Rigidbody>();

         
            }
               
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
