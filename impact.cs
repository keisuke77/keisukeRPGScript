using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class impact : MonoBehaviour {

	
	// ★★★
	public float radius = 10.0f;
	public float power = 100.0f;
    public string tags;
	
	

	
	// ★★★
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == tags||tags==null){

			// 力を発生させる場所
			Vector3 explosionPos = transform.position;

			// 中心点から設定した半径の中にあるcolliderの配列を取得する。
		
				// 力を及ぼしたいオブジェクトにRigidbodyが付いていることが必要（ポイント）
				var rb = other.gameObject.GetComponent<Rigidbody>();

				if(rb != null){
					// 取得したRigidbodyに力を加える
					// ３つの引数（加える力の強さ、力の中心点、力を及ぼす半径）
					rb.AddExplosionForce(power, explosionPos, 5.0f);
				}
			
		}
	}
}