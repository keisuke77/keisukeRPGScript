//
// Mecanimのアニメーションデータが、原点で移動しない場合の Rigidbody付きコントローラ
// サンプル
// 2014/03/13 N.Kobyasahi
using UI_InputSystem.Base;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

public enum directionXYZ
{front,horizon,height
	 
}
interface IForceIdle
{
void AddForce(Vector3 force);	
}
// 必要なコンポーネントの列記
	[RequireComponent(typeof(Animator))]
	public class UnityChanControlScriptWithRgidBody : MonoBehaviour,IForceIdle
	{

	public Rigidbody rb;
	public bool rigidcontroll;
	  public float test;
public static bool mine;
  public CharacterController controller;
  public underwater bodyunderwater;
   public LayerMask targetLayer;
		public bool stop=false;
		public float gravity=9;  
	float t=0;
	float damagetime;
	mp mp;
	public charges charges;
    public bool rotateonly;
    public bool attackkeycode;
		public float animSpeed = 1.5f;				// アニメーション再生速度設定
		public float lookSmoother = 3.0f;			// a smoothing setting for camera motion
		public bool useCurves = true;				// Mecanimでカーブ調整を使うか設定する
		// このスイッチが入っていないとカーブは使われない
		public float useCurvesHeight = 0.5f;		// カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）
public float h;				// 入力デバイスの水平軸をhで定義
		public float v;		
		public float lowmove;
		// 以下キャラクターコントローラ用パラメタ
		// 前進速度
		public float forwardSpeed = 7.0f;
		// 後退速度
		public float backwardSpeed = 2.0f;
		// 旋回速度
		public float rotateSpeed = 2.0f;
		// ジャンプ威力
		public float jumpPower = 3.0f; 
		// キャラクターコントローラ（カプセルコライダ）の参照
		private CapsuleCollider col;
			[Range(0, 5)]
		 public float dashspeedduring=2.5f;
		// キャラクターコントローラ（カプセルコライダ）の移動量
		public Vector3 velocity;
		// CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
		private float orgColHight;
		private Vector3 orgVectColCenter;
		public Animator anim;							// base layerで使われる、アニメーターの現在の状態の参照
public bool damaged=false;
		private GameObject cameraObject;	// メインカメラへの参照
	RaycastHit slideHit;
	public bool isSliding;
	public GameObject canvasios;
	public keiinput keiinput;
	public bool _isGrounded;
	public AutoRotateCamera AutoRotateCamera;
	public bool isJumping;
	public float dashpower=1;
	public float movespeed=1;
public float groundtime;
	public Sprite downSprite;
public xyz defaultxyz;
public xyz nowxyz;
	public GameObject ControlObj;
	
	itemcurrent itemcurrent;
private int time=0;

public void damage(){

damaged=true;
anim.SetBool ("wakeup", false);
anim.SetTrigger("damage");
}

public void damageheal(){
	damaged=false;

	anim.SetBool ("wakeup", true);
	}
	


	void OnEnable()
	{if (keikei.player!=null)
	{
		keikei.player=this.gameObject;
			keikei.playerset();
	
	}
	}

	
	void LateStart()
	{
		controller.enabled=false;
	}
	 void Awake()
	{
	UpdateControlObj();
		 hp=GetComponent<hp>();
			 mp=GetComponent<mp>();
			anim = GetComponent<Animator> ();
			// CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
			col = gameObject.GetComponentIfNotNull<CapsuleCollider> ();
      
		keikei.player=this.gameObject;
			keikei.playerset();
	keikei.Allplayer=new List<GameObject>(10);
			}
				// 初期化



		void UpdateControlObj(){
        rb=ControlObj.AddComponentIfnull<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotation;

		 controller=ControlObj.AddComponentIfnull<CharacterController>();
		trans=ControlObj.transform;
AutoRotateCamera.lerpatractcamera(trans);
AutoRotateCamera.Player=trans;
AutoRotateCamera.nowxyz=nowxyz;
anim=ControlObj.AddComponentIfnull<Animator>();
		}



public void ChangeControlObj(GameObject obj){
ControlObj=obj;
UpdateControlObj();
}
public void resetxyz(){
nowxyz=defaultxyz;
}
		void Start ()
		{   resetxyz();
			keikei.Allplayer.Add(gameObject);
		 charges=new charges(gameObject);
		 itemcurrent=gameObject.pclass().itemcurrent;
			defaultstepOffset=controller.stepOffset;
AutoRotateCamera.nowxyz=nowxyz;
			 keiinput=gameObject.pclass().keiinput;
			
	
		}

hp hp;


	 void jumps(){
		 if (damaged)
		 {
			 anim.SetBool ("wakeup", true);
		     damaged=false;
						 }else
		 {
		    anim.SetBool ("Jump", true);
		 }	
		 
	}

	public void start(){
		stop=false;
	}public void pause(){v=0;h=0;
		stop=true;

	}

public void animcancell(){

	anim.Play("Idle");
}

public void Landed(){

AutoRotateCamera.recovercamera();
fall=false;
falltime=0;
if (falldamage>10)
{
anim.SetTrigger("ground");
	
hp.damage((int)falldamage);
}else{

	
anim.SetTrigger("land");
}
falldamage=0;
}

public void AddForce(Vector3 force){
if (rigidcontroll)
{
	rb.AddForce(force,ForceMode.Impulse);
}else
{
 StartCoroutine(AddForces(force));
}
if (gameObject.pclass()!=null)
{
	gameObject.pclass().AutoRotateCamera.distance*=2;
}
}

IEnumerator AddForces(Vector3 force)
{
var forcepart=force/10;
	var temp=forcepart;
	
	while (forcepart.sqrMagnitude<force.sqrMagnitude)
	{
		forceValue=temp;
forcepart+=temp;

yield return new WaitForSeconds(0.0001f);
	}
forceValue=Vector3.zero;
gameObject.pclass().AutoRotateCamera.distance/=2;
	yield return null;
}

public void freehandattack(){
anim.SetFloat("swordmode", 0);
charges.chargepower("attack");
if (keiinput.guard)
	{
          if (mp.mpuse(8))
          {
             anim.SetBool("kaihi",true);
          }
	}
     
if (keiinput.guardup)
	{anim.SetBool("kaihi",false);
     }
           
        
    
}

bool once1;

void falling(){
if (!fall)
{
anim.SetTrigger("fall");
falldamage=transform.grounddistances(targetLayer);
AutoRotateCamera.resetcamera();
fall=true;
}
h=0;					
anim.SetBool("fall", true);
anim.SetBool("sky", true);

}


void animcontoroll(){

if(anim==null)return;
	

	if (v>0)
	{
		anim.SetBool("walk",true);
	}else
	{
		anim.SetBool("walk",false);
	}
isJumping = anim.GetBool ("Jump");

if (anim.GetBool("swimming")){


anim.SetBool("sky", false);
	anim.SetBool("fall", false);
}
	

if (_isGrounded||anim.GetBool("swimming")) 
{
if (fall)
{
	Landed();
}
falltime=0;		
if(bodyunderwater.iswater)return;

anim.SetBool("sky", false);
anim.SetBool("fall", false);
}else{
if (controller.velocity.y<0)
{
falling();
}


} 

}
public bool objrotate;
public Vector3 LastMoveValue;
public void MoveInput(){

if (stop)
{h=0;v=0;
	return;
}
if (keiinput!=null)
{
	
Vector2 dpad= keiinput.GetDpad();
h = dpad.x;	
v = dpad.y;	
}
h=h.NotMini();
v=v.NotMini();

if (objrotate)
{
	AutoRotateCamera.rotaterate=0;
	AutoRotateCamera.rotation=Vector3.zero;
}else
{
	if (v==0)
{
	h=0;
}
}

if (keiinput.dashduring)
{
	v*=dashpower;
}

 if (rotateonly||damaged)
 {
	v=0;
 }

	if (!isJumping)
	{
anim.SetFloat ("Speed", v);	
	}			
anim.SetFloat ("DirectionXdirectionXYZ", h); 	
	


}

public float GetDirection(directionXYZ directionXYZ){
switch (directionXYZ)
{
	case directionXYZ.front: return forward*movespeed;
		break;case directionXYZ.height: return height;
		break;case directionXYZ.horizon: return h*movespeed;
		break;
	default:return 0;
		break;
}

}
public float forward;
public float height;	
public Vector3 CalcVelocity(){

			if (anim.GetBool("swimming"))
			{
			height=	keiinput.jump?1:0;
				
			}else
			{	
				height=gravity;
			
			  if(isJumping)
		{
			height=jumpPower;
		}	
			}

    

			
				


				if (v > 0.1) {
				forward = forwardSpeed;	
				forward*=v;	// 移動速度を掛ける
			  } else if (v < -0.1) {
				forward = backwardSpeed;	
				forward*=v;// 移動速度を掛ける
			   }else
			   {
				forward=0;
			   }

	velocity = new Vector3 (GetDirection(nowxyz.x), GetDirection(nowxyz.y), GetDirection(nowxyz.z));

	
	// キャラクターのローカル空間での方向に変換
			velocity = trans.TransformDirection (velocity);
		
        
 if (isSliding)
            {//滑るフラグが立ってたら
                Debug.Log("滑る処理です");
                Vector3 hitNormal = slideHit.normal;
                velocity.x = hitNormal.x;
                  velocity.z = hitNormal.z;
            }
            
return velocity;

}


public Vector3 forceValue;

    public Vector3 lookDirectionXdirectionXYZ { get; private set; }

    public void RotateGravity(Vector3 up)
    {
        lookDirectionXdirectionXYZ = Quaternion.FromToRotation(transform.up, up) * lookDirectionXdirectionXYZ;
    }


public bool fall;
public float falltime;
public float falldamage;

  public void damagestop(){


damaged=true;
anim.SetBool("wakeup",false);
}
float defaultstepOffset;
		// 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
		void FixedUpdate ()
		{	

      
if (transform.grounddistances(targetLayer).debug() >10)
{
	_isGrounded=false;
}else  if (transform.grounddistances(targetLayer).debug()<1 )
{
	_isGrounded=true;
}

if (controller!=null)
{
	controller.stepOffset=defaultstepOffset*transform.localScale.y;
}

if (itemcurrent==null)
{
	freehandattack();
}

animcontoroll();

if (anim.GetBool("dead"))
{
	stop=true;
}
		
		
			 
MoveInput();
　　

		 LastMoveValue=	CalcVelocity() * Time.deltaTime*transform.localScale.x;
		if (rigidcontroll)
		{
			rb.velocity=LastMoveValue*2;
			controller.enabled=false;
			rb.isKinematic=false;
		}else
		{
			controller.enabled=true;
	rb.isKinematic=true;
 controller.Move(LastMoveValue/60+forceValue);

		}
			// 上下のキー入力でキャラクターを移動させる
	
			// 左右のキー入力でキャラクタをY軸で旋回させる
			trans.Rotate (nowxyz.Gethight()*h*rotateSpeed);


			if (keiinput.jump) {	// スペースキーを入力したら
jumps();
		}
		

		}

		
Transform trans;


	}
