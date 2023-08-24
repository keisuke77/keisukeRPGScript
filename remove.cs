using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Component 型の拡張メソッドを管理するクラス
/// </summary>
public static class remove
{
    /// <summary>
    /// コンポーネントを削除します
    /// </summary>
    public static void RemoveComponent<T>(this Component self) where T : Component
    {
        GameObject.Destroy(self.GetComponent<T>());
    }
}


