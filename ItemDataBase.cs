using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
 
[CreateAssetMenu(fileName = "ItemDataBase", menuName="CreateItemDataBase")]
public class ItemDataBase : ScriptableObject {
 
	[SerializeField]
	private List<Itemkind> itemLists = new List<Itemkind>();
 
	//　アイテムリストを返す
	public List<Itemkind> GetItemLists() {
		return itemLists;
	}
}