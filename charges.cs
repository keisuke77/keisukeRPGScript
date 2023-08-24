using UnityEngine;

[System.Serializable]
public class charges
{
    float chargevalue;
    public Animator anim;
    public bool charge;
    Effekseer.EffekseerHandle handle;

    /// <summary>
    ///
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    public charges(GameObject obj)
    {

        anim = obj.root().GetComponent<Animator>();
    }

    public void chargeup(string boolname)
    {
        anim.SetBool(boolname, true);

        if (charge)
        {
            anim.SetFloat("chargepower", chargevalue);
            charge = false;
            chargeeffonce = false;
            handle.Stop();
            anim.gameObject.pclass().playerMovePram.stop = false;
        }
    }

    public void charging(string boolname)
    {
        chargevalue += Time.deltaTime;
        anim.SetFloat("charge", chargevalue);
        anim.gameObject.playerstop();

        if (chargevalue > 1 && !chargeeffonce)
        {
            handle = anim.gameObject.PlayEffect(keikei.chargeeffect, true);
            chargeeffonce = true;
        }
        if (chargevalue > 5)
        {
            keikei.explosion.Instantiate(anim.gameObject.root().transform);
            chargevalue = 1;
            chargeup(boolname);
        }
    }

    bool chargeeffonce;

    public void chargepower(string boolname)
    {
        if (keiinput.Instance.attackduring && anim.GetBool("idle") && !charge)
        {
            chargevalue = 0;

            charge = true;
        }
        if (charge)
        {
            charging(boolname);
        }

        if (keiinput.Instance.attackup)
        {
            chargeup(boolname);
        }
    }
}
