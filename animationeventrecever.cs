using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using DG.Tweening;
using ItemSystem;

public class animationeventrecever : MonoBehaviour
{
    [SerializeField]
    itemcurrent itemcurrent;


    [SerializeField]
    hp hp;

    public void hpitemheal()
    {
        hp.hpheal(itemuse.instance.Itemkind.GetPower());
        itemuse.instance.itemused();
    }

    public void scaleitembig()
    {
        transform
            .DOScale(
                itemuse.instance.Itemkind.GetPower(),
                (float)itemuse.instance.Itemkind.GetPower() / 2
            )
            .SetRelative(true);
        itemuse.instance.itemused();
        keikei.delaycall(
            () =>
                transform
                    .DOScale(
                        1 / itemuse.instance.Itemkind.GetPower(),
                        (float)itemuse.instance.Itemkind.GetPower() / 2
                    )
                    .SetRelative(true),
            15f
        );
    }

    public void camerashake()
    {
        keikei.shake();
    }

    public void shot()
    {
       var shoter = gameObject.GetComponentInParentAndChildren<bowshot>();
        shoter.Shot();
    }

    public void equip()
    {
        itemuse.instance?.itemused();
        itemuse.instance = null;
    }

    public void mahoueffect()
    {
        itemcurrent?.mahoueffect();
    }

    public void mahoueffectnotparent()
    {
        itemcurrent?.mahoueffectnotparent();
    }

    public void itemdamage(int damagevalue)
    {
        itemcurrent?.itemdamage(damagevalue);
    }

    public void removecurrentitem()
    {
        itemcurrent?.removeitem();
    }

    public void itemthrow()
    {
        itemcurrent?.itemused();
    }
    // Update is called once per frame
=======

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
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}
