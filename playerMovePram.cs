using UnityEngine;




public enum directionXYZ
{front,horizon,height
	 
}
public class playerMovePram : MonoBehaviour
{//このクラスが継承されたクラスがプレイヤーにあればバグは起きない

public float height;
public Vector3 LastMoveValue;

public bool objrotate;
public float dashpower=1;
public float gravity=-9.8f;  
public Vector3 velocity;
public bool stop=false;
public bool rotateonly;
	
public float movespeed=1;
// 前進速度
public float forwardSpeed = 7.0f;
		// 後退速度
public float backwardSpeed = 2.0f;
		// 旋回速度
public float rotateSpeed = 2.0f;
public Animator anim;
public Transform trans;
public xyz defaultxyz;
public xyz nowxyz;
public CharacterController controller;
public Rigidbody rb;
public Vector3 forceValue;
// ジャンプ威力
public float jumpPower = 3.0f; 
	
public virtual void AddForce(Vector3 force){

}
}