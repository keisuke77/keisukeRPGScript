using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "motion", menuName = "")]
public class motions : ScriptableObject
{
    public AnimationClip animation;

    public Effekseer.EffekseerEffectAsset effect;
    public GameObject instanceobjs;

    [Range(0, 1)]
    public float timing;
    GameObject objs;
    public int damagevalue;
    public float radiusDamageArea;
    public bodypart bodypart;
    public int[] triggernumber;

    [Range(0, 1)]
    public float startdamagetime;

    [Range(0, 1)]
    public float enddamagetime;
    public motions continuemotion;

    public void Play(GameObject obj)
    {
        AnimEffect(obj);
        TriggerDamage(obj);
    }

    public void AnimEffect(GameObject obj)
    {
        objs = obj;
        if (obj.GetComponent<Animancer.AnimancerComponent>() != null)
        {
            obj.GetComponent<Animancer.AnimancerComponent>().enabled = true;
            obj.GetComponent<Animancer.AnimancerComponent>().Play(animation).Events.OnEnd = OnEnd;
        }
        else
        {
            obj.AddComponentIfnull<Animancer.AnimancerComponent>().Play(animation).Events.OnEnd =
                OnEnd;
        }
        float latetime = animation.length * timing;
        keikei.delaycall(
            () =>
            {
                obj.PlayEffect(effect);
                instanceobjs?.Instantiate(obj.transform);
            },
            latetime
        );
    }

    public void TriggerDamage(GameObject obj)
    {
        if (obj.GetComponentIfNotNull<triggeronoff>() != null)
        {
            triggeronoff trigeronoff = obj.GetComponentIfNotNull<triggeronoff>();
            if (damagevalue>0)
            {
                trigeronoff.obj.gameObject.collset(damagevalue);

                TriggerCall(() => trigeronoff.ontriger(), () => trigeronoff.offtriger());
            }
            
        }

        if (bodypart != bodypart.no)
        {
            Collider c = bodypart.Getbodypart(obj).GetComponentIfNotNull<Collider>();
            c.gameObject.collset(damagevalue);

            TriggerCall(() => c.enabled = true, () => c.enabled = false);
        }

        if (radiusDamageArea != 0)
        {
            foreach (var item in obj.RadiusSearch<hpcore>(radiusDamageArea))
            {
                if (obj != item.gameObject)
                {
                    item.damage(damagevalue, false, obj.Collider());
                }
            }
        }

        if (obj.GetComponentIfNotNull<trrigeronofflist>() != null)
        {
            trrigeronofflist trrigeronofflist = obj.GetComponent<trrigeronofflist>();
            if (trrigeronofflist != null && damagevalue != 0)
            {
                trrigeronofflist.num = triggernumber;
                foreach (var item in trrigeronofflist.GetTriger())
                {
                    item.gameObject.collset(damagevalue);
                }
                TriggerCall(() => trrigeronofflist.ontriger(), () => trrigeronofflist.offtriger());
            }
        }
    }

    void TriggerCall(System.Action ac, System.Action acs)
    {
        float starttime = animation.length * startdamagetime;
        float endtime = animation.length * enddamagetime;
        keikei.delaycall(ac, starttime);
        keikei.delaycall(acs, endtime);
    }

    public void OnEnd()
    {
        objs.GetComponent<Animancer.AnimancerComponent>().enabled = false;

        continuemotion.Play(objs);
    }
}
