using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class itweenmove : MonoBehaviour
{
    public float movedistance=5;
    public float movetime=3;
    public string direction="y";
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveBy(gameObject, iTween.Hash(direction, movedistance,"time", movetime,"oncomplete", "animend", 
		"oncompletetarget", gameObject));
    }
void animend(){
    iTween.MoveBy(gameObject, iTween.Hash(direction, -movedistance,"time", movetime,"EaseType", iTween.EaseType.linear,"oncomplete", "animendnext", 
		"oncompletetarget", gameObject));
}
void animendnext(){
    iTween.MoveBy(gameObject, iTween.Hash(direction, movedistance,"time", movetime,"EaseType", iTween.EaseType.linear,"oncomplete", "animend", 
		"oncompletetarget", gameObject));
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
