using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
　
namespace ItemSystem
{
  
public class itemmanage : MonoBehaviour
{ 
    // Start is called before the first frame update
  public iteminventory playeriteminventory;
     
    public Itemkind noitem;
    public itemuse[] inventorymember;
/// <summary>
/// Start is called on the frame when a script is enabled just before
/// any of the Update methods is called the first time.
void Awake()
{keikei.noitem=noitem;
    gameObject.pclass().itemmanage=this;
   playeriteminventory=gameObject.acessdata().saveiteminventory;
}
void Start()
{ 
imagecreate();
}

public void additem(Itemkind Itemkind){

if (playeriteminventory.additem(Itemkind,false))
    {
         uipop(Itemkind);
    }

}
public void give(Itemkind Itemkind){

if (playeriteminventory.additem(Itemkind,false))
    {
         uipop(Itemkind);
    }
    

}

public void additemnopop(Itemkind Itemkind,bool addmessage){

 playeriteminventory.additem(Itemkind,addmessage);
  

}
public void additem(Itemkind Itemkind,bool addmessage){
give(Itemkind,addmessage);
}
public void give(Itemkind Itemkind,bool addmessage){

if (playeriteminventory.additem(Itemkind,addmessage))
    {
         uipop(Itemkind);
    }

}

public itemuse itemhavingcheck(Itemkind Itemkind){

int a=0;
foreach (var items in playeriteminventory.GetmyItemLists())
{   if (inventorymember[a].Itemkind== Itemkind)
{
    return inventorymember[a];
}
a++;
}
return null;
}

public void uipop(Itemkind Itemkind){
 
     itemhavingcheck(Itemkind).uipop();
}

public void imagecreate(){


var b=playeriteminventory.GetmyItemLists().Distinct().ToList();
 b.Remove(null);
playeriteminventory.myitemLists=b;
int a=0;
try{
foreach (var items in playeriteminventory.GetmyItemLists())
{   if (inventorymember[a]!=null)
{
inventorymember[a].delateitem();
inventorymember[a].itemset(items);
}
   
a++;   
}


}catch{
}
    
}
    


  
          
}
}