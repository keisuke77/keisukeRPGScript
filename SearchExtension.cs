using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using DG.Tweening;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public static class SearchExtension
{
    
public static GameObject FindAllChild(this GameObject obj,string objname){


foreach (GameObject item in obj.GetAll())
{if (item.name==objname)
{
  return item;
}
}
return null;
}
  public static GameObject NearserchTag(this GameObject nowObj,string tagName){
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in  GameObject.FindGameObjectsWithTag(tagName)){
            //自身と取得したオブジェクトの距離を取得
            tmpDis =(obs.transform.position- nowObj.transform.position).sqrMagnitude;

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis){
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
    
    public static GameObject[] RadiusSearchTag(this GameObject nowObj,string tagName,float radius){
        float tmpDis = 0;           //距離用一時変数
          //string nearObjName = "";    //オブジェクト名称
        List<GameObject> targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in  GameObject.FindGameObjectsWithTag(tagName)){
            //自身と取得したオブジェクトの距離を取得
            tmpDis =(obs.transform.position- nowObj.transform.position).sqrMagnitude;
if (tmpDis<radius)
{
  targetObj.Add(obs);
}
        
        }

        return targetObj.ToArray();
    } 
    
    public static T[] RadiusSearch<T>(this GameObject nowObj,float radius){
        float tmpDis = 0;           //距離用一時変数
          //string nearObjName = "";    //オブジェクト名称
        List<T> targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で.取得する
        foreach (GameObject obs in UnityEngine.Object.FindObjectsOfType(typeof(GameObject))){
            //自身と取得したオブジェクトの距離を取得
            tmpDis =(obs.transform.position- nowObj.transform.position).sqrMagnitude;
if (tmpDis<radius)
{
  targetObj.Add(obs.GetComponent<T>());
}
        
        }

        return targetObj.ToArray();
    }
}
    