using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;  // UniTaskのためのnamespaceを追加

public class combo : MonoBehaviour
{
    public float attackCooldown = 0.5f;
    public float comboCompletedCooldown = 2.0f;
    public float comboTimeout = 1.0f;
    public float longPressInterval = 1.0f;
    public List<string> comboAnimations;
    private float lastDamageTime = -999f; // 最後にダメージを受けた時間
    private float buttonPressTime;
    private bool attackReserved = false;

    private bool isAttacking = false;
    private int comboCount = 0;
    private float lastAttackTime = 0f;

    [Range(0, 10)]
    public int CrossFadeSmoothLevel;

    [Range(0, 10)]
    public float AnimSpeed;

    private Animator animator;

    public int MaxComboCount;
    public mp mp;
public float MPUseMount;
public hpcore hpcore;

public bool progressUseMp;
    private async void Start()
    {
        animator = GetComponent<Animator>();
            }

    private async void Update()
    {
         if (IsCooldownOver() && attackReserved)
    {
        attackReserved = false;
        ProgressCombo();
    }


          if (hpcore.cooldown||animator.GetCurrentAnimatorStateInfo(0).IsTag("Damage"))
        {
          comboCount=0;
            lastDamageTime = Time.time; // ダメージを受けた時間を更新
        }
        await HandleAttack();
    }

    private async UniTask HandleAttack()
    {
        if (isAttacking) return;

        bool isSinglePress = keiinput.Instance.attack;

 if (isSinglePress)
{

    if(IsCooldownOver())
    {
        ProgressCombo();
    }
    else
    {
        attackReserved = true;
    }
}

   bool isLongPressing = keiinput.Instance.attackduring;
    if (isLongPressing)
    {
        buttonPressTime += Time.deltaTime;
        if (buttonPressTime >= longPressInterval && IsCooldownOver())
        {
            ProgressCombo();
            buttonPressTime = 0f; // ここでリセットして、次の長押しコンボまでの間隔を計測します
        }
    }

        if (comboCount > 0 && Time.time - lastAttackTime > comboTimeout)
        {
            comboCount = 0;
           
 if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                     animator.CrossFadeAnimation(DefaultState,CrossFadeSmoothLevel);
             }
        }
//例外処理
        if (comboCount==0&&animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {

             animator.CrossFadeAnimation(DefaultState,CrossFadeSmoothLevel);
              
        }
    }

    public string DefaultState = "Move";

bool IsCooldownOver()
{
    float currentCooldown = (comboCount == MaxComboCount) ? comboCompletedCooldown : attackCooldown;
    bool cooldownOver = Time.time - lastAttackTime > currentCooldown;
    return cooldownOver;
}

  void ProgressCombo()
{
           // ダメージを受けた場合
        if (hpcore.cooldown||animator.GetCurrentAnimatorStateInfo(0).IsTag("Damage"))
        {
            comboCount = 0; // コンボをリセット
            lastDamageTime = Time.time; // ダメージを受けた時間を更新
            return; // 以降のコンボ進行処理をスキップ
        }
        if (progressUseMp)
        {
            
if (!mp.mpuse(MPUseMount))
{
    return;
}
        }else if(comboCount==0)
        {
    
if (!mp.mpuse(MPUseMount))
{
    return;
}
   
        }


    if ((comboCount == 0 && animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle")) ||
        (comboCount > 0 && animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")))
    {
        comboCount++;
        if (comboCount > MaxComboCount)
        {
            comboCount = 1;
            attackReserved=false;
        }
        StartAttack(comboCount);
    }
}



    private async void StartAttack(int attackLevel)
    {
        isAttacking = true;
        lastAttackTime = Time.time;

        if (attackLevel <= comboAnimations.Count)
        {
            animator.SetFloat("AnimSpeed", AnimSpeed);
             animator.CrossFadeAnimation(comboAnimations[attackLevel - 1],CrossFadeSmoothLevel);
         }

        isAttacking = false;
    }

 
}
