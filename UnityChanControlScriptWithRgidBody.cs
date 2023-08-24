﻿//
// Mecanimのアニメーションデータが、原点で移動しない場合の Rigidbody付きコントローラ
// サンプル
// 2014/03/13 N.Kobyasahi
using UI_InputSystem.Base;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using ItemSystem;

// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]
public class UnityChanControlScriptWithRgidBody : MonoBehaviour
{
    public CharacterController controller;
    public underwater bodyunderwater;
    public LayerMask targetLayer;

    float t = 0;
    float damagetime;
    mp mp;
    hp hp;
    public playerMovePram playerMovePram;
    public charges charges;
    public Animator anim; // base layerで使われる、アニメーターの現在の状態の参照
    public bool damaged = false;
    public bool _isGrounded;
    public AutoRotateCamera AutoRotateCamera;
    public float groundtime;
    itemcurrent itemcurrent;
    private int time = 0;

    public bool isJumping;
    public bool isFalling;
    public float jumptime = 0.6f;

    public void damage()
    {
        damaged = true;
        anim.SetBool("wakeup", false);
        anim.SetTrigger("damage");
    }

    public void damageheal()
    {
        damaged = false;
        anim.SetBool("wakeup", true);
    }

    void OnEnable()
    {
        if (keikei.player != null)
        {
            keikei.player = this.gameObject;
            keikei.playerset();
        }
    }

    void Awake()
    {
        if (gameObject.pclass() != null)
        {
            gameObject.pclass().UnityChanControlScriptWithRgidBody = this;
        }

        TryGetComponent(out hp);

        TryGetComponent(out mp);

        anim = gameObject.cclass().anim;

        keikei.player = this.gameObject;
        keikei.playerset();
        keikei.Allplayer = new List<GameObject>(10);
    }

    // 初期化
    void Start()
    {
        playerMovePram = gameObject.pclass()?.playerMovePram;
        gameObject.pclass().ResetControlObj();
        keikei.Allplayer.Add(gameObject);
        charges = new charges(gameObject);
        itemcurrent = gameObject.pclass().itemcurrent;
        if (controller != null)
        {
            defaultstepOffset = controller.stepOffset;
        }
    }

    void jumps()
    {
        if (damaged)
        {
            anim.SetBool("wakeup", true);
            damaged = false;
        }
        else
        {
            anim.SetBool("Jump", true);
            isJumping = true;
            keikei.delaycall(() => isJumping = false, jumptime);
        }
    }

    public void freehandattack()
    {
        anim.SetFloat("swordmode", 0);
        charges.chargepower("attack");
        if (keiinput.Instance.guard)
        {
            if (mp.mpuse(8))
            {
                anim.SetBool("kaihi", true);
            }
        }

        if (keiinput.Instance.guardup)
        {
            anim.SetBool("kaihi", false);
        }
    }

    public void Landed()
    {
        AutoRotateCamera?.recovercamera();
        isFalling = false;
        if (falldamage > 10)
        {
            hp.damage((int)falldamage);
        }
        anim.SetTrigger("ground");
        anim.SetFloat("MotionBig", falldamage);
        falldamage = 0;
    }

    void falling()
    {
        if (!isFalling)
        {
            isFalling = true;
            anim.SetTrigger("fall");
            anim.SetBool("fall", true);
            anim.SetBool("sky", true);
            falldamage = transform.grounddistances(targetLayer);
            AutoRotateCamera?.resetcamera();
        }
    }

    void animcontoroll()
    {
        if (anim == null)
            return;

        if (anim.GetBool("swimming"))
        {
            anim.SetBool("sky", false);
            anim.SetBool("fall", false);
        }

        if ((_isGrounded || anim.GetBool("swimming")))
        {
            if (isJumping == false)
            {
                if (isFalling)
                {
                    Landed();
                }
                if (bodyunderwater != null)
                {
                    if (bodyunderwater.iswater)
                        return;
                }

                anim.SetBool("sky", false);
                anim.SetBool("fall", false);
            }
        }
        else
        {
            falling();
        }
    }

    float falldamage;
    float defaultstepOffset;

    // 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
    void FixedUpdate()
    {
        if (damaged)
        {
            playerMovePram.stop = true;
        }
        else
        {
            playerMovePram.stop = false;
        }

        if (transform.grounddistances(targetLayer).debug() > 10)
        {
            _isGrounded = false;
        }
        else if (transform.grounddistances(targetLayer).debug() < 1)
        {
            _isGrounded = true;
        }

        if (controller != null)
        {
            controller.stepOffset = defaultstepOffset * transform.localScale.y;
        }

        if (!itemcurrent.isActiveAndEnabled)
        {
            freehandattack();
        }

        animcontoroll();

        if (keiinput.Instance.jump)
        { // スペースキーを入力したら
            jumps();
        }
    }
}
