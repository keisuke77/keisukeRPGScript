using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explain : MonoBehaviour
{
    void OnGUI ()
		{
			GUI.Box (new Rect (Screen.width - 260, 10, 250, 150), "リングを集めよう");
			GUI.Label (new Rect (Screen.width - 245, 30, 250, 30), "緑は１０ポイント");
			GUI.Label (new Rect (Screen.width - 245, 50, 250, 30), "ゴールデンは３０ポイントだ");
			GUI.Label (new Rect (Screen.width - 245, 70, 250, 30), "足場は少しずつ歩いたところが");
			GUI.Label (new Rect (Screen.width - 245, 90, 250, 30), "崩れ落ちていく");
			GUI.Label (new Rect (Screen.width - 245, 110, 250, 30), "時間経過でもスコアはたまるが");
			GUI.Label (new Rect (Screen.width - 245, 130, 250, 30), "ハイスコアを狙うならリングを取ろう");
		}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
