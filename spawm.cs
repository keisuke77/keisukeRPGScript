using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawm : MonoBehaviour
{public GameObject target;
    private Vector3 random; 
public int number;
    public float stagerange=100;  // Start is called before the first frame update
<<<<<<< HEAD
 
=======
    void Start()
    {
        
    }
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
int num;
    // Update is called once per frame
    void Update()
    {if (num>number)
    {
        return;
    }
        num++;
        random = new Vector3(Random.value,0,Random.value);
        random = stagerange*random;
        Instantiate(target,random,transform.rotation);
    }

    
}
