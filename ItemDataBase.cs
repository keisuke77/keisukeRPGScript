using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using ItemSystem;
=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
 
[CreateAssetMenu(fileName = "ItemDataBase", menuName="CreateItemDataBase")]
public class ItemDataBase : ScriptableObject {
 
	[SerializeField]
	private List<Itemkind> itemLists = new List<Itemkind>();
 
	//　アイテムリストを返す
	public List<Itemkind> GetItemLists() {
		return itemLists;
	}
}