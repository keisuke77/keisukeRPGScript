using UnityEngine;

public static class SaveData {

    public static bool GetBool(string key, bool defalutValue){
        var value = PlayerPrefs.GetInt(key, defalutValue ? 1 : 0);
        return value == 1;
    }

    public static void SetBool(string key, bool value){
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }
}