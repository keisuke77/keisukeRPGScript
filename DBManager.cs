using System.Collections.Generic;
using UnityEngine;
using NCMB;
using System.Linq;

public class DBManager : MonoBehaviour
{

     public void Save(int value)
    {Save("testingkeisuke",value);
    }
    public void Save(string key, int value)
    {
        //データストアにスコアクラスを定義
        NCMBObject test = new NCMBObject("Score");

        //データストアに登録したい値を設定
        test[key] = value;

        //サーバーに書き込む
        test.SaveAsync((NCMBException e) =>
        {
            if(e != null)
            {
                Debug.LogWarning("保存に失敗: " + e.ErrorMessage);
            }
            else
            {
                Debug.Log("保存に成功");
            }
        });
    }

    public void Load(string key)
    {
        //データストアの"Score"クラスから検索
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("Score");

        //"Score"クラスのkeyカラムを降順に並び替え　例)3,2,1
        query.OrderByDescending(key);

        //実際に取得する
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if(e != null)
            {
                Debug.LogWarning("取得に失敗: " + e.ErrorMessage);
            }
            else
            {
                var scores = objList.Select(o => System.Convert.ToInt32(o[key]));

                foreach(var item in scores)
                {
                    Debug.Log(key + ": " + item);
                }
            }
        });
    }
}