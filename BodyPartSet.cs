using UnityEngine;

public class BodyPartSet : MonoBehaviour,GetBodyPart
{
    
public GameObject righthand;
public GameObject lefthand;
public GameObject rightfoot;
public GameObject leftfoot;

	public GameObject GetRightHand(){
		return righthand;
	}public GameObject GetLeftHand(){
		return lefthand;
	}public GameObject GetLeftFoot(){
		return leftfoot;
	}public GameObject GetRightFoot(){
		return rightfoot;
	}
}