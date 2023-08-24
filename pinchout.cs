using UnityEngine;
using System.Collections;

public class pinchout : MonoBehaviour {

    //public Camera camera;
    
   public float vMin = 1.0f;
   public float vMax = 5.0f;

    //直前の2点間の距離.
    private float backDist = 0.0f;
    //初期値
    float view = 60.0f;
   public static float v = 1.0f;
public float vv;


    // Update is called once per frame
    void Update () {
vv=v;
        // マルチタッチかどうか確認
        if (Input.touchCount >= 2)
        {
            // タッチしている２点を取得
            Touch t1 = Input.GetTouch (0);
            Touch t2 = Input.GetTouch (1);

            //2点タッチ開始時の距離を記憶
            if (t2.phase == TouchPhase.Began)
            {Debug.Log("tacth");
                backDist = Vector2.Distance (t1.position, t2.position);
            }
            else if (t1.phase == TouchPhase.Moved && t2.phase == TouchPhase.Moved)
            {Debug.Log("tacthmove");
                // タッチ位置の移動後、長さを再測し、前回の距離からの相対値を取る。
                float newDist = Vector2.Distance (t1.position, t2.position);
                view = view + (backDist - newDist) / 100.0f;
                v = v + (newDist - backDist);

                // 限界値をオーバーした際の処理
                if(v > vMax)
                {
                    v = vMax;
                }
                else if(v < vMin)
                {
                    v = vMin;
                }

                
            }
        }
    }
}