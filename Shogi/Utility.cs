using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
    public static class Utility
    {
        public static List<Vector2> DuplicateAdress(this List<KomaInfo> KomaInfos)
        {
            List<Vector2> result = new List<Vector2>();
            int length = KomaInfos.Count;
            int offset = 0;
            for (var i = offset; i < length; i++)
            {
                for (var j = offset + 1; j < length; j++)
                {
                    if (KomaInfos[i].Adress == KomaInfos[j].Adress)
                    {
                        result.Add(KomaInfos[i].Adress);
                    }
                }
                offset++;
            }
            Debug.Log("DuplicateAdress!!!");
            return result;
        }

        public static KomaInfo GetKoma(this List<KomaInfo> KomaInfos, GameObject obj)
        {
            foreach (var item in KomaInfos)
            {
                if (item.obj == obj)
                {
                    return item;
                }
            }
            return null;
        }

        public static Team ReverseTeam(this Team CurrentTeam)
        {
            switch (CurrentTeam)
            {
                case Team.Red:
                    CurrentTeam = Team.Blue;
                    break;
                case Team.Blue:
                    CurrentTeam = Team.Red;
                    break;
            }
            return CurrentTeam;
        }

   
     

        //盤面の自分のおける駒の合計スコア盤面評価関数
        public static KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>> GetMostBehavior(
            this List<KomaInfo> KomaInfos,
            int BoardSize,
            Team CurrentTeam,
            bool returnTotal = true
        )
        {
            int TotalScore = 0;
            KeyValuePair<KomaInfo, KomaInfo> temp = new KeyValuePair<KomaInfo, KomaInfo>();
            foreach (KomaInfo item in KomaInfos)
            {
                if (item.Team == CurrentTeam)
                {
                    var k = item.GetPlaceableMostHighScore(BoardSize, CurrentTeam, KomaInfos);
                    if (k != null)
                    {
                        TotalScore += k.Koma.Score;
                        if (temp.Key == null)
                        {
                            temp = new KeyValuePair<KomaInfo, KomaInfo>(item, k);
                        }
                        if (temp.Value.Koma.Score < k.Koma.Score)
                        {
                            temp = new KeyValuePair<KomaInfo, KomaInfo>(item, k);
                        }
                    }
                }
            }
            return new KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>>(
                returnTotal == true ? TotalScore : temp.Value.Koma.Score,
                temp
            );
        }

        public static List<KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>>> GetAllBehavior(
            this List<KomaInfo> KomaInfos,
            int BoardSize,
            Team CurrentTeam
        )
        {
            List<KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>>> result =
                new List<KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>>>();
            foreach (KomaInfo item in KomaInfos)
            {
                if (item.Team == CurrentTeam)
                { //自分のチームの全ての駒に対して取得可能な一番スコアの高い駒を調べる
                    KomaInfo k = item.GetPlaceableMostHighScore(BoardSize, CurrentTeam, KomaInfos);
                    if (k.Koma != null)
                    {
                        result.Add(
                            new KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>>(
                                k.Koma.Score,
                                new KeyValuePair<KomaInfo, KomaInfo>(item, k)
                            )
                        );
                    }
                }
            }
            return result;
        }

        public static List<KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>>> GetAllWaysBehavior(
            this List<KomaInfo> KomaInfos,
            int BoardSize,
            Team CurrentTeam
        )
        {
            List<KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>>> result =
                new List<KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>>>();
                //自分のチームの全ての駒に対して取得可能な駒を調べる
                  
            foreach (KomaInfo item in KomaInfos)
            {
                if (item.Team == CurrentTeam)
                {
                    //その駒のすべての動ける駒取得
                      var k = item.GetAllPlaceable(BoardSize, CurrentTeam, KomaInfos);
                    if (k != null)
                    {
                        foreach (var koma in k)
                        {
                            result.Add(
                                new KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>>(
                                    koma.Koma.Score,
                                    new KeyValuePair<KomaInfo, KomaInfo>(item, koma)
                                )
                            );
                        }
                    }
                }
            }
            return result;
        }

        public static KomaInfo GetPlaceableMostHighScore(
            this KomaInfo KomaInfo,
            int BoardSize,
            Team CurrentTeam, //リストは入れるとより強力になる
            List<KomaInfo> KomaInfos = null
        )
        {
            //場所によってはエアーコマが入る
            KomaInfo temp = null;
            foreach (Vector2 item in KomaInfo.GetMoveableAdress(BoardSize, CurrentTeam, KomaInfos))
            {
                KomaInfo now = KomaInfos.GetKomaFromAdress(item);
                if (temp == null)
                {
                    temp = now;
                }
                if (temp.Koma.Score < now.Koma.Score)
                {
                    temp = now;
                }
            }
            return temp;
        }

        public static List<KomaInfo> GetAllPlaceable(
            this KomaInfo KomaInfo,
            int BoardSize,
            Team CurrentTeam, //リストは入れるとより強力になる
            List<KomaInfo> KomaInfos = null
        )
        {
            List<KomaInfo> result = new List<KomaInfo>();
            //場所によってはエアーコマが入る

            foreach (Vector2 item in KomaInfo.GetMoveableAdress(BoardSize, CurrentTeam, KomaInfos))
            {
                result.Add(KomaInfos.GetKomaFromAdress(item));
            }
            return result;
        }

        public static List<Vector2> GetMoveableAdress(
            this KomaInfo KomaInfo,
            int BoardSize,
            Team CurrentTeam, //リストは入れるとより強力になる
            List<KomaInfo> KomaInfos = null
        )
        {
            List<Vector2> result = new List<Vector2>();
            Vector2[] PlaceablePos = new Vector2[0];
            if (KomaInfo.Team == Team.None)
            {
                return new List<Vector2>();
            }
            if (KomaInfo.Koma != null)
            {
                if (!KomaInfo.isNari)
                {
                    PlaceablePos = KomaInfo.Koma.PlaceablePos;
                }
                else
                {
                    PlaceablePos = KomaInfo.Koma.isNariPlaceablePos;
                }
            }

            foreach (Vector2 item in PlaceablePos)
            {
                Vector2 direction = new Vector2();
                if (CurrentTeam == Team.Red)
                {
                    direction = item;
                }
                if (CurrentTeam == Team.Blue)
                {
                    direction = new Vector2(item.x, -item.y);
                }

                Vector2 Pos = direction + KomaInfo.Adress;

                if (Pos.x >= 0 && Pos.x <= BoardSize && Pos.y >= 0 && Pos.x <= BoardSize)
                {
                    if (KomaInfos != null)
                    {
                        KomaInfo PlaceKomaInfo = KomaInfos.GetKomaFromAdress(Pos);
                        if (PlaceKomaInfo != null)
                        {
                            //同じチームの駒の上にはおけないから
                            if (PlaceKomaInfo.Team != CurrentTeam)
                            {
                                if (
                                    KomaInfo.Koma.Skipable
                                    || !KomaInfos.BetWeenKomaCheck(KomaInfo, PlaceKomaInfo)
                                )
                                {
                                    result.Add(Pos);
                                }
                            }
                        }
                    }
                    else
                    {
                        result.Add(Pos);
                    }
                }
            }
            return result;
        }

        public static bool BetWeenKomaCheck(
            this List<KomaInfo> KomaInfos,
            KomaInfo KomaInfo,
            KomaInfo KomaInfoo
        )
        {
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    var detect = new Vector2(i, j);
                    for (var size = 0; size < 9; size++)
                    {
                        //もしもその方角上に目当ての駒が存在したら
                        if (KomaInfo.Adress + (detect * size) == KomaInfoo.Adress)
                        {
                            //その方角に目当て以外の駒が存在するか調べる
                            for (var s = 1; s < size; s++)
                            {
                                var k = KomaInfos.GetKomaFromAdress(KomaInfo.Adress + detect * s);
                                if (k != null)
                                {
                                    if (k.Team != Team.None && k != KomaInfoo)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        //なれるかどうかのフラグ
        public static bool NariCheck(this KomaInfo KomaInfo, int BoardSize)
        {
            if (KomaInfo.Team == Team.Blue)
            {
                if (KomaInfo.Adress.y < 3)
                {
                    return true;
                }
            }
            if (KomaInfo.Team == Team.Red)
            {
                if (KomaInfo.Adress.y > (BoardSize - 4))
                {
                    return true;
                }
            }
            return false;
        }

        //アドレス未割当の場所を探す
        public static List<Vector2> NothingAdress(this List<KomaInfo> KomaInfos, int BoardSize)
        {
            List<Vector2> result = new List<Vector2>();

            for (var x = 0; x < BoardSize; x++)
            {
                for (var y = 0; y < BoardSize; y++)
                {
                    Vector2 check = new Vector2(x, y);
                    bool Exsit = false;
                    foreach (var item in KomaInfos)
                    {
                        if (item.Adress == check)
                        {
                            Exsit = true;
                        }
                    }
                    if (Exsit == false)
                    {
                        result.Add(check);
                    }
                }
            }
            return result;
        }

        public static KomaInfo GetKomaFromAdress(this List<KomaInfo> KomaInfos, Vector2 Adress)
        {
            foreach (var item in KomaInfos)
            {
                if (item.Adress == Adress)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
