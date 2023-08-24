using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

[System.Serializable]
public class Projectle
{
    public GameObject obj;

    [Header("attackpartsのコライダー設定は不要")]
    public AttackPart AttackPart;
    public DoTweenSeri DoTweenSeri;

    [HideInInspector]
    public string AttackableTag;
    public string name;

    public void Play(Transform Spawner)
    {
        var objs = keikei.Instantiate(obj, Spawner.position, Spawner.rotation);
        var rb = objs.AddComponentIfnull<Rigidbody>() as Rigidbody;
        rb.isKinematic = true;
        AttackPart.Create(objs);
        AttackPart.attack.damageInfo.attackableTag = AttackableTag;
        AttackPart.On();
        DoTweenSeri
            .Play(objs.transform)
            .OnComplete(() =>
            {
                keikei.Destroy(objs, 1);
            });
    }
}

public class ProjectleManager : MonoBehaviour
{
    [Header("SpawnProjectle(name)で実行")]
    public List<Projectle> Projectles;
    public string AttackableTag;

    private string namesFromStatemacine;
public void SetName(string name){
namesFromStatemacine=name;
}

    void Start()
    {
        foreach (var item in Projectles)
        {
            item.AttackableTag = AttackableTag;
        }
    }

    public void SpawnProjectle(string name="")
    {if (name=="")name=namesFromStatemacine;
    
        foreach (var item in Projectles)
        {
            if (item.name == name)
            {
                item.Play(transform);
            }
        }
    }
}
