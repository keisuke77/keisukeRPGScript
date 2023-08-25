using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamer : MonoBehaviour
{
    public GameObject beam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(beam,transform.position+new Vector3(0,0.5f,0),transform.rotation);
        }
    }
}
