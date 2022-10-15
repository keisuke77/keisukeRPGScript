using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timelineexecute : MonoBehaviour
{
   public timelinemanager timelinemanager;
   public int num;
   public bool Awake;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (Awake)
        {
            timelinemanager.EventPlay(num);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
