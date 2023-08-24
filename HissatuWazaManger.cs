using UnityEngine;using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;

[System.Serializable]
public class HissatuWaza {
    public string Name;
    public Image icon;
   public float mpUseAmount;
    public mp mp;
  
}
public class HissatuWazaManger : MonoBehaviour {
    
    public Animator anim;
    public controll WazaKey;
    public KeyCode AddKey;
    public KeyCode DownKey;

public List<HissatuWaza> HissatuWazas;
public HissatuWaza CurrentHissatuWaza;

public int active;
 void Awake() {
 
ChangeActive(active);
}
public void ChangeActive(int num){

active=num;
     CurrentHissatuWaza=HissatuWazas[active%HissatuWazas.Count];
     foreach (var item in HissatuWazas)
     {if (item.icon)
     {
        item.icon.gameObject.SetActive(false);
     
     }
        
     }
     CurrentHissatuWaza.icon.gameObject.SetActive(true);
      
}

void Hissatu(){
   
    if (CurrentHissatuWaza.mp.mpuse(CurrentHissatuWaza.mpUseAmount))
    {
          anim.Play(CurrentHissatuWaza.Name);
    }
    
}
 void Update() {
    
    
    if (keiinput.Instance.GetKey(WazaKey))
    {
      Hissatu();
    }

if(AddKey.keydown()){
ChangeActive(active-1);
}
if(DownKey.keydown()){
ChangeActive(active+1);
}
   

}


}