using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

using Unity.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
namespace Shogi
{
    public enum Behaviour
    {
        Random,
        GetMost,
        MiniMax,
    }

    public class ShogiAI : MonoBehaviour
    {
        public MainSystem MainSystem;
        public Team Team;
        List<KomaInfo> KomaInfos;
        KeyValuePair<int, KeyValuePair<KomaInfo, KomaInfo>> AIInput;
         [SerializeField, ReadOnly]
        private KeyValuePair<int, KeyValuePair<Koma, KomaInfo>> AIInputStack;
        public KomaInfo AIInputplace;
        public KomaInfo AIInputplaced;

        [Range(0, 10)]
        public int Strength;

       public bool stackUse;

    [SerializeField, ReadOnly]       private bool isStackUse;
        Dictionary<KomaInfo, KomaInfo> Data;
        public float Interval;

        void OnEnable()
        {
            }

        void OnDisable()
        {
            CancelInvoke();
        }
private void Update() {
  
}private void FixedUpdate() {
      MainLoop();
}
        public List<KomaInfo> GetTeamKomas()
        {
            List<KomaInfo> result = new List<KomaInfo>();
            foreach (var item in MainSystem.KomaInfos)
            {
                if (item.Team == Team)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public KomaInfo AIPlaceSelect()
        {
            return MainSystem.KomaInfos.GetAtRandom();
        }

        public KomaInfo AISelectKoma()
        {
            return KomaInfos.GetAtRandom();
        }

        public Koma AIStackSelect()
        {
            return null;
        }

        bool Once = true;
        public Behaviour CurrentBehaviour;

       async UniTaskVoid AIInputValue()
        {
             await UniTask.SwitchToThreadPool();
     
            switch (CurrentBehaviour)
            {
                case Behaviour.Random:
                    AIInput = MainSystem.KomaInfos
                        .GetAllBehavior(MainSystem.BoardSize, Team)
                        .GetAtRandom();

                    break;
                case Behaviour.GetMost:
                    AIInput = MainSystem.KomaInfos.GetMostBehavior(MainSystem.BoardSize, Team);

                    break;
                case Behaviour.MiniMax:
                    AIInput = MainSystem.KomaInfos.GetMiniMaxBehavior(
                        MainSystem.BoardSize,
                        Team,
                        Strength
                    );


                    break;

                default:
                    break;
            }
            if (stackUse)
            {
                if (MainSystem.GetCurrentTeamInfo().KomaStack.Count != 0)
                {
                    AIInputStack = MainSystem.KomaInfos.MostStackSelectBehavior(
                        MainSystem.BoardSize,
                        Team,
                        MainSystem.GetCurrentTeamInfo().KomaStack.Keys.ToList()
                    );
                    //スタックのほうがスコアでかかったとき
                    if (AIInput.Key < AIInputStack.Key)
                    {
                        isStackUse = true;
                    }
                }
            }
            AIInputplace = AIInput.Value.Key;
            AIInputplaced = AIInput.Value.Value;
            
   
        }

        public void MainLoop()
        {
            if (MainSystem.CurrentTeam == Team)
            {
                if (Once)
                {
                    Once = false;
                    AIInputValue();
                }

                switch (MainSystem.CurrentState)
                {
                    case State.KomaSelect:

                        if (isStackUse)
                        {
                            MainSystem.CurrentSelectKoma = AIInputStack.Value.Key;
                            MainSystem.SwitchState(State.PlacePosSelectStack);
                        }
                        else
                        {
                            if (MainSystem?.CurrentSelectKomaInfo?.Koma == null)
                            {
                                MainSystem.TouchKoma = AIInputplace;AIInputplace=null;
                            }
                            else
                            {
                                MainSystem.TouchKoma = AIInputplaced;AIInputplaced=null;
                            }
                        }

                        break;
                    case State.PlacePosSelectStack:
                        MainSystem.TouchKoma = AIInputStack.Value.Value;

                        break;

                    default:
                        break;
                }
            }
            else
            {
                isStackUse = false;
                Once = true;
            }
        }
    }
}
