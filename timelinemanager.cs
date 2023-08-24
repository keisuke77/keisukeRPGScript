using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[RequireComponent(typeof(PlayableDirector))]
public class timelinemanager : MonoBehaviour
{
    // ここにインスペクター上であらかじめ複数のセット
    [SerializeField] private TimelineAsset[] timelines;

    private PlayableDirector director;//PlayableDirector型の変数directorを宣言

    void Start()
    {
        //同じオブジェクトに付いているPlayableDirectorコンポーネントを取得
        director = this.GetComponent<PlayableDirector>();        
    }

    //イベント再生メソッド ボタンに割り当てる
    public void EventPlay(int id)
    {

        //ボタンの引数によってタイムラインを指定して再生
        switch (id)
        {
            case 1:
                // 再生したいタイムラインをPlayableDirectorに再生させる
                director.Play(timelines[0]);                
                break;
            case 2:
                // 再生したいタイムラインをPlayableDirectorに再生させる
                director.Play(timelines[1]);                
                break;
            case 3:
                // 再生したいタイムラインをPlayableDirectorに再生させる
                director.Play(timelines[2]);                
                break;
        }
    }
}