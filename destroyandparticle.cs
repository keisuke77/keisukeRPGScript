using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyandparticle : MonoBehaviour
{
    // Start is called before the first frame update
   public ParticleSystem particle;
	public float time = 5f;


	// Use this for initialization
	void Start () 
	{
		Invoke("execute",time);
	}

void execute()
{
Instantiate(particle,transform.position,transform.rotation);
    Destroy(gameObject);
}}