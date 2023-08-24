using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemSystem
{
    public class itemcurrent : MonoBehaviour
    {
        public Itemkind Itemkind;
        iteminventory playeriteminventory;
        public UnityChanControlScriptWithRgidBody UnityChanControlScriptWithRgidBody;
        public GameObject Player;

        public bool defences;

        [SerializeField]
        Text text;
        public Animator anim;
    
        [Header("絶対に必要")]
       public weaponchange weaponchange;
      
     
        public Effekseer.EffekseerEffectAsset difenceeffect;
        public Text numbertext;
      
        public static itemcurrent instance;
        public Image resistanceimage;
        public Image backresistanceimage;
        public Image icon;
        itemmanage itemmanage;
        public charges charges;
    bool once1;
      
        data data;
        hp hp;
        mp mp;
        Itemkind noitem;
        Effekseer.EffekseerEmitter playeremitter;
        Effekseer.EffekseerHandle handle;
        void Awake()
        {mp=gameObject.root().GetComponent<mp>();
            icon = GetComponent<Image>();
            gameObject.pclass().itemcurrent = this;
            instance = this;
            playeremitter = gameObject.pclass().emitter;
        }

        void Start()
        {
           
            itemmanage = gameObject.pclass().itemmanage;
            charges = new charges(gameObject);
            noitem = keikei.noitem;
            data = gameObject.acessdata();
            temp = data.Itemkind;
            playeriteminventory = data.saveiteminventory;
            Player = gameObject.root();
          
             UnityChanControlScriptWithRgidBody = gameObject
                .pclass()
                .UnityChanControlScriptWithRgidBody;
            hp = Player.GetComponent<hp>();
            itemmanage.imagecreate();
            keikei.delaycall(() => setitem(temp), 0.5f);
        }

        public void returnitem()
        {
            itemmanage.additem(Itemkind, false);
            removeitem();
        }

        public void removeitem()
        {
            itemchange();
            Itemkind = noitem;
            resistanceimage.enabled = false;
            backresistanceimage.enabled = false;
        }

        public void itemchange()
        {
            weaponchange.objhide();
            if (defences)
            {
                defenceend();
            }
        }

        public void numbertexts()
        {
            if (
                Itemkind.GetKindOfItem().ToString() == "useWeapon"
                || Itemkind.GetKindOfItem().ToString() == "placeitem"
            )
            {
                keikei.itemnumtext(Itemkind, numbertext);
            }
            else
            {
                numbertext.text = "";
            }
        }

        public void itemused()
        {
            if (Itemkind.GetKindOfItem().ToString() == "Weapon")
            {
                removeitem();
            }
            Itemkind.downnumber();
        }

        public void weapontriggerSet()
        {
            gameObject.root().GetComponent<triggeronoff>().obj = weaponchange
                .Getobj()
                .GetComponent<Collider>();
        }

        public void setitem(Itemkind Itemkinds)
        {
            itemchange();
            if (Itemkind != Itemkinds)
            {
                weaponchange.objhide();
                keikei.scalechange(GetComponent<RectTransform>());
            }
            if (playeriteminventory.additem(Itemkind, false))
            {
                itemmanage.imagecreate();
            }
            Itemkind = Itemkinds;

            if (Itemkind.GetKindOfItem().ToString() == "Weapon")
            {
                warning.instance?.message(Itemkind.GetItemName() + "を装備した");
                Invoke("weapontriggerSet", 1f);
                resistanceimage.enabled = true;
                backresistanceimage.enabled = true;
                Player.PlayEffect(Itemkind.weaponseteffect, true);
            }
            else
            {
                resistanceimage.enabled = false;
                backresistanceimage.enabled = false;
            }
        }

        public void informationtext()
        {
            text.text = Itemkind.GetItemName() + "\n" + Itemkind.GetInformation();
        }

        public void removetext()
        {
            text.text = "";
        }

        public void mahoueffect()
        {
            var w = Instantiate(
                Itemkind.Getmagiceffect(),
                Player.transform.position + Player.transform.forward * 2,
                Player.transform.rotation
            );
            w.transform.SetParent(Player.transform);
            itemused();
        }

        public void mahoueffectnotparent()
        {
            Instantiate(
                Itemkind.Getmagiceffect(),
                Player.transform.position + Player.transform.forward * 2,
                Player.transform.rotation
            );
            itemused();
        }

        public void itemdamage(int damage)
        {
            Itemkind.Resitance -= damage;
        }

        Itemkind temp;

        // Update is called once per frame
        void LateUpdate()
        {
            if (Itemkind == null)
            {
                Itemkind = noitem;
            }
            icon.sprite = Itemkind.GetIcon();
            ItemFunction();
            resistanceimage.fillAmount = (float)Itemkind.Resitance / Itemkind.oriResitance;
            data.Itemkind = Itemkind;
            numbertexts();

            if (Itemkind.GetResistance() <= 0 && Itemkind != keikei.noitem)
            {
                Itemkind.Resitance = Itemkind.oriResitance;
                warning.instance?.message(Itemkind.GetItemName() + "が壊れた！");

                removeitem();
            }

            if (Itemkind.Getnumber() == 0 && Itemkind != noitem)
            {
                removeitem();
            }

            if (Itemkind.GetKindOfItem().ToString() == "placeitem")
            {
                placeitem();
            }
        }

        public void defence(int defencepowers = 500)
        {
            if (defences)
            {
                return;
            }
            handle = playeremitter.Play(difenceeffect);
            gameObject.pclass().playerMovePram.rotateonly = true;
            anim.SetBool("defence", true);
            hp.defence += defencepowers;
            defences = true;
        }

        public void defenceend()
        {
            handle.Stop();
            anim.SetBool("defence", false);
            gameObject.pclass().playerMovePram.rotateonly = false;
            if (hp != null)
            {
                hp.defence = hp.defaultdefencepower;
            }
            defences = false;
        }

        void ItemFunction()
        {
            if (Itemkind == null)
            {
                return;
            }
        if (Itemkind.GetKindOfItem().ToString() != "Weapon")
            {
                UnityChanControlScriptWithRgidBody.freehandattack();
            
            }else
            {
                 if (Itemkind.canThrow)
            {
            itemthrow();
            }
           
               
            
            switch (Itemkind.GetItemName())
            {
                case "プラスチック製の剣":
 weaponchange.changeint(2);
                sword();
                break;

                case "ゴッドソード":
 weaponchange.changeint(11);
                sword();
                break;

                case "フレイムソード":  
                weaponchange.changeint(9);
                sword();
                break; 
                 case  "魔法": 
                 if (keiinput.Instance.attack)
                {
                    keikei.shake();
                    anim.Play("mahouanim", 0);
                }
                break;  
                 case "ハイパーキックブーツ": 
                  weaponchange.changeint(0);
                if (keiinput.Instance.attack)
                {
                    anim.SetTrigger("kick");
                }
                break;  
                 case "合金製ハンマー":
                    weaponchange.changeint(5);
                attack("hammer");

                break;  
                 case "たる爆弾": 
                 weaponchange.changeint(6);
                 break;  
                 case "鉄のピッケル":  weaponchange.changeint(8);
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    anim.SetBool("pickaxe", true);
                }
                 break;  
                   case "鉄の斧": 
                   
                    weaponchange.changeint(12);
                if (keiinput.Instance.attack)
                {
                    anim.SetBool("axe", true);
                }
                    break;  
                   case "松明":
                      weaponchange.changeint(7);
            
                break;  
                   case "手裏剣":
      weaponchange.changeint(1);
            
                break;  
                   case  "弓矢":   
                   weaponchange.changeint(3);
                GameObject bow = weaponchange.objlist[3];

                arture(bow);
                break;  
                case "木の盾":
                  once1 = true;
                weaponchange.changeint(4);
                shield();
                break;
                case "リフレクトシールド":
                  once1 = true;
                hp.defence = 10;

                weaponchange.changeint(10);
                shield();
                itemthrow();
                break;
                default:
                break;
            }
          
            }       
        }

     

  

        bool attack(string boolname, float value=0)
        {
            if (keiinput.Instance.attack && mp.mpuse(value))
            {
                anim.SetBool(boolname, true);
                return true;
            }
            return false;
        }

        public void placeitem()
        {
            if (keiinput.Instance.Throw)
            {
                anim.Play("spawnobj", 0);
                Player.PlayEffect(Itemkind.effect, true);
            }
        }

        public void sword()
        {
            itemthrow();

            anim.SetFloat("swordmode", 1);
            charges.chargepower("sword");
            if (keiinput.Instance.hissatu)
            {
                if (mp.mpuse(30))
                {
                    anim.SetBool("swordhissatu", true);
                }
            }
        }

        bool bowcharge;

        public void arture(GameObject bow)
        {
            var bowshot = bow.GetComponent<bowshot>();
            bowshot.basepower = Itemkind.GetPower();
            if (keiinput.Instance.attack)
            {
                gameObject.pclass().playerMovePram.objrotate = true;
                bowcharge = true;
                anim.SetBool("bow", true);
                bowshot.damagevalue = 0;
            }
            else if (keiinput.Instance.attackup)
            {
                gameObject.pclass().playerMovePram.objrotate = false;
                if (Itemkind.optionget() == 1)
                {
                    bowshot.danyaku = true;
                }
                else
                {
                    bowshot.danyaku = false;
                }
                anim.SetBool("bow", false);
                Itemkind.optionset(0);
                bowcharge = false;
            }
            if (bowcharge)
            {
                bowshot.damagevalue++;
            }
        }

        public void shield()
        {
            if (keiinput.Instance.attack)
            {
                defence(Itemkind.GetPower());
            }
            else if (keiinput.Instance.attackup)
            {
                defenceend();
            }
        }

        public void itemthrow()
        {
            if (keiinput.Instance.Throw)
            {
                if (Itemkind == noitem)
                {
                    warning.instance?.message("投げるアイテムがない");
                    return;
                }
                anim.SetBool("throw", true);
            }
        }
    }
}
