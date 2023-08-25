using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class find : MonoBehaviour
{
   public GameObject brick;
    // Start is called before the first frame update
    void Start()
    {
       brick = GameObject.Find("Brick");
       Debug.Log(brick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
