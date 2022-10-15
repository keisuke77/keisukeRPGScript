using UnityEngine;
using UnityEngine.UI;			// Sliderを扱うために必要

public class suraida : MonoBehaviour {
	private const int maxHp = 200;	// 敵キャラのHP最大値を100とする
	private int currentHp;		// 現在のHP
	public Slider slider;		// シーンに配置したSlider格納用
    public float maHp;
	// Use this for initialization
	void Start () {Debug.Log("col");
		slider.maxValue = maxHp;	// Sliderの最大値を敵キャラのHP最大値と合わせる
		currentHp = maxHp;		// 初期状態はHP満タン
		slider.value = currentHp;
		// Sliderの初期状態を設定（HP満タン）
	}
	
	private void OnCollisionEnter(Collision other)
	{

		Debug.Log("test");
		if(other.gameObject.tag == "Player")	// プレイヤーとぶつかったとき
		{
			currentHp -= 10;		// 現在のHPを減.らす
			slider.value = currentHp;	// Sliderに現在HPを適用
			Debug.Log("slider.value = " + slider.value);

			// Sliderが最小値になったら（例：ボスキャラを倒したら）
			if (slider.value <=0)
			{
				Destroy(gameObject);			// 物体を消去
				Destroy(slider);	// Sliderも消去
			}
		}
	}
}