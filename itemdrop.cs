using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(fileName = "ItemDataBase", menuName="CreateItemDropData")]
public class itemdrop : ScriptableObject {
 
	[SerializeField]
	private List<itemdropdata> itemdroplist = new List<itemdropdata>();
 
 [System.Serializable]
 public class itemdropdata
 {
     public GameObject itemdropelement;
       [Range(0, 100)]
     public int perdrop;
 }

public void itemappenddrop(GameObject obj){

	   foreach (var item in this.GetItemdropLists())
                {
                    if (keikei.kakuritu(item.perdrop))
                    {
                       var b= Instantiate(item.itemdropelement,obj.transform.position,Quaternion.identity);
             keikei.itemappend(b);
                      }
                  }
}

             
            
	//　アイテムリストを返す
	public List<itemdropdata> GetItemdropLists() {
		return itemdroplist;
	}
}