using UnityEngine;




public class playerMovePram : MonoBehaviour
{//このクラスが継承されたクラスがプレイヤーにあればバグは起きない


public bool objrotate; 
public bool stop=false;
public bool rotateonly;
public float dashpower=1;
public float gravity=-9.8f; 
public float movespeed=1;
// 前進速度
public float forwardSpeed = 7.0f;
		// 後退速度
public float backwardSpeed = 2.0f;
		// 旋回速度
public float rotateSpeed = 2.0f;
// ジャンプ威力
public float jumpPower = 3.0f; 
	

	
public Animator anim;
public Transform trans;
public xyz defaultxyz;
public xyz nowxyz;
public CharacterController controller;
public Rigidbody rb;
public virtual void AddForce(Vector3 force){

}
}