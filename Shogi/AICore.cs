using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

using System.Linq;

namespace Shogi
{
    public static class AICore
    {
            public static List<KomaInfo> ListCopy(this List<KomaInfo> originalList)
        {
            return originalList.Select(item => item.Clone()).ToList();
        }
     

        public static List<KomaInfo> GetVirtualMoveBoard(
            this List<KomaInfo> KomaInfos,
            KomaInfo PlaceKoma,
            KomaInfo PlacedKoma,
            Team CurrentTeam
        )
        {
            List<KomaInfo> VirtualBoard = KomaInfos.ListCopy();
            KomaInfo vPlaceKoma = VirtualBoard.GetKomaFromAdress(PlaceKoma.Adress);
            KomaInfo vPlacedKoma = VirtualBoard.GetKomaFromAdress(PlacedKoma.Adress);
            VirtualBoard.Add(new KomaInfo(MainSystem._AirKoma, vPlaceKoma.Adress, CurrentTeam));
            vPlaceKoma.Adress = vPlacedKoma.Adress;
            VirtualBoard.Remove(vPlacedKoma);
            return VirtualBoard;
        }

        public static List<KomaInfo> GetVirtualMoveBoard(
            this List<KomaInfo> KomaInfos,
            Koma PlaceKoma,
            KomaInfo PlacedKoma,
            Team CurrentTeam
        )
        {
            return KomaInfos.GetVirtualMoveBoard(
                new KomaInfo(PlaceKoma, PlacedKoma.Adress, CurrentTeam),
                PlacedKoma,
                CurrentTeam
            );
        }

        public static KeyValuePair<int, KeyValuePair<Koma, KomaInfo>> MostStackSelectBehavior(
            this List<KomaInfo> KomaInfos,
            int BoardSize,
            Team CurrentTeam,
            List<Koma> Stacks
        )
        {
            KeyValuePair<Koma, KomaInfo> saveData = new KeyValuePair<Koma, KomaInfo>();

            int temp = 100;
            //スタックの駒をランダムな空気の場所に配置実行
            foreach (Koma item in Stacks)
            {
                foreach (KomaInfo RandomAir in KomaInfos)
                {
                    if (RandomAir.Team == Team.None)
                    {
                        KomaInfo PlaceKoma = new KomaInfo(item, RandomAir.Adress, CurrentTeam);

                        List<KomaInfo> firestBoard = KomaInfos.GetVirtualMoveBoard(
                           item,
                            RandomAir,
                            CurrentTeam
                        );

                        int MyScore = PlaceKoma.GetPlaceableMostHighScore(BoardSize, CurrentTeam,firestBoard)
                            .Koma.Score;

                        int NextScore = firestBoard
                            .GetMostBehavior(BoardSize, CurrentTeam.ReverseTeam(), false)
                            .Key;

                        int result = MyScore - NextScore;
                        if (temp == 100)
                        {
                            temp = result;
                             saveData = new KeyValuePair<Koma, KomaInfo>(item, RandomAir);
                    
                        }
                        if (result > temp)
                        {
                            temp = result;
                            saveData = new KeyValuePair<Koma, KomaInfo>(item, RandomAir);
                        }
                    }
                }

              
            }

return new KeyValuePair<int, KeyValuePair<Koma, KomaInfo>>(temp,saveData);
        }
        
//ゲーム理論のミニマックス法
        public static KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>> GetMiniMaxBehavior(
            this List<KomaInfo> KomaInfos,
            int BoardSize,
            Team CurrentTeam,
            int Strength=0
        )
        {
            int TempScore = 100;
            KeyValuePair<KomaInfo, KomaInfo> temp = new KeyValuePair<KomaInfo, KomaInfo>();
            List<KomaInfo> VirtualBoard=new List<KomaInfo>();
          Team OriTeam=CurrentTeam;
             foreach (
                KeyValuePair<
                    int,
                    KeyValuePair<KomaInfo, KomaInfo>
                > item in KomaInfos.GetAllWaysBehavior(BoardSize, CurrentTeam)
            )
            {
                int Score=0;

                var KomaPlaceAndPlaced = item.Value;
             
                //自分のランダムに動かした時に取れる駒ランク
                Score += item.Key;
                //実際にランダムに動かした盤面を取得

                VirtualBoard = KomaInfos.GetVirtualMoveBoard(
                    KomaPlaceAndPlaced.Key,
                    KomaPlaceAndPlaced.Value,
                    CurrentTeam
                );
 //ランダムに動かした後の相手の最も取れる駒のランク
                var NextScore = VirtualBoard.GetMostBehavior(
                    BoardSize,
                    CurrentTeam.ReverseTeam(),
                    false
                );
                Score-=NextScore.Key;

for (var i = 0; i < Strength; i++)
{
      
if (CurrentTeam==OriTeam)
{
      //ランダムに動かした後の自分の最も取れる駒のランク
                 var MyScore = VirtualBoard.GetMostBehavior(
                    BoardSize,
                    CurrentTeam,
                    false
                );
                  Score+=MyScore.Key;

                 NextScore = VirtualBoard.GetMostBehavior(
                    BoardSize,
                    CurrentTeam.ReverseTeam(),
                    false
                );
                Score-=NextScore.Key;
      

}else
{
    
//ランダムに動かした後の自分の最も取れる駒のランク
                 var MyScore = VirtualBoard.GetMostBehavior(
                    BoardSize,
                    CurrentTeam,
                    false
                );
                  Score-=MyScore.Key;

                 NextScore = VirtualBoard.GetMostBehavior(
                    BoardSize,
                    CurrentTeam.ReverseTeam(),
                    false
                );
                Score+=NextScore.Key;
      

}
                      
CurrentTeam=CurrentTeam.ReverseTeam();
                 VirtualBoard = VirtualBoard.GetVirtualMoveBoard(
                    NextScore.Value.Key,
                    NextScore.Value.Value,
                    CurrentTeam
                );   



}


                //最初のみ
                if (TempScore == 100)
                {
                    TempScore = Score;
                    temp = new KeyValuePair<KomaInfo, KomaInfo>(
                        KomaPlaceAndPlaced.Key,
                        KomaPlaceAndPlaced.Value
                    );
                }
                //次のループから
                if (Score > TempScore)
                {
                    TempScore = Score;
                    temp = new KeyValuePair<KomaInfo, KomaInfo>(
                        KomaPlaceAndPlaced.Key,
                        KomaPlaceAndPlaced.Value
                    );
                }
            }

            Debug.Log(temp);
            return new KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>>(
                temp.Value.Koma.Score,
                temp
            );
        }

        public static KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>> GetSeeFutureBehavior(
            this List<KomaInfo> KomaInfos,
            int BoardSize,
            Team CurrentTeam
        )
        {
            int TempScore = 100;
            KeyValuePair<KomaInfo, KomaInfo> temp = new KeyValuePair<KomaInfo, KomaInfo>();

            //ランダムに動かしたもの全パターンループ
            foreach (
                KeyValuePair<
                    int,
                    KeyValuePair<KomaInfo, KomaInfo>
                > item in KomaInfos.GetAllWaysBehavior(BoardSize, CurrentTeam)
            )
            {
                var KomaPlaceAndPlaced = item.Value;

                //自分のランダムに動かした時に取れる駒ランク
                int BeforeScore = item.Key;
                //実際にランダムに動かした盤面を取得

                List<KomaInfo> firestBoard = KomaInfos.GetVirtualMoveBoard(
                    KomaPlaceAndPlaced.Key,
                    KomaPlaceAndPlaced.Value,
                    CurrentTeam
                );

                //ランダムに動かした後の相手の最も取れる駒のランク
                int NextScore = firestBoard.GetMostBehavior(BoardSize, CurrentTeam, false).Key;
                Debug.Log("Next" + NextScore);

                //差分をとる
                int Score = BeforeScore + NextScore;

                //最初のみ
                if (TempScore == 100)
                {
                    TempScore = Score;
                    temp = new KeyValuePair<KomaInfo, KomaInfo>(
                        KomaPlaceAndPlaced.Key,
                        KomaPlaceAndPlaced.Value
                    );
                }
                //次のループから
                if (Score > TempScore)
                {
                    Debug.Log("Next" + NextScore);
                    Debug.Log("Behore" + BeforeScore);
                    TempScore = Score;
                    temp = new KeyValuePair<KomaInfo, KomaInfo>(
                        KomaPlaceAndPlaced.Key,
                        KomaPlaceAndPlaced.Value
                    );
                }
            }

            Debug.Log(temp);
            return new KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>>(TempScore, temp);
        }
    }
}
