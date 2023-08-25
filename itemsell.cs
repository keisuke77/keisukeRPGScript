using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
using ItemSystem;


public class itemsell : MonoBehaviour
{int b; 
public Itemkind Itemkind;
GameObject child;
Text explaintext;
Text placetext;
iteminventory playeriteminventory;
=======
public class itemsell : MonoBehaviour
{int b;
  datamanage datamanage;   
 public Itemkind Itemkind;
 
GameObject child;
Text explaintext;
Text placetext;
Transform trans;
 iteminventory playeriteminventory;

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae

void Start()
{
  playeriteminventory=keikei.playeriteminventory;
<<<<<<< HEAD
GetComponent<Image>().sprite=Itemkind.GetIcon();
=======
  trans=GetComponent<Transform>();
GetComponent<Image>().sprite=Itemkind.GetIcon();
   datamanage=keikei.datamanage;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
  explaintext=gameObject.transform.GetChild(0).GetComponent<Text>();
  placetext=gameObject.transform.GetChild(1).GetComponent<Text>();
  placetext.text=Itemkind.getplace().ToString()+"G";
}
<<<<<<< HEAD
　

public void touch(){
explaintext.enabled=true;
=======


public void touch(){
    explaintext.enabled=true;

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
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
<<<<<<< HEAD
shop.opener.acessdata().money>=Itemkind.getplace())
=======
datamanage.data.money>=Itemkind.getplace())
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
{
   return true;
}else
{
<<<<<<< HEAD
warning.instance?.warn("所持金が足りません");
=======
warning.warn("所持金が足りません");
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
   return false;
}
}

public void itemsells(){
   if (buycheck()==false)return;
    if ( playeriteminventory.additem(Itemkind,false))
    {
<<<<<<< HEAD
	shop.opener.pclass().message.SetMessagePanel(Itemkind.getplace().ToString()+"Gを払って"+Itemkind.GetItemName()+"を購入した。",true);
shop.opener.acessdata().money-=Itemkind.getplace();
      keikei.uijump(transform,50);
=======
		keikei.message.SetMessagePanel(Itemkind.getplace().ToString()+"Gを払って"+Itemkind.GetItemName()+"を購入した。",true);
    keikei.playeranim.SetTrigger("buy");
	
      datamanage.data.money-=Itemkind.getplace();
      keikei.uijump(trans,50);

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    }
            

           


}
}