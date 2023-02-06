using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
[CreateAssetMenu(fileName = "ItemDataBase", menuName="CreateItemRandom")]
public class RandomItemkind : ScriptableObject {
 int totalweight;



	[SerializeField]
	private List<itemrandomdata> itemrandomlist = new List<itemrandomdata>();
 
 [System.Serializable]
 public class itemrandomdata
 {
     public Itemkind itemelement;
       [Range(0, 100)]
     public int weight;
 }
 public Itemkind GetRandomOne(){
	 totalweight=0;
foreach (var item in itemrandomlist)
{
	totalweight+=item.weight;
}
foreach (var item in itemrandomlist)
{
	if (((float)item.weight/totalweight).GetRatecheck())
{
	return item.itemelement;
}

}
return keikei.noitem;
 }
	//　アイテムリストを返す
	public List<itemrandomdata> GetItemrandomLists() {
		return itemrandomlist;
	}
}