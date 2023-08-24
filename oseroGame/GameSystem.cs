using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using DG.Tweening;

namespace osero
{
    public enum nowturn
    {
        black,
        white
    }

    public class GameSystem : MonoBehaviour
    {[Button("render","render")]
        public int ii;

        public void render(){
            board.render();
        }
        public GameObject TouchEffect;
        public nowturn nowturn;
        public board board;
        public koma TouchKoma;
        public message message;
        public TMPro.TextMeshProUGUI scoretext;
        public TMPro.TextMeshProUGUI turntext;
        public Image turnimage;
        public System.Action turnEndcall,
            GameSetCallback,
            GameSetUpCallback,
            PlaceMissCallback;
        public bool AutoReflashGame;
        public bool Touchable = true;
        
        public Dictionary<koma, int> GetAllPlaceableData(nowturn nowturns)
        {
            Dictionary<koma, int> KomaPlaceableNumDictionary = new Dictionary<koma, int>();
            foreach (var item in board.komas)
            {
                if (item != null)
                {
                    var PlaceableKomas = DetectKomaAndChanges(item, nowturns);
                    if (PlaceableKomas.Count > 1)
                    {
                        KomaPlaceableNumDictionary.Add(item, PlaceableKomas.Count);
                    }
                }
            }
            return KomaPlaceableNumDictionary;
        }

        public static komatype GetTurnToKomaType(nowturn nowturns)
        {
            return nowturns == nowturn.black ? komatype.black : komatype.white;
        }

        public static komatype GetReverseTurnToKomaType(nowturn nowturns)
        {
            return nowturns == nowturn.black ? komatype.white : komatype.black;
        }

        public static nowturn GetReverseTurn(nowturn nowturns)
        {
            return nowturns == nowturn.black ? nowturn.white : nowturn.black;
        }

        void Message(string mes)
        {
            if (message != null)
            {
                message.SetMessagePanel(mes, true);
            }
        }

        public void MessageSet()
        {
            turnEndcall += () =>
            {
                var st = nowturn == nowturn.black ? "黒" : "白";
                Message(st + "のターンになった。");
            };
            PlaceMissCallback += () =>
            {
                Message("この場所にはおけないみたいだ。");
            };
            GameSetCallback += () =>
            {
                Message("決着しました。");
            };
        }

        public void SetUp()
        {
            board.Reset();
            int n = (int)board.boardsize / 2;
            board.komas[n - 1, n].Change(komatype.black);
            board.komas[n, n - 1].Change(komatype.black);
            board.komas[n, n].Change(komatype.white);
            board.komas[n - 1, n - 1].Change(komatype.white);
            board.Counter();
            if (GameSetUpCallback != null)
            {
                GameSetUpCallback();
            }
           GameSetCallback=()=>{
if (AutoReflashGame)
{
    SetUp();
    GameSetOnce=false;
}
 };
           
        }

        void Awake()
        { 
            MessageSet();
            SetUp();
        }

        bool NoPlaceable;

        public void TurnChange()
        {
            nowturn = nowturn == nowturn.black ? nowturn.white : nowturn.black;
            var data = GetAllPlaceableData(nowturn);
            if (data.Count == 0)
            {
                if (NoPlaceable)
                {
                    GameSet();
                    Message("双方のおける場所がなくなってしまった。");
                }
                else
                {
                    NoPlaceable = true;
                    TurnChange();
                }
            }
            else
            {
                NoPlaceable = false;
            }

            turnEndcall();
        }

        public bool KomaTryPlace(koma koma)
        {
            if (koma.komatype == komatype.none)
            {
                var allchangekoma = DetectKomaAndChanges(koma, nowturn);
                if (allchangekoma.Count > 1)
                {
                    foreach (var item in allchangekoma)
                    {
                        item.Change(GetTurnToKomaType(nowturn));
                    }
                    TurnChange();
                    board.Counter();
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        void MainLoop()
        {
            TouchKoma = TouchGetKoma();
            if (TouchKoma != null)
            {
                Debug.Log("osero");
                if (!KomaTryPlace(TouchKoma))
                {
                    PlaceMissCallback();
                }
                TouchKoma = null;
            }
            if (board.blackcount == 0 || board.whitecount == 0 || board.RestSpaceCount() == 0)
            {
                if (!GameSetOnce)
                {
                    GameSetOnce = true;
                    GameSet();
                }
            }
        }

        public bool GameSetOnce;

        void UILoop()
        {
            if (scoretext != null)
            {
                scoretext.text =
                    "白"
                    + board.whitecount.ToString()
                    + "枚"
                    + "　黒"
                    + board.blackcount.ToString()
                    + "枚";
            }
            if (turntext != null)
            {
                turntext.text = nowturn == nowturn.black ? "黒のターン" : "白のターン";
            }
            if (turnimage != null)
            {
                turnimage.material.color = nowturn == nowturn.black ? Color.black : Color.white;
            }
        }

        void Update()
        {
            MainLoop();
            UILoop();
        }

        public List<koma> DetectKomaAndChanges(koma komas, nowturn nowturns)
        {
            List<koma> TootalChangeKomas = new List<koma>();

            if (komas.komatype != komatype.none)
            {
                return TootalChangeKomas;
            }
            TootalChangeKomas.Add(komas);
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    var detect = DetectKomaAndChange(komas, new Vector2(i, j), nowturns);
                    if (detect != null)
                    {
                        TootalChangeKomas.AddRange(detect);
                    }
                }
            }
            return TootalChangeKomas;
        }

        public List<koma> DetectKomaAndChange(koma komas, Vector2 direction, nowturn nowturns)
        {
            var SearchPos = komas.Adress + direction;

            var ChangeKomas = new List<koma>();

            try
            {
                while (
                    board.komas[(int)SearchPos.x, (int)SearchPos.y].komatype== GetReverseTurnToKomaType(nowturns)
                )
                {
                    ChangeKomas.Add(board.komas[(int)SearchPos.x, (int)SearchPos.y]);
                    SearchPos += direction;

                    if (
                        (int)SearchPos.x < 0
                        || (int)SearchPos.x > board.boardsize
                        || (int)SearchPos.y < 0
                        || (int)SearchPos.y > board.boardsize
                    )
                    {
                        return null;
                    }
                }

                if (
                    board.komas[(int)SearchPos.x, (int)SearchPos.y]?.komatype
                    == GetTurnToKomaType(nowturns)
                )
                {
                    return ChangeKomas;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }

            return null;
        }

        public koma TouchGetKoma()
        {
            if (Touchable)
            {
                RaycastHit hit = keikei.mousePositionObj();
                if (hit.point != Vector3.zero)
                {
                    if (TouchEffect != null)
                    {
                        Instantiate(TouchEffect, hit.point, Quaternion.identity);
                    }
                    return board.GetKoma(hit.collider.gameObject);
                }
            }
            return null;
        }

        public void RetryGame()
        {
            board.KomaDestroy();
            SetUp();
        }

        public IEnumerator GameSetKomaAnimation()
        {float hw=0;float hb=0;
            foreach (var item in board.komas)
            {
                item.Change(item.komatype);
            }
            yield return new WaitForSeconds(Time.deltaTime);
            foreach (var item in board.komas)
            {
                if (item.komatype == komatype.black)
                {
                    item.komaobj.transform.DOMove(BlackKomaSpace.position+new Vector3(0,KomaHight*hb,0), 1f);
            hb++;
                }
                if (item.komatype == komatype.white)
                {
                    item.komaobj.transform.DOMove(WhiteKomaSpace.position+new Vector3(0,KomaHight*hw,0), 1f);
             hw++;
                }
                yield return new WaitForSeconds(Time.deltaTime);
               
            }

            yield return null;
        }

        public Transform BlackKomaSpace;
        public Transform WhiteKomaSpace;
        public float KomaHight = 0.3f;

        public void GameSet()
        {  GameSetCallback();
        if (!AutoReflashGame)
        {
              StartCoroutine(GameSetKomaAnimation());
        }
            
        }
    }
}
