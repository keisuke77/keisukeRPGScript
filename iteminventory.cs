using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace ItemSystem
{
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
	   warning.instance?.message(item.GetItemName()+"をゲットした");
    
	}
	    
	return true;
}
}

if (myitemLists.Count<Listsize)
{
myitemLists.Add(item);	
if (message)
	{
	   warning.instance?.message(item.GetItemName()+"をゲットした");
    
	}
return true;
}else
{
warning.instance?.message("インベントリがいっぱいです",1);
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
}
}