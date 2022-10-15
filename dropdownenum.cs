
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class dropdownenum : MonoBehaviour
{
    [SerializeField]
    Dropdown dropDown;

    [SerializeField]
    string enumName;

    void Awake()
    {
        var type = Type.GetType(enumName);
        if (type == null && !type.IsEnum) {
            Debug.LogError("指定のEnum型は存在しません");
            return;
        }

        //EnumをStringの配列に変換
        string[] enumNames = System.Enum.GetNames(type);

        //Stringの配列をリストに変換
        var names = new List<string>(enumNames);

        if(dropDown == null) {
            Debug.LogError("ドロップダウンメニューが存在しません");
            return;
        }

        // 一旦クリア
        dropDown.ClearOptions();

        //DropDownの要素にリストを追加
        dropDown.AddOptions(names);
    }
  
}