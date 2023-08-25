using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
<<<<<<< HEAD
　
namespace ItemSystem
{
  
public class itemmanage : MonoBehaviour
{ 
    // Start is called before the first frame update
  public iteminventory playeriteminventory;
     
    public Itemkind noitem;
=======

public class itemmanage : MonoBehaviour
{ int a=0;
    // Start is called before the first frame update
  public iteminventory playeriteminventory;
   
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    public itemuse[] inventorymember;
/// <summary>
/// Start is called on the frame when a script is enabled just before
/// any of the Update methods is called the first time.
void Awake()
<<<<<<< HEAD
{keikei.noitem=noitem;
=======
{
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    gameObject.pclass().itemmanage=this;
   playeriteminventory=gameObject.acessdata().saveiteminventory;
}
void Start()
{ 
imagecreate();
}

<<<<<<< HEAD
=======

public void Randomgive(RandomItemkind RandomItemkind){

    Itemkind Itemkind=RandomItemkind.GetRandomOne();
    additem(Itemkind);
}

public void Randomgive(RandomItemkind RandomItemkind,bool addmessage){

    Itemkind Itemkind=RandomItemkind.GetRandomOne();
    additem(Itemkind,addmessage);
}

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
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

<<<<<<< HEAD
int a=0;
=======
a=0;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
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
<<<<<<< HEAD
int a=0;
=======
a=0;
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
try{
foreach (var items in playeriteminventory.GetmyItemLists())
{   if (inventorymember[a]!=null)
{
inventorymember[a].delateitem();
<<<<<<< HEAD
inventorymember[a].itemset(items);
=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}
   
a++;   
}
<<<<<<< HEAD


}catch{
=======
a=0;
foreach (var items in playeriteminventory.GetmyItemLists())
{   if (inventorymember[a]!=null)
{
inventorymember[a].itemset(items);
}
  
a++;
}


}catch{

    
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}
    
}
    
<<<<<<< HEAD


  
          
}
}
=======
          
}
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
