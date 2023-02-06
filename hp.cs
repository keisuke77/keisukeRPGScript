using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIExtensions;
using DG.Tweening;

using ItemSystem;

public class hp : hpcore
{
    
    public flashscrean flashscrean;
    bool once;
    public itemdrop itemdrop;
    public float shakepower = 1;
    public bool damageshake;
    datamanage datamanage;
    public bool timeScale = true;
    AutoRotateCamera AutoRotateCamera;
    public Canvas deathcanvas;
    // Start is called before the first frame update



    public override void SetUp()
    {
       datamanage = GetComponent<datamanage>();
        AutoRotateCamera = gameObject.pclass()?.AutoRotateCamera;
    }

  
    public void hpitemheal()
    {
        hpheal(itemuse.instance.Itemkind.GetPower());
        itemuse.instance.itemused();
    }

    public override void OnDamage(int damage)
    {
        gameObject
            .pclass()
            .PlayerMoveAction(() => anim.gameObject.transform.LookAt(killer.transform));
        Debug.Log($"ggggg");
        if (damageshake)
        {
            ShakeableTransform.m_shakeable.InduceStress((float)damage * shakepower);
        }
        if (flashscrean != null)
        {
            flashscrean?.damage();
        }
    
    }

    public override void OnDeath()
    {
        if (once)
            return;
        once = true;
        if (itemdrop != null)
        {
            keikei.itemspawnexplosion(gameObject, itemdrop);
        }
        if (datamanage != null)
        {
            datamanage.HPreset();
        }
        warning.instance?.message("死んでしまった！");
        gameObject.pclass().playerMovePram.stop = true;
        gameObject.acessmessage().SetMessagePanel("体力がなくなってしまった！！", true);
        if (AutoRotateCamera != null)
        {
            AutoRotateCamera.lerpatractcamera(transform, 7);
            DOTween.To(() => AutoRotateCamera.yaxis, (x) => AutoRotateCamera.yaxis = x, 20, 4f);
        }

        if (deatheffect != null)
        {
            keikei.Effspawn(deatheffect, transform);
        }
        if (deathparticle != null)
        {
            deathparticle.Instantiate(gameObject.transform);
        }

        if (deathcanvas != null)
        {
            deathcanvas.enabled(true);
        }

        keikei.delaycall(() => gametransition(), 3f);
    }

    bool gametransitiononce;

    public void gametransition()
    {
        if (gametransitiononce)
            return;
        gametransitiononce = true;

        if (gamemanager.instance != null)
        {
            gamemanager.instance.gameend();
        }
        gameObject.pclass().gametransition("loss");
    }
}
