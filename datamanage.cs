using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using DG.Tweening;
<<<<<<< HEAD
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ItemSystem;

public class datamanage : MonoBehaviour
{
    public static bool pos;
    public data data;
    public hpcore hp;
    public data nowdata;
    public bool firstdataload;
    public itemcurrent itemcurrent;
    public charactorchange charactorchange;
    playerMovePram playerMovePram;

    public void addmoney(int amount)
    {
        data.addmoney(amount);
    }

=======

using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
public class datamanage : MonoBehaviour
{
  
    public static bool pos;
    public data data;
    public hp hp;
    public data nowdata;
    public bool firstdataload;
    public itemcurrent itemcurrent;
    UnityChanControlScriptWithRgidBody UnityChanControlScriptWithRgidBody;
    
    
    public void addmoney(int amount){

    data.addmoney(amount);
    }
    
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    private static string TypeNameToString(string type)
    {
        var typeParts = type.Split(new char[] { '.' });
        if (!typeParts.Any())
            return string.Empty;

<<<<<<< HEAD
        var words = Regex
            .Matches(typeParts.Last(), "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)")
=======
        var words = Regex.Matches(typeParts.Last(), "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)")
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
            .OfType<Match>()
            .Select(match => match.Value)
            .ToArray();
        return string.Join(" ", words);
    }
<<<<<<< HEAD

    public void dataset(data d)
    {
        data = d;
    }

    public void dataCreate()
    {
        data = ScriptableObject.CreateInstance<data>();
    }

    public void onoffios(bool onoff)
    {
        data.ios = onoff;
    }

    public void save()
    {
        data.pos = gameObject.transform.position;
        gameObject.pclass().message.SetMessagePanel("データをセーブしました");
    }

    public void SetItemInventory(iteminventory iteminventory)
    {
        data.saveiteminventory = iteminventory;
    }

    void Awake()
    {
        gameObject.pclass().datamanage = this;
        hp = gameObject.pclass().hpcore;
       gameObject.pclass().hpcore.HP = data.HP;
        playerMovePram = gameObject.pclass().playerMovePram;
        keikei.playeriteminventory = data.saveiteminventory;
    }

    public void dataupdate()
    {
        if (itemcurrent != null)
        {
            hp.defaultdefencepower = data.defence;
            data.Itemkind = itemcurrent.Itemkind;
        }
        playerMovePram.forwardSpeed = data.forwardSpeed;
        playerMovePram.backwardSpeed = data.backwardSpeed;
        playerMovePram.rotateSpeed = data.rotateSpeed;
        data.HP = hp.HP;
        if (data.HP == 0)
        {
            data.HP = hp.maxHP;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (firstdataload)
        {
            keikei.PlayerEnterTransform(gameObject.root(), data.pos, data.rotation);
            //初期アイテムセット
            if (itemcurrent != null)
            {
                itemcurrent.setitem(data.Itemkind);
            }
        }
        if (gameObject.pclass()?.charactorchange != null)
        {
            charactorchange = gameObject.pclass()?.charactorchange;
            charactorchange.active = data.charactor;
        }
    }

    public void HPreset()
    {
        if (data != null && hp != null)
        {
            data.HP = hp.maxHP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        nowdata = data;
        data.charactor = charactorchange.active;
        dataupdate();
    }
=======
    public void dataset(data d ){
data=d;
    }public void dataCreate(){
data=ScriptableObject.CreateInstance<data>();
   }
    public void onoffios(bool onoff){
data.ios=onoff;

}

public void save(){

data.pos=gameObject.transform.position;
gameObject.pclass().AutoRotateCamera.SetMessage("データをセーブしました");

}


public void SetItemInventory(iteminventory iteminventory){
data.saveiteminventory=iteminventory;

}
  private void Awake()
  {
 UnityChanControlScriptWithRgidBody=GetComponent<UnityChanControlScriptWithRgidBody>();
            hp.HP=data.HP;
        keikei.playeriteminventory=data.saveiteminventory;
  }

 public void dataupdate(){
UnityChanControlScriptWithRgidBody.defencepower=data.defence;
UnityChanControlScriptWithRgidBody.forwardSpeed=data.forwardSpeed;
UnityChanControlScriptWithRgidBody.backwardSpeed=data.backwardSpeed;
UnityChanControlScriptWithRgidBody.rotateSpeed=data.rotateSpeed;
        data.Itemkind=itemcurrent.Itemkind;
 data.HP= hp.HP;
if(data.HP==0){
    data.HP=hp.maxHP;
}
  }
    // Start is called before the first frame update
    void Start()
    { 
        if (firstdataload)
        {
               keikei.PlayerEnterTransform(gameObject.root(),data.pos,data.rotation);
        keikei.datamanage=gameObject.root().GetComponent<datamanage>();
        //初期アイテムセット
        if (itemcurrent!=null)
        {
             itemcurrent.setitem(data.Itemkind);
        }
        }
     
      
       
           
        
    }

public void HPreset(){

     if (data!=null&&hp!=null)
    {
          data.HP=hp.maxHP;

    }
}

    // Update is called once per frame
    void Update()
    {       
             nowdata=data;
        dataupdate();
      
        }
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}
