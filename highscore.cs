
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class highscore : MonoBehaviour {
	
	
	public Text scoreText;
//********** 開始 **********//
	public Text highScoreText; //ハイスコアを表示するTextオブジェクト
//********** 終了 **********//
		 public bool recordupdate=false;
  
	//********** 開始 **********//
	private float highScores; //ハイスコア計算用変数
	private string key = "HIGH SCORE"; //ハイスコアの保存先キー
//********** 終了 **********//
	
	void Start (){
			
		highScores = PlayerPrefs.GetFloat(key, 0);
		//ハイスコアを表示
		
	}
public void scoresave(float score){

    PlayerPrefs.SetFloat("now", score);
			
if (score > highScores) {

PlayerPrefs.SetInt("recordupdate", 1);
				//ハイスコア更新
				highScores = score;
				//ハイスコアを保存
				PlayerPrefs.SetFloat(key, highScores);
				//ハイスコアを表示
					}
    }

	
		
	}
