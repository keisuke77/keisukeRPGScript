using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class moveta : MonoBehaviour {

    public NavMeshAgent nav;
    public GameObject target;
private Animator anim;
    void Start () {
        anim = GetComponent<Animator>();
        nav  = GetComponent<NavMeshAgent>();
    }

    void Update () {
          Vector3 Apos = gameObject.transform.position;
        Vector3 Bpos = target.transform.position;
        float dis = Vector3.Distance(Apos, Bpos);
        
        if (target != null&&dis>3) {
            nav.destination  = target.transform.position;
            anim.SetBool("walk", true);
        }else{
            nav.destination  = gameObject.transform.position;
         
           anim.SetBool("walk", false);
        }

       

    }
}