using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class mathshot : MonoBehaviour
{
    public InputField inputField;
    public int problemcount = 10;
    public Image backimage;
    public float time;

    [Range(1, 4)]
    public int keta = 2;
    public int answercount = 0;
    public int rightanswercount = 0;
    public int onenumber;
    public int twonumber;
    public int rightnumber;
    public Text mathproblem;
    public Text marubasu;
    public Text timetext;
    public bool timestart;
    public Button startbutton;
    public Tween tween;
    public float onelimittime;
    string texts;

    void Start()
    {
        marubasu.text = "暗算マスター機";
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        startbutton.onClick.AddListener(mathstart);
    }

    public enum enzansi
    {
        plus,
        hiku,
        waru,
        kakeru
    }

    public enzansi enzansis;

    void FixedUpdate()
    {
        if (timestart)
        {
            time += Time.deltaTime;
            timetext.text =
                "経過時間:"
                + time.ToString("F2")
                + "残り"
                + (problemcount - rightanswercount).ToString()
                + "問";
        }
        else
        {
            time = 0;
        }
    }

    public void mathstart()
    {
        createproblem();
        marubasu.text = "暗算マスター機";
        timestart = true;
        startbutton.gameObject.SetActive(false);
        tween = backimage.DOFade(1, onelimittime).OnComplete(gameover);
    }

    public void createproblem()
    {
        tween.Restart();
        if (keta == 1)
        {
            onenumber = Random.Range(0, 9);
            twonumber = Random.Range(0, 9);
        }
        if (keta == 2)
        {
            onenumber = Random.Range(10, 99);
            twonumber = Random.Range(10, 99);
        }
        if (keta == 3)
        {
            onenumber = Random.Range(100, 999);
            twonumber = Random.Range(100, 999);
        }
        if (keta == 4)
        {
            onenumber = Random.Range(1000, 9999);
            twonumber = Random.Range(1000, 9999);
        }

        switch (enzansis)
        {
            case enzansi.plus:
                rightnumber = onenumber + twonumber;
                texts = onenumber.ToString() + "+" + twonumber.ToString();
                break;
            case enzansi.kakeru:
                rightnumber = onenumber * twonumber;
                texts = onenumber.ToString() + "×" + twonumber.ToString();
                break;
            case enzansi.waru:
                rightnumber = onenumber / twonumber;
                texts = onenumber.ToString() + "÷" + twonumber.ToString();
                break;
            case enzansi.hiku:
                rightnumber = onenumber - twonumber;
                texts = onenumber.ToString() + "-" + twonumber.ToString();

                break;
            default:
                break;
        }

        mathproblem.DOText(texts, 0.5f);
    }

    public void gameover()
    {
        marubasu.text =
            "ゲームオーバー。。 かかった時間："
            + ((int)time).ToString()
            + "成績："
            + (10000 / (rightanswercount) * (int)time).ToString();

        backimage.DOFade(0, 0.5f);
        marubasu.color = Color.blue;

        reset();
    }

    public void answer()
    {
        if (rightnumber == int.Parse(inputField.text))
        {
            rightanswercount++;
            marubasu.text = "正解！！";
            marubasu.color = Color.red;

            marubasu.transform.DOLocalJump(Vector3.zero, 100f, 1, 1, false);
            if (problemcount == rightanswercount)
            {
                clear();
                return;
            }
            else
            {
                createproblem();
            }
            Invoke("deletetext", 1f);
        }
    }

    void deletetext()
    {
        inputField.text = "";
    }

    void clear()
    {
        marubasu.text =
            "ステージクリア！！ かかった時間："
            + ((int)time).ToString()
            + "成績："
            + (10000 / (rightanswercount) * (int)time).ToString();
        reset();
    }

    public void reset()
    {
        timestart = false;
        timetext.text = "";
        startbutton.gameObject.SetActive(true);
        rightanswercount = 0;
        rightnumber = 922190;
        mathproblem.text = "";
    }
}
