using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncircle : MonoBehaviour {

    [Header("分布")]
    [SerializeField] Transform CenterPosition;                 // 対象オブジェクト
    [SerializeField] int ArrangementMaxRedius = 1000;         // 配置位置の最大半径
    [SerializeField] int ArrangementMinRedius = 500;         // 配置位置の最小半径
    [SerializeField] int ArrangementHeight = 10;              // 配置位置の高さ
 [SerializeField] bool onstart;              // 配置位置の高さ


    [Header("個数")]
    [SerializeField] GameObject CreaturePrefab;                 // 対象オブジェクト
    [SerializeField] int CreatureLength = 100;                 // 配置位置の最大


    private System.Random random;                               // 乱数機

    // Use this for initialization
    void Start () {
if (onstart)
{
     spawn(CreaturePrefab,CreatureLength);
  
}
       }
    


    public GameObject[] spawn(GameObject obj,int number){
  GameObject[] CreatureRange = new GameObject[number];
        random = new System.Random();

        int x;
        int z;

        double xAbs;
        double zAbs;

        double maxR = Math.Pow(ArrangementMaxRedius, 2);
        double minR = Math.Pow(ArrangementMinRedius, 2);

        for (int i = 0; i < CreatureRange.Length; i++)
        {
            while (CreatureRange[i] == null){
                x = random.Next(-ArrangementMaxRedius, ArrangementMaxRedius);
                z = random.Next(-ArrangementMaxRedius, ArrangementMaxRedius);

                xAbs = Math.Abs(Math.Pow(x, 2));
                zAbs = Math.Abs(Math.Pow(z, 2));

                // 特定の範囲内化確認
                if (maxR > xAbs + zAbs && xAbs + zAbs > minR)
                {
                    GameObject go = Instantiate(
                        obj,             // 個体のオブジェクト
                        (new Vector3(x, ArrangementHeight, z)) + CenterPosition.position,        // 初期座標
                        Quaternion.identity         // 回転位置
                    );
                    CreatureRange[i] = go;
                }
            }
        }
return CreatureRange;
    }
    // Update is called once per frame
    void Update () {
        
    }
}