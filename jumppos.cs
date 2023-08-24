using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumppos : StateMachineBehaviour {

	[SerializeField] AvatarTarget targetBodyPart = AvatarTarget.Root;
	[SerializeField, Range(0, 1)] float start = 0, end = 1;
public bool dokan;
public bool bench;
public bool localposition;
	[HeaderAttribute("match target")]
	public Vector3 matchPosition;	
	Vector3 matchPositionsave;	// 指定パーツが到達して欲しい座標
	public Quaternion matchRotation;	// 到達して欲しい回転

	[HeaderAttribute("Weights")]
	public Vector3 positionWeight = Vector3.one;		// matchPositionに与えるウェイト。(1,1,1)で自由、(0,0,0)で移動できない。e.g. (0,0,1)で前後のみ
	public float rotationWeight;			// 回転に与えるウェイト。
GameObject obj;
	private MatchTargetWeightMask weightMask;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		weightMask = new MatchTargetWeightMask (positionWeight, rotationWeight);

		if(bench)
		{obj=animator.gameObject.NearserchTag("bench");
			matchPosition=obj.transform.position;
			
		matchRotation=obj.transform.rotation;
		foreach (var item in obj.GetComponentsInChildren<Collider>())
		{
			item.enabled=false;
		}
		
		}
if (dokan)
{
	matchPosition=keikei.dokan.position;
	
}
if (localposition)
{
	matchPosition=animator.transform.position+matchPosition;
}

}
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{if (localposition)
	{
			matchPosition=matchPosition-animator.transform.position ;

	}
if (bench)
{
		foreach (var item in obj.GetComponentsInChildren<Collider>())
		{
			item.enabled=true;
		}
}
	
		
		}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		animator.MatchTarget (matchPosition, matchRotation, targetBodyPart, weightMask, start, end);
	}
}