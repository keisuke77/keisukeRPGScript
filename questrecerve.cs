using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.UI;

public class questrecerve : MonoBehaviour
{
    
data data;
     public GameObject panel;
    public quest[] quests;
    public Image image;
    public Text bigtitle;
    public Text title;
    public Text expression;
    public Text expandmoney;
  
public int num;

<<<<<<< HEAD
=======
public void questpanelopen(quest[] quest){
questpanelopen();
quests=quest;
 questboardset(quests[num]);
       
}
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

public void questpanelopen(quests quest){

bigtitle.text=quest.title;
<<<<<<< HEAD

  questpanelopen();
quests=quest.questss;
 questboardset(quests[num]);     
=======
questpanelopen(quest.questss);

       
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}

public void questpanelopen()
{
panel.transform.parent.GetComponent<Canvas>().enabled=true;

} 

public void questpanelclose()
{


panel.transform.parent.GetComponent<Canvas>().enabled=false;

} 


   // Start is called before the first frame update
    void Start()
    {
        questboardset(quests[num]);
        data=keikei.playerdata;
        questpanelclose();
        if (data.nowquest!=null)
        {
            data.nowquest.queststart();
        }
    }


    public void add(){

num++;

num=num%quests.Length;
 questboardset(quests[num]);
       
    }
    public void down(){

num--;


num=num%quests.Length;
 questboardset(quests[num]);
       
    }

public void questboardset(quest q){

    Sequence sequence=DOTween.Sequence();
sequence.Append(panel.gameObject.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.4f,  
    RotateMode.FastBeyond360)).AppendCallback(()=>set(q)).Append(panel.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.4f,  
    RotateMode.FastBeyond360));  
    

}

public void set(quest q){

    image.sprite=q.sprite;
            title.text=q.questname;
            expression.text=q.expression;
            expandmoney.text="受注金額　"+q.needmoney+"G\n報酬　"+q.money+"G "+q.exp+"exp";
        
}

public void questdecide(){
quest quest=quests[num];
if (data.nowquest==quest)
{
<<<<<<< HEAD
    warning.instance?.warn("既におなじクエストを受注しています");
=======
    warning.warn("既におなじクエストを受注しています");
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}

if (data.money>quest.needmoney&&data.level>quest.needlevel)
{
    data.nowquest=quest;
<<<<<<< HEAD
    warning.instance?.message("クエストの受注に成功しました",2);
=======
    warning.message("クエストの受注に成功しました",2);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

    data.money-=quest.needmoney;
    quest.queststart();
    questpanelclose();
}else
{
<<<<<<< HEAD
     warning.instance?.message("クエストの受注条件を満たしていません",1);
=======
     warning.message("クエストの受注条件を満たしていません",1);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

}

}
   
}
