using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageknock: StateMachineBehaviour {

	[SerializeField] AvatarTarget targetBodyPart = AvatarTarget.Root;
	[SerializeField, Range(0, 1)] float start = 0, end = 1;

	[HeaderAttribute("match target")]
	public Vector3 matchPosition;		// 指定パーツが到達して欲しい座標
	public Quaternion matchRotation;	// 到達して欲しい回転

	[HeaderAttribute("Weights")]
	public Vector3 positionWeight = Vector3.one;		// matchPositionに与えるウェイト。(1,1,1)で自由、(0,0,0)で移動できない。e.g. (0,0,1)で前後のみ
	public float rotationWeight = 0;			// 回転に与えるウェイト。

	private MatchTargetWeightMask weightMask;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		weightMask = new MatchTargetWeightMask (positionWeight, rotationWeight);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		animator.MatchTarget (matchPosition, matchRotation, targetBodyPart, weightMask, start, end);
	}
}