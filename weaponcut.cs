using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponcut : MonoBehaviour
{public LineBlade LineBlade;
Transform trans;
    // Start is called before the first frame update
public void sta(){
    LineBlade.sta(keikei.player.GetComponent<objectchange>().Getobj().transform.GetChild(0).transform);
}
public void end(){
    LineBlade.end(keikei.player.GetComponent<objectchange>().Getobj().transform.GetChild(0).transform);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
