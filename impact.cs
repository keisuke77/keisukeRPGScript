using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class impact : MonoBehaviour {

<<<<<<< HEAD
	
	// ★★★
	public float radius = 10.0f;
	public float power = 100.0f;
    public string tags;
=======
	public float moveSpeed;
	public float turnSpeed;
	public float boostSpeed = 200.0f;
	public Rigidbody rb;
	private float movementInputValue;
	private float turnInputValue;

	// ★★★
	public float radius = 10.0f;
	public float power = 100.0f;

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
	
	

	
	// ★★★
	void OnCollisionEnter(Collision other){
<<<<<<< HEAD
		if(other.gameObject.tag == tags||tags==null){
=======
		if(other.gameObject.tag == "block"
        ){
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

			// 力を発生させる場所
			Vector3 explosionPos = transform.position;

			// 中心点から設定した半径の中にあるcolliderの配列を取得する。
		
				// 力を及ぼしたいオブジェクトにRigidbodyが付いていることが必要（ポイント）
<<<<<<< HEAD
				var rb = other.gameObject.GetComponent<Rigidbody>();
=======
				rb = other.gameObject.GetComponent<Rigidbody>();
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

				if(rb != null){
					// 取得したRigidbodyに力を加える
					// ３つの引数（加える力の強さ、力の中心点、力を及ぼす半径）
					rb.AddExplosionForce(power, explosionPos, 5.0f);
				}
			
		}
	}
}