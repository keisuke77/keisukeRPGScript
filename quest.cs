
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
 
[Serializable]
[CreateAssetMenu(fileName = "quest", menuName="Createquest")]
public class quest : ScriptableObject {

public string questname;
public enemysSet enemysSet;
public itemdrops itemdrops;
public int needmoney;
public int needlevel;
public int money;
public int exp;
public string expression;
public Sprite sprite;
public string clearmessage;
public Dictionary<string,int> restenemy;


public void enemykill(string name){
<<<<<<< HEAD
    if (!restenemy.ContainsKey(name))
    {
        return;
    }
restenemy[name]-=1;
if (restenemy[name]==0)
{
warning.instance?.message("クエストターゲット"+name+"を全て倒した！");
}else
{
warning.instance?.message("クエストターゲット"+name+"を倒した！\n残りは"+
=======
restenemy[name]-=1;
if (restenemy[name]==0)
{
warning.message("クエストターゲット"+name+"を全て倒した！");
}else
{
warning.message("クエストターゲット"+name+"を倒した！\n残りは"+
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
restenemy[name]+"体だ！");
}
questclearcheck();
}

public void queststart(){
restenemy=new Dictionary<string, int>(){};
foreach (var item in enemysSet.enemys)
{restenemy.Add(item.enemystatus.name,item.number);
}
}
string texts;
public string textinpress(){
    texts="";
 foreach(var item in restenemy) {
    texts=texts+item.Key+"残り"+item.Value.ToString()+"\n";
       
      }
      return texts;

}

int check;
public void questclearcheck(){
    check=0;
foreach (var item in restenemy)
{
    check+=item.Value;
}
if (check<=0)
{
    questclear();
}

}
public void questclear(){
keikei.playerdata.nowquest=null;
<<<<<<< HEAD
warning.instance?.message(clearmessage,2);
=======
warning.message(clearmessage,2);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
keikei.playerdata.addexp(exp);
keikei.playerdata.addmoney(money);
itemdrops.itemdropers();
}
}
 