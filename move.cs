using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

public float speed;
public float horizon=0;
public float vertical=0;
public bool up=false;
public bool down=false;public bool left=false;public bool right=false;
	// Use this for initialization
	void Start () {
		
	}

    void moveto(float from, float to){

    }
    
   public void righton(){
        Debug.Log("right");
        right=true;
       horizon=1;
    }

  public void rightoff(){
        right=false;
         horizon=0;
    }
     public void lefton(){
         horizon=-1;
        left=true;
       
    } public void leftoff(){
       horizon=0;
        left=false;
       
    } public void downon(){
        vertical=-1;
        down=true;
       
    } public void downoff(){
       vertical=0;
        down=false;
       
    }
     public void upon(){
         vertical=1;
        up=true;
       
    } public void upoff(){
       vertical=0;
        up=false;
       
    }
	void FixedUpdate()
    {
         if (Input.GetKey(KeyCode.UpArrow)||up)
        {
            transform.Translate(0f, 0f, 0.1f*speed);
        }
        if (Input.GetKey(KeyCode.DownArrow)||down)
        {
            transform.Translate(0f, 0f, -0.1f*speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow)||left)
        {
            transform.Translate(-0.1f*speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow)||right)
        {
            transform.Translate(0.1f*speed, 0f, 0f);
        }

    }
	// Update is called once per frame


}
