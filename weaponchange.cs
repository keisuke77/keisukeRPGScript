using UnityEngine;

[RequireComponent(typeof(triggeronoff))]
public class weaponchange : objectchange
{
    public triggeronoff triggeronoff;

    void Start()
    {
        triggeronoff = GetComponent<triggeronoff>();
        gameObject.pclass().weaponchange = this;
    }

    public override void weapon()
    {
        if (objlist[active].GetComponent<Collider>() != null)
        {
            objlist[active].GetComponent<Collider>().isTrigger = true;
            triggeronoff.obj = objlist[active].GetComponent<Collider>();
        }
        //投げたアイテムを回収するときにそのアイテムを拾えるようにする処理

        if (objlist[active].GetComponent<interactionenter>() != null)
        {
            objlist[active].GetComponent<interactionenter>().nowinteraction.Itemkind = gameObject
                .pclass()
                .itemcurrent?.Itemkind;
        }
    }
}
