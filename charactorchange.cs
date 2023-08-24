using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class character
{  
    public ChatCharactor ChatCharactor{set{ChatCharactorSet(value);_ChatCharactor=value;
 }get{return _ChatCharactor;}
    }
   
    ChatCharactor _ChatCharactor;
   [HideInInspector] public string layerName;
  [HideInInspector] public string name;
  [HideInInspector] public int power = 3;
  [HideInInspector] public Sprite Icon;
  [HideInInspector] public int hp;
  [HideInInspector] public int maxhp;
   [Header("説明")]
  [HideInInspector] public string Explain;
  [HideInInspector] public int defence;


    public GameObject bone;
    public GameObject mesh;
    public Avatar avatar;
    public GameObject righthand;
    public GameObject lefthand;
    public GameObject rightfoot;
    public GameObject leftfoot;
    public GameObject weapon;
    public transformdata weaponstransform;
  
   
    public float HPRate(){
       return (float) hp/maxhp;
    }

    public void ChatCharactorSet(ChatCharactor ChatCharactor){
     layerName=ChatCharactor.name; 
     name=ChatCharactor.name; 
power=ChatCharactor.Power;
Icon=ChatCharactor.icon;
hp=ChatCharactor.CurrentHP;
maxhp=ChatCharactor.MaxHP;
Explain=ChatCharactor.Explain;
defence=ChatCharactor.Defence;

    }
    
    
    public void Set(charactorchange charactorchange)
    {  
        foreach (var characterss in charactorchange.characters)
        {
            characterss.bone.SetActive(false);
            characterss.mesh.SetActive(false);
        }
     
        bone.SetActive(true);
        mesh.SetActive(true);
      
        charactorchange.anim.avatar = avatar;
      
      //アバター変更の後に変更する必要がある
       for (int i = 0; i < charactorchange.characters.Count; i++)
        {
               charactorchange.anim.SetLayerWeight(i,0);
        }
        charactorchange.anim.SetLayerWeight(charactorchange.anim.GetLayerIndex(layerName),1);
 if (charactorchange.weapons!=null)
        {
              charactorchange.weapons.transform.parent = righthand.transform;

        }
      
        //武器の装着
        if (weaponstransform != null && charactorchange.weapons != null)
        {
            keikei.transformenter(charactorchange.weapons.transform, weaponstransform);
        }
        
    }
}

public enum charactername
{
    mario,
    miku,
    man,
    unitychan
}

public interface GetBodyPart
{
    GameObject GetRightHand();
    GameObject GetLeftHand();
    GameObject GetLeftFoot();
    GameObject GetRightFoot();  GameObject GetWeapon();
}

public class charactorchange : MonoBehaviour, GetBodyPart
{
    
    


    public KeyCode ChangeKey;   
    public GameObject footsmoke;
    public Dropdown DropDown;
    public GameObject weapons;
    public List<character> characters;
    public Animator anim;
    [Button("Reload","リロード")]
    public int q;
    public AnimSpeedChangeState AnimSpeedChangeState;
   
    // Start is called before the first frame update
    public Text text;
    public int active = 0;
    string temptext;
    int tempactive = -1;
    int hairetucheck;
    public List<string> m_DropOptions;
    character currentcharactor;

    public float Delay;


    public GameObject ChangeSpawn;
    public DoTweenSeri DoTweenSeri;
    //　メインカメラ
    public GameObject GetRightHand()
    {
        return currentcharactor.righthand;
    }

    public GameObject GetLeftHand()
    {
        return currentcharactor.lefthand;
    }

    public GameObject GetLeftFoot()
    {
        return currentcharactor.leftfoot;
    }

    public GameObject GetRightFoot()
    {
        return currentcharactor.rightfoot;
    }  
    
    public GameObject GetWeapon()
    {
        return currentcharactor.weapon;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        this.enabled = true;
    }

    void Awake()
    {
        tempactive = -1;
        if (gameObject.pclass() != null)
        {
            gameObject.pclass().charactorchange = this;
        }
        
    }
private void OnEnable() {
    Reload();
}
public void Reload(){
     currentcharactor.Set(this);
}
    void Start()
    {
   
		  if (GetComponent<hpcore>()!=null)
        { 
        hpcore= GetComponent<hpcore>();
        }
        
        //DropDownの要素にリストを追加
        foreach (character item in characters)
        {   
               m_DropOptions.Add(item.name);
        }
          foreach (character item in characters)
        {   
            item.mesh.SetActive(false);
        }
        if (DropDown != null)
        {
            DropDown.ClearOptions();
            DropDown.AddOptions(m_DropOptions);
        }
    
    }

    public void collidespawnSet(GameObject obj)
    {
        var a = obj.AddComponentIfnull<collidespawn>();
        a.obj = footsmoke;
    }

    public void characterhide()
    {
        foreach (var characterss in characters)
        {
            characterss.mesh.SetActive(false);
        }
    } 

    public void charactorchanger(int num)
    {  
        
        charactorchanger(characters[Mathf.Abs(num%characters.Count)]);
       
      
    }  
    Sequence ChangeTween;
    public void charactorchanger(character characterss)
    { 
        
         if (ChangeSpawn!=null)
        {
            Instantiate(ChangeSpawn,transform.position,Quaternion.identity);
        } 
        if (ChangeTween!=null)
        {
                //チェンジ中に周りの動きを止める
         ChangeTween.Complete();
  
        }
         
       ChangeTween= DoTweenSeri.Play(transform);
        keikei.delaycall(()=>{

        currentcharactor=characterss;  
        currentcharactor.Set(this);
 
        if (hpcore!=null)
        {
        hpcore.HP=currentcharactor.ChatCharactor.CurrentHP;
        hpcore.maxHP=currentcharactor.ChatCharactor.MaxHP;
        hpcore.defence=currentcharactor.ChatCharactor.Defence;
        }
        if (GetComponent<AnimSpeedChangeState>()!=null)
        {
            GetComponent<AnimSpeedChangeState>().runSpeed=currentcharactor.ChatCharactor.RunSpeed;
            GetComponent<AnimSpeedChangeState>().idleSpeed=currentcharactor.ChatCharactor.IdleSpeed;
            GetComponent<AnimSpeedChangeState>().walkSpeed=currentcharactor.ChatCharactor.WalkSpeed;
        }
        if (GetComponent<attackcore>()!=null)
        { 
          GetComponent<attackcore>().basedamagevalue=currentcharactor.ChatCharactor.Power;
          GetComponent<attackcore>().baseforcepower=currentcharactor.ChatCharactor.knockBack;    
        }
          

        },Delay);
     try
{
      var navchaises=GameObjectExtension.GetComponentsInActiveScene<navchaise>(false);
         if (navchaises!=null)
         {
              
        foreach (var item in  navchaises)
        {
            
        item.Stop();
        keikei.delaycall(()=>item.ReStart(),1.5f);
        }
         }
}
catch (System.Exception)
{
    
    throw;
}
    }

hpcore hpcore;
   // Update is called once per frame
    void LateUpdate()
    {   
       

        if (ChangeKey.keydown())
        {
            charactoradd();
        }
         if(text != null)
        {
            text.text = currentcharactor.name;
        }
        if (active != tempactive)
        {
            tempactive = active;
            charactorchanger(active);
        }
        if (hpcore!=null&&currentcharactor!=null)
        {    
          currentcharactor.hp=hpcore.HP;
          currentcharactor.maxhp=hpcore.maxHP;
        }
        if (DropDown != null)
        {
            if (temptext != DropDown.captionText.text)
            {
                hairetucheck = 0;
                temptext = DropDown.captionText.text;

                foreach (var item in characters)
                {
                    hairetucheck++;
                    if (item.name == DropDown.captionText.text)
                    {
                        active = hairetucheck;
                    }
                }
            }
        }
    }

    public void charactoradd()
    {
        active++;
    }

    public void charactordown()
    {
        active--;
    }

    public void charactorchanges(int nums)
    {
        active = nums;
    }
}
