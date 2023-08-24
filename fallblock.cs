using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallblock : MonoBehaviour
{
    public int max;
    public int maxhight=20; 
  public GameObject block;
    public float often=10f;
    public float ori;
    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("spawn",1,often);
ori =often;
    }

    // Update is called once per frame
    void Update()
    {
        
       if (often !=ori)
       {ori=often;
           CancelInvoke("spawn");
            InvokeRepeating("spawn",1,often);
       }
      
    }
    void spawn(){ 
        int x = Random.Range(-max,max);
       int y = Random.Range(-max,max);
       int high = Random.Range(5,maxhight);
        object p = Instantiate(block, new Vector3(x,high,y),Quaternion.identity);
    }
}
