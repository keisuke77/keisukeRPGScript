
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectspawner : MonoBehaviour
{  [System.Serializable]
    public class targeteffect{
         public Transform target;
    public GameObject effect;
    }
   public targeteffect[] targeteffects;
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void effectspawn(int i){
    var a=targeteffects[i];
    Instantiate(a.effect,a.target.position,a.target.rotation);
    
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
