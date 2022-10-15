using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class uipop : MonoBehaviour
{
    
    public bool auto;
 Transform my;
 public float time=1;
 public float hight=50;

    // Start is called before the first frame update
    void Start()
    {my=GetComponent<Transform>();
        if (auto)
        {
            keikei.uiloopjump(my,hight);
        }
    }
public void execute(){

 keikei.uiloopjump(my,hight);
     
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
