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

public imageselect PlayerSideSelect;
public imageselect EnemySideSelect;


public Party PlayerParty;
public Party EnemyParty;


public BattleState CurrentBattleState;
interactionlist interactionlist;


RPGCharactor nowSelectCharactor;
GameObject nowSelectCharactorObj;


public RPGCharactor nowAttacker;
public GameObject nowAttackerObj;
public RPGCharactor nowAttacked;
public GameObject nowAttackedObj;



public RpgPlayerMotion nowRpgPlayerMotion;
public Animator anim;

public CameraSetting defaultCameraSetting;
public CameraSetting PlayerSideCameraSetting;
public CameraSetting EnemySideCameraSetting;

public Transform defaultCameraPos;

public message message;

public enum BattleState
{
    CommandSelect,WhoIsAttackPlayer,WhoisAttackedEnemy,SelectPlayerMotion,StartAttackPlayer,ItemSelect,Nigeru
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

        
    }

private void Start() {
    battleStart();
}
public void Guide(string strings){
message.SetMessagePanel(strings,true);

}



public void battleStart(){

anim?.SetBool("BattleStart",true);
keikei.delaycall(()=>SwitchState(BattleState.CommandSelect),1f);
AutoRotateCamera.lerpatractcamera(defaultCameraPos,10);
AutoRotateCamera.CameraSettingSet(defaultCameraSetting);
StageSet();

}
 



public void StageSet(){

RenderSettings.skybox = skybox;

LinkPartyToSideSelect(EnemySideSelect,EnemyParty);
LinkPartyToSideSelect(PlayerSideSelect,PlayerParty);

PlayerSideSelect.gameObject.SetActive(false);
EnemySideSelect.gameObject.SetActive(false);
   
    }


public void LinkPartyToSideSelect(imageselect imageselects,Party Partys){

int i=0;
foreach (RPGCharactor member in Partys.members)
{
    
   Partys.InstanceObj[i] = member.CharactorObj?.Instantiate(playerPositions[i]);
if (Partys.InstanceObj[i]!=null)
{
    
   imageselects.spriteevents[i].sprite=SelectImage.CreateImage(Partys.InstanceObj[i],Vector3.up*3).GetComponent<Image>();
   imageselects.spriteevents[i].sprite.transform.parent=imageselects.gameObject.transform;
   
   imageselects.spriteevents[i].Selectaction=()=>{
    nowSelectCharactor=member;
    nowSelectCharactorObj=Partys.InstanceObj[i];
};

    i++;
}
}
i=0;
}



public void PlayerTurn(){
  Guide("あなたの番です");
 

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
        
        
        case BattleState.CommandSelect:

interactionlist.createinteraction("攻撃",()=>{SwitchState(BattleState.WhoIsAttackPlayer);interactionlist.Alldeleteinteraction();});
interactionlist.createinteraction("逃げる",()=>{SwitchState(BattleState.Nigeru);interactionlist.Alldeleteinteraction();});
interactionlist.createinteraction("アイテム",()=>{SwitchState(BattleState.ItemSelect);interactionlist.Alldeleteinteraction();});

        
         break;

        case BattleState.WhoIsAttackPlayer:
    
    PlayerSideSelect.gameObject.SetActive(true);
    tempnum=0;
    GuideText.text=nowSelectCharactor.nickname;

PlayerSideSelect.decideaction=()=>{
   
    nowAttacker=nowSelectCharactor;
    nowAttackerObj=nowSelectCharactorObj;
    AutoRotateCamera.lerpatractcamera(nowAttackerObj.transform);
    AutoRotateCamera.CameraSettingSet(PlayerSideCameraSetting);
Guide(nowAttacker.nickname+"で攻撃を行います!");
PlayerSideSelect.decideaction=null;
PlayerSideSelect.gameObject.SetActive(false);
SwitchState(BattleState.SelectPlayerMotion);


};

            break;
            case BattleState.SelectPlayerMotion:

Guide(nowAttacker.nickname+"の使う技を選んでください");        
            foreach (var item in nowAttacker.RpgPlayerMotions)
            {
        
interactionlist.createinteraction(
    item.name,()=>{nowRpgPlayerMotion=item;
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


EnemySideSelect.decideaction=()=>{
   
    nowAttacked=nowSelectCharactor;
    nowAttackedObj=nowSelectCharactorObj;
    AutoRotateCamera.lerpatractcamera(nowAttackedObj.transform);
    AutoRotateCamera.CameraSettingSet(EnemySideCameraSetting);
    Guide(nowAttacker.nickname+"で攻撃を行います!");
    EnemySideSelect.decideaction=null;
    EnemySideSelect.gameObject.SetActive(false);
    SwitchState(BattleState.SelectPlayerMotion);


};

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




public void EnemyTurn(){

}






public void TurnChange(){

}


}