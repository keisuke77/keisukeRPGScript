using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
    public class SelectButton
    {
        public Button button;
        Color defaultcolor;
        Image img;
        Outline Outline;
        float scaleUp = 1;
        public Vector3 originSacle;

        public SelectButton(Button btn, float scaleUps, Vector2 OutLineWidthHights)
        {
            button = btn;
            scaleUp = scaleUps;
            originSacle = button.gameObject.transform.localScale;
            Outline = button.gameObject.AddComponentIfnull<Outline>() as Outline;
            Outline.effectDistance = OutLineWidthHights;
            img = button.gameObject.GetComponent<Image>();
            defaultcolor = img.color;
        }

        public void DeSelect()
        {
            img.color = defaultcolor;
            Outline.enabled = false;
            button.transform.DOScale(originSacle, 0.5f);
        }

        public void Select(Color SelectColor, Color OutlineColor)
        {
            img.color = SelectColor;
            Outline.effectColor = OutlineColor;
            Outline.enabled = true;
            button.transform.DOScale(originSacle * scaleUp, 0.5f);
        }
    }

    public List<SelectButton> SelectButtons;
    public Color SelectColor;
    public Color OutlineColor;
    public int active;
    SelectButton currentButton;
    public float scaleUpAmount = 1.3f;
    public float ClickPower = 1.5f;
    public Vector2 OutLineWidthHight;

    [Button("SetUp", "SetUp")]
    public int Reset;

    void SetUp()
    {
        var buttons = gameObject.GetComponentsInChildren<Button>();
        SelectButtons = new List<SelectButton>();
        foreach (var item in buttons)
        {
            SelectButtons.Add(new SelectButton(item, scaleUpAmount, OutLineWidthHight));
        }
        reset();
    }

    void Awake()
    {
        SetUp();
    }

    public void reset()
    {
        foreach (var item in SelectButtons)
        {
            item.DeSelect();
        }
    }

    void OnSelect()
    {
        reset();
        currentButton.Select(SelectColor, OutlineColor);
    }

    void OnClick()
    {
        currentButton.button.onClick.Invoke();
        currentButton.button.transform.DOPunchScale(Vector3.one * ClickPower, 0.8f, 5, 1f);
    }

    int beforeactive;

    void Update()
    {
        if (keiinput.Instance.add)
        {
            active++;
        }
        if (keiinput.Instance.down)
        {
            active--;
        }
        if (keiinput.Instance.decide)
        {
            OnClick();
        }
        active = (int)Mathf.Repeat(active, SelectButtons.Count);

        currentButton = SelectButtons[active];
        if (active != beforeactive)
        {
            beforeactive = active;
            OnSelect();
        }
    }
}
