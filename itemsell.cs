using UnityEngine;
using UnityEngine.UI;
public class itemsell : MonoBehaviour
{int b;
  datamanage datamanage;   
 public Itemkind Itemkind;
 
GameObject child;
Text explaintext;
Text placetext;
Transform trans;
 iteminventory playeriteminventory;


void Start()
{
  playeriteminventory=keikei.playeriteminventory;
  trans=GetComponent<Transform>();
GetComponent<Image>().sprite=Itemkind.GetIcon();
   datamanage=keikei.datamanage;
  explaintext=gameObject.transform.GetChild(0).GetComponent<Text>();
  placetext=gameObject.transform.GetChild(1).GetComponent<Text>();
  placetext.text=Itemkind.getplace().ToString()+"G";
}


public void touch(){
    explaintext.enabled=true;

explaintext.text=Itemkind.GetItemName()+Itemkind.GetInformation();
}

public void untouch(){
  explaintext.enabled=false;

}

    public void itemset(Itemkind a ,int index){

if (b==-1)
{
    b=index;
}

if (Itemkind==null)
{
    Itemkind=a;

  GetComponent<Image>().sprite=Itemkind.GetIcon();
  
}

}




public void delateitem(){

Itemkind=null;
       
b=-1;
 GetComponent<Image>().sprite=null;
}

public bool buycheck(){
if (
datamanage.data.money>=Itemkind.getplace())
{
   return true;
}else
{
warning.warn("所持金が足りません");
   return false;
}
}

public void itemsells(){
   if (buycheck()==false)return;
    if ( playeriteminventory.additem(Itemkind,false))
    {
		keikei.message.SetMessagePanel(Itemkind.getplace().ToString()+"Gを払って"+Itemkind.GetItemName()+"を購入した。",true);
    keikei.playeranim.SetTrigger("buy");
	
      datamanage.data.money-=Itemkind.getplace();
      keikei.uijump(trans,50);

    }
            

           


}
}