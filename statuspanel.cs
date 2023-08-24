using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class statuspanel : MonoBehaviour
{
    data playerdata;
    public Text hptext;
    public Text leveltext;
    public Text moneytext;
    public Text exptext;
    public Text nextexptext;
    public Text totalexptext;
    public Text powertext;
    // Start is called before the first frame update
    void Start()
    {
        playerdata=keikei.playerdata;
    }
private void OnEnable() {
    hptext.text="いまのHP　"+playerdata.maxHP.ToString();
    totalexptext.text="合計経験値　"+playerdata.totalexp.ToString();
    powertext.text="こうげきりょく　"+playerdata.power.ToString();
    nextexptext.text="次のレベルまでの必要経験値　"+playerdata.nextexp.ToString();
    leveltext.text="現在のレベル　"+playerdata.level.ToString();
    
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
