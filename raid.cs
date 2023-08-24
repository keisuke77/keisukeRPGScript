using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class raid : MonoBehaviour
{
    public bool auto;
    public List<enemysSet> raidenemys;
public List<GameObject> check;

int i;

void Start()
{if (auto)
{
    setupraid();
}
    
}
public void clear(){


}

 public void  setupraid()
{


    check=raidenemys[i].spawn(transform);
    i++;
}
int b;
    void Update()
    {b=0;
       
        
    if (check==null)
    {
        setupraid();
    }else
    {
         foreach (GameObject item in check)
        {
            if (item==null)
            {
                check.RemoveAt(b);
            }
            b++;
        }
    }
    if (i==raidenemys.Count)
    {
        clear();
    }
        
    }
}