using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetspawneffect : MonoBehaviour
{
   

    [System.Serializable]
    public class targeteffect
    {
        public Transform target;

        public bodypart part;
        public Effekseer.EffekseerEffectAsset effect = null;
        public Vector3 rot;
        public bool parent;
        public GameObject particle;
        public int ondamage;
        public int squenceinterval;
        public int forcepower;
        public Effekseer.EffekseerHandle handle;
    }

    public targeteffect[] targeteffects;
    public GameObject[] box;
    public string AttackableTag;
    // Start is called before the first frame update
    void Start()
    {
        box = new GameObject[targeteffects.Length];
    }

    public void Play(int i)
    {
        effekseerspawn(i);
    }

    public void Stop(int i)
    {
        effekseerstop(i);
    }

    public void effekseerspawn(int i)
    {
        var a = targeteffects[i];

        if (a.effect)
        {
            if (a.target != null)
            {
                a.handle = a.target.gameObject
                    .PlayEffect(a.effect, a.parent)
                    .SetRotation(Quaternion.Euler(a.rot));
            }
            else
            {
                a.handle = a.part
                    .Getbodypart(gameObject)
                    .PlayEffect(a.effect, a.parent)
                    .SetRotation(Quaternion.Euler(a.rot));
            }
        }

        if (a.particle)
        {
            if (a.target)
            {
                box[i] = keikei.instantiate(a.particle, a.target, a.parent);
            }
            else
            {
                box[i] = keikei.instantiate(a.particle, a.part.Getbodypart(gameObject).transform, a.parent);
            }
            if (a.forcepower > 0)
            {
                Rigidbody ballRigidbody = box[i].GetComponent<Rigidbody>();

                ballRigidbody.AddForce(transform.forward * a.forcepower, ForceMode.Impulse);
            }
            if (a.ondamage != 0)
            {
             var attack=  box[i].AddComponent<attack>()as attack;
             attack.damageInfo.attackableTag=AttackableTag;
            }
        }
    }

    public void effekseerstop(int i)
    {
        var a = targeteffects[i];

        if (a.effect)
        {
            a.handle.Stop();
        }
        Destroy(box[i]);
    }
}
