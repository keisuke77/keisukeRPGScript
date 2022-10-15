using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class RPGBattleManager : Singleton<RPGBattleManager>
{

    public Text GuideText;
    public AutoRotateCamera AutoRotateCamera;
    public Material skybox;
public Sprite SelectImage;  
    public Transform[] enemyPositions;
    public Transform[] playerPositions;

public keiinput keiinput;

public imageselect PlayerSideSelect;
public imageselect EnemySideSelect;


public PlayerParty nowPlayerParty;
public EnemyParty nowEnemyParty;    
public GameObject[] playerObjs;
public GameObject[] enemyObjs;
public BattleState CurrentBattleState;
interactionlist interactionlist;
public RPGCharactor nowAttacker;
public GameObject nowAttackerObj;
public RPGCharactor nowAttacked;
public GameObject nowAttackedObj;
public RpgPlayerMotion nowRpgPlayerMotion;
public Animator anim;


public PlayerParty testp;
public EnemyParty teste;

public CameraSetting defaultCameraSetting;
public CameraSetting PlayerSideCameraSetting;
public CameraSetting EnemySideCameraSetting;

public Transform defaultCameraPos;

public message message;

public enum BattleState
{
    WhoIsAttackPlayer,WhoisAttackedEnemy,SelectPlayerMotion,StartAttackPlayer,ItemSelect,Nigeru
}
     public void Awake()
    {
        if (this!=Instance)
        {
            Destroy(gameObject);
            
            return;
        }
        
        transform.parent = null;
        DontDestroyOnLoad(this.gameObject);
        interactionlist=interactionlist.Instance;

        battleStart(testp,teste);
    }

public void Guide(string strings){
message.SetMessagePanel(strings,true);

}



public void battleStart(PlayerParty PlayerParty,EnemyParty EnemyParty){

anim?.SetBool("BattleStart",true);

nowPlayerParty=PlayerParty;
nowEnemyParty=EnemyParty;
keikei.delaycall(PlayerTurn,1f);
AutoRotateCamera.lerpatractcamera(defaultCameraPos,10);
AutoRotateCamera.CameraSettingSet(defaultCameraSetting);
StageSet();

}
 
int i;
    public void StageSet(){
        i=0;
RenderSettings.skybox = skybox;
foreach (var item in nowPlayerParty.members)
{playerObjs[i]= item.CharactorObj?.Instantiate(playerPositions[i]);
if (playerObjs[i]!=null)
{
    
  PlayerSideSelect.spriteevents[i].sprite=SelectImage.CreateImage(playerObjs[i],Vector3.up*3).GetComponent<Image>();

 PlayerSideSelect.spriteevents[i].sprite.transform.parent=PlayerSideSelect.gameObject.transform;
PlayerSideSelect.spriteevents[i].BattleSelectChara=item;

PlayerSideSelect.spriteevents[i].RpgGameobject=playerObjs[i];
    i++;
}
}
i=0;
foreach (var item in nowEnemyParty.members)
{enemyObjs[i]= item.CharactorObj?.Instantiate(enemyPositions[i]);
if (enemyObjs[i]!=null)
{
    
 EnemySideSelect.spriteevents[i].sprite=SelectImage.CreateImage(enemyObjs[i],Vector3.up*3).GetComponent<Image>();
 EnemySideSelect.spriteevents[i].sprite.transform.parent=EnemySideSelect.gameObject.transform;
EnemySideSelect.spriteevents[i].BattleSelectChara=item;
EnemySideSelect.spriteevents[i].RpgGameobject=enemyObjs[i];
    i++;
}
}
PlayerSideSelect.gameObject.SetActive(false);
EnemySideSelect.gameObject.SetActive(false);
    }

public void PlayerTurn(){
  Guide("あなたの番です");
  
interactionlist.createinteraction("攻撃",()=>{SwitchState(BattleState.WhoIsAttackPlayer);interactionlist.Alldeleteinteraction();});
interactionlist.createinteraction("逃げる",()=>{SwitchState(BattleState.Nigeru);interactionlist.Alldeleteinteraction();});
interactionlist.createinteraction("アイテム",()=>{SwitchState(BattleState.ItemSelect);interactionlist.Alldeleteinteraction();});


}



public int SelectNum;


void SwitchState(BattleState state){

CurrentBattleState=state;
StateAction();
}


public int nowPlayerSideSelectNumber;
public int nowEnemySideSelectNumber;

int tempnum;
public void StateAction(){


 switch (CurrentBattleState)
    {
        case BattleState.WhoIsAttackPlayer:
PlayerSideSelect.gameObject.SetActive(true);
tempnum=0;
foreach (var item in PlayerSideSelect.spriteevents)
{
   item.Selectaction=()=>{

    GuideText.text=item.BattleSelectChara.nickname;
   };


    item.decideaction=()=>{ 
    nowAttacker=item.BattleSelectChara;
    nowAttackerObj=item.RpgGameobject;
    AutoRotateCamera.lerpatractcamera(item.RpgGameobject.transform);
    
AutoRotateCamera.CameraSettingSet(PlayerSideCameraSetting);
Guide(nowAttacker.nickname+"で攻撃を行います!");
PlayerSideSelect.gameObject.SetActive(false);
SwitchState(BattleState.SelectPlayerMotion);

    };
}

            break;
            case BattleState.SelectPlayerMotion:

Guide(nowAttacker.nickname+"の使う技を選んでください");        
            foreach (var item in nowAttacker.RpgPlayerMotions)
            {
        
interactionlist.createinteraction(item.name,()=>{nowRpgPlayerMotion=item;
GuideText.text=item.motionname;
SwitchState(BattleState.WhoisAttackedEnemy);
interactionlist.Alldeleteinteraction();
});

            }


            break;
             case BattleState.WhoisAttackedEnemy:

AutoRotateCamera.lerpatractcamera(defaultCameraPos,10);

AutoRotateCamera.CameraSettingSet(EnemySideCameraSetting);
EnemySideSelect.gameObject.SetActive(true);



foreach (var item in EnemySideSelect.spriteevents)
{
   
    item.decideaction=()=>{
        
        nowAttacked=item.BattleSelectChara;
        nowAttackedObj=item.RpgGameobject;
    AutoRotateCamera.lerpatractcamera(item.RpgGameobject.transform);
Guide(nowAttacked.nickname+"に攻撃を行います!");
EnemySideSelect.gameObject.SetActive(false);
SwitchState(BattleState.StartAttackPlayer);

    };
}

            break; 
            case BattleState.StartAttackPlayer:
nowAttackerObj.MoveTargetRate(nowAttackedObj,0.8f,1f,()=>{

nowRpgPlayerMotion.Play(nowAttackerObj,nowAttackedObj,this);

});



            break;
          
        default:
            break;
    }




}


 void Update()
{
   
    
}


public void EnemyTurn(){

}






public void TurnChange(){

}


}