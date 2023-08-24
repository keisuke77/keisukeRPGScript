using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(navchaise))]
[RequireComponent(typeof(Animator))]

public class WazaManagement : MonoBehaviour
{
    public navchaise navchaise;
    public waza MainWaza;
    public Animator anim;
    public bool Loop = false;
    public List<WazaHpChange> wazaHpChanges;
    public hpcore hpcore;
    public bool attachedStart;
    public bool damageStop;
[System.Serializable]
    public class WazaHpChange
    {
        [Header("このHp以上&以下だったらこの技を選択")]
        public int hpAbove; // HPの最小値
        public int hpBelow; // HPの最大値
        public waza waza;
    }

    private void Awake()
    {
        // HPが変わったときのイベントを購読
        hpcore.OnHpChanged += HandleHpChanged;
        if(anim != null) 
{
 anim=GetComponent<Animator>();   // Your code to access the animator
}
    }

    private void OnDestroy()
    {
        // イベントの購読を解除
        hpcore.OnHpChanged -= HandleHpChanged;
    }

    private async void Start()
    { if (!attachedStart)
    {
          SelectWazaBasedOnHP();
    }
           await RandomLoopAsync();
     
     }

    private async Task RandomLoopAsync()
    {
        while (true)
        {
            if (!Loop)
            {
                await Task.Delay(1000);
                continue;
            }
      if (MainWaza == null)
        {
            await Task.Delay(100); // MainWazaがnullのときに待つ時間。適切な値に調整することができます。
            continue;
        }
            float randomWaitTime = UnityEngine.Random.Range(MainWaza.MinInterval, MainWaza.MaxInterval);
            
            await Task.Delay((int)(randomWaitTime * 1000));
            meleeattack();
        }
    }

    void meleeattack()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
            return;
if (damageStop&&hpcore.cooldown)
    return;

foreach (var item in MainWaza.wazalist)
{
       anim.SetBool(item.name, false);
}
        SelectWazaBasedOnHP();

        foreach (var item in MainWaza.wazalist)
        {
            if (item.wazachange != null)
            {
                MainWaza = item.wazachange;
            }

            if (IsValidWaza(item))
            {
                ExecuteWaza(item);
                break;
            }
        }
    }

    private void SelectWazaBasedOnHP()
    {
        foreach (var hpChange in wazaHpChanges)
        {
            if (hpcore.HP >= hpChange.hpAbove && hpcore.HP <= hpChange.hpBelow)
            {
                MainWaza = hpChange.waza;
                break;
            }
        }
    }

    private bool IsValidWaza(waza.wazas item)
    {
        return keikei.kakuritu(item.kakuritu)
                && !anim.GetBool(item.name)
                && item.mindis * item.mindis <= navchaise.agentdestinationdis
                && navchaise.agentdestinationdis <= item.maxdis * item.maxdis;
    }

    private void ExecuteWaza(waza.wazas item)
    {
        anim.SetBool(item.name, true);
        anim.SetTrigger(item.name);

        if (item.motions != null)
        {
            item.motions.Play(gameObject);
        }
    }

    void Update()
    {
        // Set Loop to the opposite of navchaise.patrol
        Loop = !navchaise.patrol;
    }

    // HPが変わったときに呼び出されるメソッド
    private void HandleHpChanged(int newHp)
    {
        // HPが変わったときの処理（技の再選択など）
        SelectWazaBasedOnHP();
    }
}
