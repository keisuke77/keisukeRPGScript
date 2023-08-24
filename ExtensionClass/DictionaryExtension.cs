
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

using System.Linq;
/// <summary>
/// Listの拡張クラス
/// </summary>
public static class DictionaryExtension {
public static List<T1> GetMinValueList<T1>(this Dictionary<T1,int> dic){
 int minValue = dic.Values.Min();
            List<T1> minElem = dic.Where(c => c.Value == minValue).ToDictionary(x => x.Key, y => y.Value).Keys.ToList();
         return minElem;
}
public static List<T1> GetMaxValueList<T1>(this Dictionary<T1,int> dic){
 int minValue = dic.Values.Max();
   List<T1> minElem = dic.Where(c => c.Value == minValue).ToDictionary(x => x.Key, y => y.Value).Keys.ToList();
         return minElem;
}


}