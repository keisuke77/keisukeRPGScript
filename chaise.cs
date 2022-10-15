using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaise : MonoBehaviour {

    public GameObject player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用
public float needtime=3;
float time;
Vector3 pos;
	// Use this for initialization
	void Start () {
        if (player==null)
        {
                 this.player = GameObject.Find("unitychan");
pos=player.transform.position;
        }
        //unitychanの情報を取得
       
        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
               time+=Time.deltaTime;
var t=time/needtime;

        //新しいトランスフォームの値を代入する
        transform.position = Vector3.Lerp(transform.position,pos,t);
if (t>1.1f)
{
        Destroy(gameObject);
}
	}
}