
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
namespace ItemSystem
{
[Serializable]
[CreateAssetMenu(fileName = "Item", menuName="CreateItem")]
public class Itemkind : ScriptableObject {
 
 
	public enum KindOfItem {
		Weapon,
		useWeapon,
		UseItem,
		NoUseItem,
		placeitem
	}

	private int option=0;

[SerializeField] 
	 public Effekseer.EffekseerEffectAsset effect;
[SerializeField]
	 public Effekseer.EffekseerEffectAsset weaponseteffect;
	 [Range(100,0)]
public int oriResitance,Resitance=100;

public float usetime;
	[SerializeField]
	private KindOfItem kindOfItem;
	[SerializeField]
	private GameObject magiceffect;
	[SerializeField]
	private int power;
	[SerializeField]
	private int place;
	//　アイテムのアイコン
	[SerializeField]
	private Sprite icon;

[SerializeField]
	private int number=1;

	//　アイテムの名前
	[SerializeField]
	private string itemName;
	//　アイテムの情報
	[SerializeField]
	private string information;
 
 public bool canThrow;
 public Animation anim;
 public int deltanumber;
 public int optionset(int a){
	 option=a;
	 return option;
 }
 public int optionget(){
	 
	 return option;
 }
	public KindOfItem GetKindOfItem() {
		return kindOfItem;
	}
	public int Getnumber() {
		return number;
	}public int GetResistance() {
		return Resitance;
	}
	public int addnumber() {
	number++;
	deltanumber++;
	return number;
	}public int addnumber(int num) {
	number+=num;
	return number;
	}public int downnumber() {
		if (number!=0)
		{
			
	number--;
	
	deltanumber--;
		}
	return number;
	}
 
	public Sprite GetIcon() {
		return icon;
	}
	public GameObject Getmagiceffect() {
		return magiceffect;
	}
 public int GetPower() {
		return power;
	}public int getplace() {
		return place;
	}
 
	public string GetItemName() {
		return itemName;
	}

	public string GetInformation() {
		return information;
	}



	
    public void add(GameObject obj){

         if (obj.acessdata().saveiteminventory.additem(this))
        {
obj.pclass().itemmanage.imagecreate();
obj.pclass().itemmanage.uipop(this);
        }  
    
    }


public List<Itemkind> Remove(GameObject obj) {
		return obj.acessdata().saveiteminventory.Remove(this);
	

	}
}
}
