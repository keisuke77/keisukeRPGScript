using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// オブジェクトを円周上で移動させるスクリプトです。
/// </Summary>
public class SphereMover : MonoBehaviour
{
    // 円の半径を設定します。
    public float radius = 10f;
public float speed=2;
    // 初期位置を取得し、高さを保持します。
    Vector3 initPos;

    void Start()
    {
        // 初期位置を保持します。
        initPos = gameObject.transform.position;
    }

    void Update()
    {
        CalcPosition();
    }

    /// <Summary>
    /// オブジェクトの位置を計算するメソッドです。
    /// </Summary>
    void CalcPosition()
    {
        // 位相を計算します。
        float phase = Time.time * speed * Mathf.PI;

        // 現在の位置を計算します。
        float xPos = radius * Mathf.Cos(phase);
        float zPos = radius * Mathf.Sin(phase);
Vector3 SpherePos=new Vector3(xPos, 0, zPos);
        // ゲームオブジェクトの位置を設定します。
        
        gameObject.transform.position = initPos +SpherePos;
    }
}