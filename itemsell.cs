using UnityEngine;
using UnityEngine.UI;
using ItemSystem;


public class itemsell : MonoBehaviour
{int b; 
public Itemkind Itemkind;
GameObject child;
Text explaintext;
Text placetext;
iteminventory playeriteminventory;

void Start()
{
  playeriteminventory=keikei.playeriteminventory;
GetComponent<Image>().sprite=Itemkind.GetIcon();
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
shop.opener.acessdata().money>=Itemkind.getplace())
{
   return true;
}else
{
warning.instance?.warn("所持金が足りません");
   return false;
}
}

public void itemsells(){
   if (buycheck()==false)return;
    if ( playeriteminventory.additem(Itemkind,false))
    {
	shop.opener.pclass().message.SetMessagePanel(Itemkind.getplace().ToString()+"Gを払って"+Itemkind.GetItemName()+"を購入した。",true);
shop.opener.acessdata().money-=Itemkind.getplace();
      keikei.uijump(transform,50);
    }
            

           


}
}