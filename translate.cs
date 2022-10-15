using System.Collections;
using System.Collections.Generic;
using UnityEngine;using DG.Tweening;

public class translate : MonoBehaviour
{public float speed=1;
public Vector3 pos;
public Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void Playpos(Vector3 p){  transform.DOMove(p, speed );
}
public void Playrot(Vector3 p){
    transform.DORotate(p, speed );
}
public void Playpos(){  transform.DOMove(pos, speed );
}
public void Playrot(){
    transform.DORotate(rot, speed );
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
