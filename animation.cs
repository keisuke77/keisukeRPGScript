using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
public bool atractcamera;
   public Animation anim;
 
	// Use this for initialization
	void Start () {

		anim = this.gameObject.GetComponent<Animation> ();
	}
    // Start is called before the first frame update
    
public void Play(string name){

anim.Play(name);
if (atractcamera)
{
    
keikei.atractcamera(2f,transform,10f);
}
}


    // Update is called once per frame
    void Update()
    {
        
    }
}
