using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataload : MonoBehaviour
{
   public GameObject player;
   public bool load =true;
    // Start is called before the first frame update
    void Awake()
    {

  Vector3 pos= player.transform.position;

        if (load&&PlayerPrefs.HasKey("PlayerX"))
        {
             Vector3 newPosition = Vector3.zero;
 newPosition.x = PlayerPrefs.GetFloat("PlayerX");
 newPosition.y = PlayerPrefs.GetFloat("PlayerY");
 newPosition.z = PlayerPrefs.GetFloat("PlayerZ");
 player.transform.position = newPosition;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
