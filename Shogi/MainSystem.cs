using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

using DG.Tweening;

namespace Shogi
{
    public enum State
    {
        KomaSelect,
        PlacePosSelect,
        KomaStackSelect,
        PlacePosSelectStack
    }

    [System.Serializable]
    public class ActionButton
    {
        public Button Button;
        public Text Text;

        public void ActionSet(string ActionName, System.Action ac)
        {
            Text.text = ActionName;
            Button.onClick.RemoveAllListeners();
            Button.onClick.AddListener(() => ac());
        }
    }

    public class MainSystem : MonoBehaviour
    {
        public GameObject TouchEffect;
        public GameObject KomaModel;
        public BoardData BoardData;
        public Koma AirKoma;
        public TeamInfo RedTeamInfo;
        public TeamInfo BlueTeamInfo;
        public message message;
        public ActionButton ActionButton;
public static Koma _AirKoma;
        public List<KomaInfo> KomaInfos;

        [HideInInspector]
        public int BoardSize;

        public Team CurrentTeam;
        public State CurrentState;

        public KomaInfo CurrentSelectKomaInfo;
        public Koma CurrentSelectKoma;
        Vector3 OriScale;
        KomaInfo TempCurrentSelectKomaInfo;
        public KomaInfo TouchKoma;

        public void ChangeTurn()
        {
            switch (CurrentTeam)
            {
                case Team.Red:
                    CurrentTeam = Team.Blue;
                    Mesaage("青チームの番だ！");
                    break;
                case Team.Blue:
                    CurrentTeam = Team.Red;
                    Mesaage("赤チームの番だ！");
                    break;
                case Team.None:
                    if (keikei.kakuritu(50))
                    {
                        CurrentTeam = Team.Red;
                        Mesaage("赤チームの番だ！");
                    }
                    else
                    {
                        CurrentTeam = Team.Blue;
                        Mesaage("青チームの番だ！");
                    }

                    break;
                default:

                    break;
            }
        }

        public TeamInfo GetCurrentTeamInfo()
        {
            switch (CurrentTeam)
            {
                case Team.Red:
                    return RedTeamInfo;
                    break;
                case Team.Blue:
                    return BlueTeamInfo;
                    break;
                default:
                    return null;
                    break;
            }
            return null;
        }

        KeyValuePair<KomaInfo, KomaInfo> TempPlaceKomas;

        public void PlaceKoma(KomaInfo KomaInfo, KomaInfo PlacedKomaInfo)
        {
            TempPlaceKomas = new KeyValuePair<KomaInfo, KomaInfo>(
                KomaInfo.Clone(),
                PlacedKomaInfo.Clone()
            );
            //もともとあった場所にエアーコマ生成
            var instance=new KomaInfo(AirKoma, KomaInfo.Adress,Team.None, false);
            instance.Create(KomaModel); 
            KomaInfos.Add(instance);
            //アドレスを変える
            KomaInfo.ChangeAdress(PlacedKomaInfo.Adress);

            Destroy(PlacedKomaInfo.obj);
            KomaInfos.Remove(PlacedKomaInfo);

            if (KomaInfo.NariCheck(BoardSize))
            {
                KomaInfo.Nari();
            }

            //スタック追加
            if (PlacedKomaInfo.Koma != AirKoma)
            {
                GetCurrentTeamInfo().AddKoma(PlacedKomaInfo.Koma);
            }
            if (PlacedKomaInfo.King)
            {
                Mesaage("Winner!!!!!!!!!!!!!");
            }
        }

        public void PlaceKoma(KomaInfo KomaInfo)
        {
            KomaInfo Before = KomaInfos.GetKomaFromAdress(KomaInfo.Adress);
            KomaInfos.Remove(Before);
            Destroy(Before.obj);
            KomaInfos.Add(KomaInfo);
        }

        public void PlaceKoma(Koma Koma, KomaInfo PlacedKomaInfo)
        { var instance=new KomaInfo(Koma, PlacedKomaInfo.Adress, CurrentTeam);
            instance.Create(KomaModel); 
            PlaceKoma(instance);
        }

        public void ReturnPlace()
        {
            PlaceKoma(TempPlaceKomas.Key);
            PlaceKoma(TempPlaceKomas.Value);
        }

        public KomaInfo AIInput;

        public KomaInfo TouchGetKoma()
        {
            RaycastHit hit = keikei.mousePositionObj();
            if (hit.collider != null)
            {
                if (TouchEffect != null)
                {
                    Instantiate(TouchEffect, hit.point, Quaternion.identity);
                }
                return KomaInfos.GetKoma(hit.collider.gameObject);
            }

            return null;
        }

       public void SwitchState(State states)
        {
            TouchKoma = null;
            CurrentState = states;
            switch (CurrentState)
            {
                case State.KomaSelect:
                    Mesaage("動かす駒を選ぼう！");
                    ActionButton.ActionSet(
                        "手持ちの駒から選ぶ",
                        () =>
                        {
                            if (GetCurrentTeamInfo().KomaStack.Count == 0)
                            {
                                Mesaage("手持ちの駒がないみたいだ。。。");
                                return;
                            }
                            SwitchState(State.KomaStackSelect);
                        }
                    );
                    break;
            
                case State.KomaStackSelect:
                    CurrentSelectKoma = null;
                    Mesaage("使用したい持ち駒を選ぼう");

                    Mesaage("使用する持ち駒を選ぼう！");
                    ActionButton.ActionSet(
                        "盤面の駒から選ぶ",
                        () =>
                        {
                            SwitchState(State.KomaSelect);
                        }
                    );
                    break;
                default:
                    break;
            }
        }

        public void Mesaage(string mes)
        {
            if (message != null)
            {
                message.SetMessagePanel(mes, true);
            }
        }

         void FixedUpdate() {
     
            switch (CurrentState)
            {
               
                case State.KomaSelect:
var temp=TouchGetKoma();
if (temp!=null)
{
     TouchKoma = temp;
}
                     if (TouchKoma == null)
                        {
                            return;
                        }

                    if (CurrentSelectKomaInfo.Koma == null)
                    {
                       
                        if (TouchKoma.Koma == AirKoma)
                       {
                            Mesaage("そこに駒はないよ！");
                            return;
                        }
                        if (TouchKoma.Team != CurrentTeam)
                        {
                            Mesaage("自分チームのコマを選んで！");
                            return;
                        }

                        CurrentSelectKomaChange(TouchKoma);
                        TouchKoma=null;
                    }
                    else
                    {
                       
                        if (TouchKoma.Team == CurrentTeam)
                        {
                            CurrentSelectKomaChange(TouchKoma);
                            return;
                        }
                        if (
                            CurrentSelectKomaInfo
                                .GetMoveableAdress(BoardSize, CurrentTeam, KomaInfos)
                                .Contains(TouchKoma.Adress)
                        )
                        {
                            PlaceKoma(CurrentSelectKomaInfo, TouchKoma);
                            TurnEnd();
                        }
                        else
                        {
                            Mesaage("その場所にはおけないみたいだ");
                        }
                    }

                    break;
                case State.PlacePosSelectStack:

                  
var temps=TouchGetKoma();
if (temps!=null)
{
     TouchKoma = temps;
}
                     if (TouchKoma == null)
                        {
                            return;
                        }
                    
                    
               
                    if (TouchKoma.Koma == AirKoma)
                    {
                        PlaceKoma(CurrentSelectKoma, TouchKoma);
                        GetCurrentTeamInfo().UseKoma(CurrentSelectKoma);
                        TurnEnd();
                    }
                    else
                    {
                        Mesaage("その場所にはおけないみたいだ");
                    }
                    break;

                default:
                    break;
            }
        }

        public void ColorReset()
        {
            foreach (KomaInfo item in KomaInfos)
            {
                if (item.Koma == AirKoma)
                {
                    item.ChangeColor(new Color(0, 0, 0, 0));
                }
                else
                {
                    item.ChangeColor(Color.white);
                }
            }
        }

        public void CurrentSelectKomaChange(KomaInfo KomaInfo)
        {
            ColorReset();
            if (KomaInfo != null)
            {
                if (KomaInfo.obj != null)
                {
                    CurrentSelectKomaInfo = KomaInfo;
                    CurrentSelectKomaInfo.obj.transform.DOScale(OriScale * 1.2f, 0.4f);
                    foreach (
                        Vector2 item in CurrentSelectKomaInfo.GetMoveableAdress(
                            BoardSize,
                            CurrentTeam,
                            KomaInfos
                        )
                    )
                    {
                        KomaInfos.GetKomaFromAdress(item).ChangeColor(Color.red);
                    }
                }
            }

            if (TempCurrentSelectKomaInfo != null)
            {
                if (TempCurrentSelectKomaInfo.obj != null)
                {
                    TempCurrentSelectKomaInfo.obj.transform.DOScale(OriScale * 1f, 0.4f);
                }
            }
            TempCurrentSelectKomaInfo = CurrentSelectKomaInfo;
        }

        public void TurnEnd()
        {
            CurrentSelectKomaInfo = null;
            CurrentSelectKoma = null;
　　　　　 　TouchKoma=null;
            GetCurrentTeamInfo().UIUpdate();
            ColorReset();
            ChangeTurn();
            GetCurrentTeamInfo()
                .UIUpdate(
                    this,
                    () =>
                    {
                        SwitchState(State.PlacePosSelectStack);
                    }
                );
            SwitchState(State.KomaSelect);
          
        }

        void Awake()
        {_AirKoma=AirKoma;
            SetUp();
            TurnEnd();
        }

        public void SetUp()
        {
            BoardSize = BoardData.BoardSize;
            BoardData b = Instantiate(BoardData);

            KomaInfos = new List<KomaInfo>(b.KomaInfos);
            RedTeamInfo.SetUp();
            BlueTeamInfo.SetUp();
            foreach (var item in KomaInfos)
            {
                item.Create(KomaModel);
                item.obj.transform.parent=transform;
            }
            //アドレスが割り当てられてない場所を検知して空の駒を置く
            foreach (Vector3 item in KomaInfos.NothingAdress(BoardSize))
            { var instance=new KomaInfo(AirKoma, item, Team.None);
                instance.Create(KomaModel); 
                KomaInfos.Add(instance);
            }
            ColorReset();
            OriScale = KomaInfos[0].obj.transform.localScale;
        }
    }
}
