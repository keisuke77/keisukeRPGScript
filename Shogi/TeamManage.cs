using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

using DG.Tweening;

namespace Shogi
{
    [System.Serializable]
    public class UI
    {
         [HideInInspector]
        public RawImage IconImage;

        [HideInInspector]
        public Text StackNumberText;

        public void SetUp()
        {
            StackNumberText = IconImage.gameObject.GetComponentInChildren<Text>();
        }
    }

    [System.Serializable]
    public class TeamInfo
    {
        public Dictionary<Koma, int> KomaStack;
        public List<UI> UIs;
         public List<RawImage> IconImage;
float oriScale;
        public void AddKoma(Koma Koma)
        {
            if (KomaStack.ContainsKey(Koma))
            {
                KomaStack[Koma] += 1;
            }
            else
            {
                KomaStack.Add(Koma, 1);
            }
        }

        public void UseKoma(Koma Koma)
        {
            if (KomaStack.ContainsKey(Koma))
            {
                KomaStack[Koma] -= 1;
            }
            if (KomaStack[Koma] < 1)
            {
                KomaStack.Remove(Koma);
            }
        }

        public void SetUp()
        {int num=0;
            foreach (var item in UIs)
            {item.IconImage= IconImage[num];
            num++;
                item.SetUp();
            }
            oriScale= UIs[0].IconImage.gameObject.transform.localScale.x;
            KomaStack = new Dictionary<Koma, int>();
        }

        public void UIUpdate(MainSystem MainSystem = null, System.Action ac = null)
        {
            //初期化
            foreach (var UI in UIs)
            {
                if (UI.IconImage.gameObject.GetComponentIfNotNull<Button>() != null)
                {
                    UI.IconImage.gameObject.GetComponentIfNotNull<Button>().targetGraphic = null;
                }
                UI.IconImage.color = new Color(0, 0, 0, 0);
                UI.IconImage.gameObject.transform.DOScale(oriScale, 0.2f);
                UI.IconImage.texture = null;
                UI.StackNumberText.text = null;
            }

            if (KomaStack.Count > 0)
            {
                int i = 0;

                foreach (var item in KomaStack)
                {
                    var UI = UIs[i];

                    var btn = UI.IconImage.gameObject.AddComponentIfnull<Button>() as Button;
                    btn.targetGraphic = UI.IconImage;
                    Koma Koma = item.Key;
                    btn.onClick.RemoveAllListeners();
                    if (MainSystem != null)
                    {
                        btn.onClick.AddListener(() =>
                        {
                            MainSystem.CurrentSelectKoma = Koma;

                            UI.IconImage.gameObject.transform.DOScale(oriScale*1.1f, 0.3f);
                            ac();
                        });
                    }
                    
                    UI.IconImage.color = Color.white;
                    UI.IconImage.texture = item.Key.NormalIcon;
                    UI.StackNumberText.text = item.Value.ToString();
                    i++;
                }
            }
        }
    }
}
