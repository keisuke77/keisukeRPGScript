using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {

  public float countTime = 0;
  public Text timetext;
   public highscore score;
   public bool add=true;
   public float limittime=100;
   
   
    // Use this for initialization
    void Start () {

limittime=PlayerPrefs.GetFloat("time",limittime);
    }

 public void scoresave(){
   score.scoresave(countTime);
}
    // Update is called once per frame
    void Update () {
      if (add)
      {
           countTime += Time.deltaTime; //スタートしてからの秒数を格納
    timetext.text = "Score:"+countTime.ToString("F2"); //小数2桁にして表示
      }else
      {
         limittime -= Time.deltaTime; //スタートしてからの秒数を格納
    timetext.text = "残り時間:"+limittime.ToString("F2"); //小数2桁にして表示
    

      }


     }
}