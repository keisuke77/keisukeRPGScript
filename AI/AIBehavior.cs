using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;


public enum State
{
    Chaise,Patrol,Wait,RunAway,Attack
}


public class AIBehavior : MonoBehaviour {
    public NavMeshAgent agent;
    public Animator anim;
    public State nowState;
    public string TargetTag;
    public Transform[] points;
    Patrol Patrol;


    void Update() {
        switch (nowState)
        {
            case State.Chaise:
                break;
            default:
                break;
        }
        
    }
}