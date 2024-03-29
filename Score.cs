using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // スコアを表示する
    public Text scoreText;
    // ハイスコアを表示する
    public Text highScoreText;

    // スコア
    private int score;
    public bool recordupdate=false;
    // ハイスコア
    private int highScore;

    // PlayerPrefsで保存するためのキー
    private string highScoreKey = "highScore";

    void Start ()
    {
        Initialize ();
    }

    void Update ()
    {
        // スコアがハイスコアより大きければ
        if (highScore < score) {
            highScore = score;
            recordupdate=true;
        }

        // スコア・ハイスコアを表示する
        scoreText.text = score.ToString ();
        highScoreText.text = highScore.ToString ();
    }

    // ゲーム開始前の状態に戻す
    private void Initialize ()
    {
        // スコアを0に戻す
        score = 0;

        // ハイスコアを取得する。保存されてなければ0を取得する。
        highScore = PlayerPrefs.GetInt (highScoreKey, 0);
    }

    // ポイントの追加
    public void AddPoint (int point)
    {
        score = score + point;
    }

    // ハイスコアの保存
    public void Save ()
    {
        // ハイスコアを保存する


        PlayerPrefs.SetInt (highScoreKey, highScore);
        PlayerPrefs.Save ();

        // ゲーム開始前の状態に戻す
        Initialize ();
    }
}