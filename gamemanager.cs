using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public hp hp;
    public enemyhp enemyhp;
   public float timer;
    public Text text;
    public gamescore gamescore;
    public static gamemanager instance;
    // Start ist called before the first frame update
    void Start()
    {
        instance=this;
        gamescore.reset();
    }
public void gameend(){

    gamescore.cleartime=timer;
}
    // Update is called once per frame
    void Update()
    {timer+=Time.deltaTime;
        text.text="経過時間:"+timer.ToString("F2");
        gamescore.hp=hp.HP;
        gamescore.givedamage=enemyhp.maxHP-enemyhp.HP;
    }
}
