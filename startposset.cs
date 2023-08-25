using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startposset : MonoBehaviour
{ GameObject Player;
 Vector3 pos;
public GameObject targetpos;
    // Start is called before the first frame update
    void Awake()
    {
       
     
    }
    void Start()
    {
       if (targetpos==null)
        {
         
        }else
        {
           pos= targetpos.transform.position;
        keikei.player.transform.position=pos;
        
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
