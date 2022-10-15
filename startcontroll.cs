using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class startcontroll : MonoBehaviour
{


   public navchaise navchaise;
   public enemyhp enemyhp;
   public NavMeshAgent agent;
   public navmeshonoff navmeshonoff;

    
    private void Awake()
    {
        
navmeshonoff=GetComponent<navmeshonoff>();
        navchaise=GetComponent<navchaise>();
        enemyhp=GetComponent<enemyhp>();
        agent=GetComponent<NavMeshAgent>();
        navmeshonoff.enabled=false;
agent.enabled=false;
enemyhp.enabled=false;
navchaise.enabled=false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void setstart(){
navmeshonoff.enabled=true;
agent.enabled=true;
enemyhp.enabled=true;
navchaise.enabled=true;
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
