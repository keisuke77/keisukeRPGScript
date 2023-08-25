//  GameObjectExtension.cs
//  http://kan-kikuchi.hatenablog.com/entry/GetComponentInParentAndChildren
//
//  Created by kikuchikan on 2015.08.25.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// GameObjectの拡張クラス
/// </summary>
public static class GameObjectExtension{


  
  
  /// <summary>
  /// 親や子オブジェクトも含めた範囲から指定のコンポーネントを取得する
  /// </summary>
  public static T GetComponentInParentAndChildren<T>(this GameObject gameObject) where T : UnityEngine.Component {

    if(gameObject.GetComponentInParent<T>() != null){
      return gameObject.GetComponentInParent<T>();
    }
    if(gameObject.GetComponentInChildren<T>() != null){
      return gameObject.GetComponentInChildren<T>();
    }

    return gameObject.GetComponent<T>();
  }
  
  /// <summary>
  /// 親や子オブジェクトも含めた範囲から指定のコンポーネントを全て取得する
  /// </summary>
  public static List<T> GetComponentsInParentAndChildren<T>(this GameObject gameObject) where T : UnityEngine.Component {
    List<T> _list = new List<T>(gameObject.GetComponents<T>());

    _list.AddRange (new List<T>(gameObject.GetComponentsInChildren<T>()));
    _list.AddRange (new List<T>(gameObject.GetComponentsInParent<T>()));

    return _list;
  }  

}