using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
