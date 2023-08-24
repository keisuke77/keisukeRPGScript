using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using System.Linq;

namespace osero
{
    public class oseroAI : MonoBehaviour
    {
        public GameSystem GameSystem;
        public nowturn executeturn;

        public float speed = 1;

        [Header("残りの置く場所がこの数値より小さくなったら多めにとるようになる")]
        public int StragyChangePoint = 12;

        [Header("端を優先するか？")]
        public bool hasiCheck = true;

        [Header("角を優先するか？")]
        public bool KadoCheck = true;

        public bool AIAttack;
        public bool AISupport;

        public List<koma> MinGet(Dictionary<koma, int> data)
        {
            var minValue = data.Values.Min();
            var minElem = data.Where(c => c.Value == minValue).ToDictionary(x => x.Key, y => y.Value).Keys.ToList();
            return minElem;
        }

        public List<koma> MostGet(Dictionary<koma, int> data)
        {
            var maxValue = data.Values.Max();
            var maxElem = data.Where(c => c.Value == maxValue).ToDictionary(x => x.Key, y => y.Value).Keys.ToList();
            return maxElem;
        }




public List<koma> GetKomasByCondition(Dictionary<koma, int> data, Func<Vector3, bool> condition)
{
    var komas = new List<koma>();
    foreach (var item in data.Keys)
    {
        if (condition(item.Adress))
        {
            komas.Add(item);
        }
    }
    return komas;
}





        public List<koma> KadoGet(Dictionary<koma, int> data)
        {
            List<koma> komas = new List<koma>();
            var Dictionary = data;
            var size = GameSystem.board.boardsize;
            foreach (var item in Dictionary.Keys)
            {
                if (
                    new Vector3[]
                    {
                        new Vector2(0, 0),
                        new Vector2(0, size),
                        new Vector2(size, 0),
                        new Vector2(size, size)
                    }.Contains(item.Adress)
                )
                {
                    komas.Add(item);
                }
            }
            return komas;
        }

        public List<koma> hasiGet(Dictionary<koma, int> data)
        {
            List<koma> komas = new List<koma>();
            var Dictionary = data;
            var size = GameSystem.board.boardsize;
            foreach (var item in Dictionary.Keys)
            {
                if (
                    item.Adress.x == 0
                    || item.Adress.x == size
                    || item.Adress.y == 0
                    || item.Adress.y == size
                )
                {
                    komas.Add(item);
                }
            }
            return komas;
        }

        delegate List<koma> Delegate(Dictionary<koma, int> data);
        Delegate d;

        System.Action temp;

        IEnumerator Support()
        {
            if (GameSystem.nowturn == executeturn)
            {
                yield return new WaitForSeconds(speed);

                var data = GameSystem.GetAllPlaceableData(executeturn);
                if (data != null)
                {
                    foreach (koma item in data.Keys)
                    {
                        item.render.material.color = Color.red;
                        temp = () =>
                        {
                            item.render.material.color = item.KomaTypeGetColor();
                            GameSystem.turnEndcall -= temp;
                        };

                        GameSystem.turnEndcall += temp;
                    }
                }
            }
        }

        IEnumerator Attack()
        {
            if (GameSystem.nowturn == executeturn)
            {
                GameSystem.Touchable = false;

                yield return new WaitForSeconds(speed);
                GameSystem.Touchable = true;
                Debug.Log("aiGet");

                var data = GameSystem.GetAllPlaceableData(executeturn);
                if (data.Count == 0)
                {
                    GameSystem.TurnChange();
                    yield break;
                }
                if (GameSystem.board.RestSpaceCount() < StragyChangePoint)
                {
                    d = MostGet;
                }
                else
                {
                    d = MinGet;
                }

                if (hasiCheck)
                {
                    if (hasiGet(data).Count > 0)
                    {
                        d = hasiGet;
                    }
                }
                if (KadoCheck)
                {
                    if (KadoGet(data).Count > 0)
                    {
                        d = KadoGet;
                    }
                }

                GameSystem.KomaTryPlace(d(data).GetAtRandom());
            }
            yield break;
        }

        void datatest()
        {
            StragyChangePoint = (int)UnityEngine.Random.Range(0, GameSystem.board.boardsize);
            if (OseroAIdata.StragyChangePoint.ContainsKey(StragyChangePoint))
            {
                OseroAIdata.StragyChangePoint[StragyChangePoint] +=
                    executeturn == nowturn.black
                        ? GameSystem.board.blackcount
                        : GameSystem.board.whitecount;
            }
            else
            {
                OseroAIdata.StragyChangePoint.Add(
                    StragyChangePoint,
                    executeturn == nowturn.black
                        ? GameSystem.board.blackcount
                        : GameSystem.board.whitecount
                );
            }
        }

        public void Execute()
        {
            if (AIAttack)
            {
                StartCoroutine("Attack");
            }
            if (AISupport)
            {
                StartCoroutine("Support");
            }
            
        }

        void Awake()
        {
            Execute();
            GameSystem.turnEndcall += (() => Execute());
            GameSystem.GameSetCallback += (
                () =>
                {
                    datatest();
                }
            );
        }
    }
}
