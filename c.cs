using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColliderManager
{
    public static void ColliderDataInput(this GameObject a_collider, GameObject a_object, ref Vector3 a_vector,float Power=30)
    {
        a_vector.Set(
            a_object.transform.position.x - a_collider.transform.position.x,
            0f,
            a_object.transform.position.z - a_collider.transform.position.z
        );
        a_vector.Normalize();
        a_vector*=Power;
    }
}

/*
    [規則]
    p_ 外部アクセス
    m_ メンバー変数
    l_ ローカル変数
    a_ 引数
    e_ 列挙型

    [説明]

    [バージョン]
    2021-01-28　吹き飛ばし機能の実装

    [タスク]
    タスク１　戦闘開始時にMainPlayerColliderSetでステータスを反映させる
*/
