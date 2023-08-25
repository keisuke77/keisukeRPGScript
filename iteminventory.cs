using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
<<<<<<< HEAD
namespace ItemSystem
{
=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
[CreateAssetMenu(fileName = "ItemDataBase", menuName="CreateItemInventory")]
public class iteminventory : ScriptableObject{
 
public int Listsize=10;

	public List<Itemkind> myitemLists = new List<Itemkind>();
 
	




public bool additem(Itemkind item,bool message=true){
if (item==keikei.noitem)
{
	return false;
}

foreach (Itemkind items in myitemLists)
{if (items.GetItemName()==item.GetItemName())
{
	item.addnumber();
	if (message)
	{
<<<<<<< HEAD
	   warning.instance?.message(item.GetItemName()+"をゲットした");
=======
	   warning.message(item.GetItemName()+"をゲットした");
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    
	}
	    
	return true;
}
}

if (myitemLists.Count<Listsize)
{
myitemLists.Add(item);	
if (message)
	{
<<<<<<< HEAD
	   warning.instance?.message(item.GetItemName()+"をゲットした");
=======
	   warning.message(item.GetItemName()+"をゲットした");
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
    
	}
return true;
}else
{
<<<<<<< HEAD
warning.instance?.message("インベントリがいっぱいです",1);
=======
warning.message("インベントリがいっぱいです",1);
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
return false;
}
	
	
	return false;
}



public Itemkind removeList(Itemkind Itemkind){
	myitemLists.Remove(Itemkind);
	return Itemkind;
}

public List<Itemkind> removeLists(Itemkind Itemkind) {

			return Remove(Itemkind);
	}
public List<Itemkind> Remove(Itemkind Itemkind) {

	if (Itemkind.Getnumber()==0)
	{
		myitemLists.Remove(Itemkind);
	
	}else
	{
		Itemkind.downnumber();
	}
			return myitemLists;
	}

public List<Itemkind> clearLists() {
	myitemLists.Clear();
		return myitemLists;
	}
	public List<Itemkind> GetmyItemLists() {
		return myitemLists;
	}
<<<<<<< HEAD
}
=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}