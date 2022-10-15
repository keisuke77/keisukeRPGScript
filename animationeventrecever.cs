using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationeventrecever : MonoBehaviour
{
[SerializeField]
    itemcurrent itemcurrent;
    [SerializeField]
    bowshot shoter;
[SerializeField]
    itemuse itemuse;

[SerializeField]
    hp hp;
[SerializeField]
    scalechangeplayer scalechangeplayer;

[SerializeField]
    U10PS_DissolveOverTime U10PS_DissolveOverTime;

   
public void hpitemheal(){

    hp.hpheal(itemuse.instance.Itemkind.GetPower());
    itemuse.instance.itemused();
}
    
public void scaleitembig(){

    scalechangeplayer.scalechange(itemuse.instance.Itemkind.GetPower());
    itemuse.instance.itemused();
}
    
    public void charactorchangeitem(){

        U10PS_DissolveOverTime.dissolvecharachange();
        itemuse.instance.itemused();
    }
    public void camerashake(){

        
keikei.shake();
    }
    public void shot(){
      shoter=gameObject.GetComponentInParentAndChildren<bowshot>();
        shoter.Shot();
        
    }
public void equip(){

itemuse.equiped();
itemuse.instance=null;
}

public void mahoueffect(){

itemcurrent.mahoueffect();

}

public void mahoueffectnotparent(){

itemcurrent.mahoueffectnotparent();

}
public void itemdamage(int damagevalue){
itemcurrent.itemdamage(damagevalue);



}
public void removecurrentitem(){
    itemcurrent.removeitem();
}
public void itemthrow(){
    itemcurrent.itemused();
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
