using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;

[CreateAssetMenu(fileName = "data", menuName = "money")]
public class data : ScriptableObject
{
    public string name;
    public inputsetting inputsetting;
    public iteminventory saveiteminventory;
    public int money;
    public int HP;
    public int charactor;
    public int nextexp;
    public Itemkind Itemkind;
    public int exp;
    public int level;
    public int totalexp;
    public int defence;
    public int power;
    public int maxHP;
    public int deltamoney;
    public int deltaexp;
    public float forwardSpeed;
    public float backwardSpeed;
    public float rotateSpeed;
    public Vector3 pos;
    public Quaternion rotation;
    public bool ios;
    public int storykey;
    public quest nowquest;
    public GameObject player;

    public void addmoney(int amount)
    {
        deltamoney += amount;
        money += amount;
    }

    public void addexp(int amount)
    {
        deltaexp += amount;
        exp += amount;

        warning.instance?.message(amount.ToString() + "xpを獲得した");
        if ((nextexp - exp) <= 0)
        {
            levelup();
            keikei.delaycall(() => addexp(exp - nextexp), 2f);
        }
    }

    public int levelup()
    {
        warning.instance?.message("おめでとう！あなたはレベル" + level.ToString() + "になった！");

        nextexp = level * 100;
        level++;
        totalexp += exp;
        exp = 0;

        power = level * 2;
        defence = level * 1;

        maxHP = 100 + level * 5;
        return level;
    }
}
