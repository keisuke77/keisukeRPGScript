using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class AutoRotateCamera : MonoBehaviour {
 
    //　キャラクターのTransform
public message message;
public bool ScrollWheel;
[HideInInspector]
    public Transform camera;

    public Transform charaLookAtPosition;
    
    public Transform defaultcharaLookAtPosition;
    
   public Transform defaultparent;
    //　カメラの移動スピード
    [SerializeField]
    private float cameraMoveSpeed = 2f;
   public keiinput keiinput;
public float rotatesensvilty=20;
    public bool lookat;
    [SerializeField]
    private float cameraRotateSpeed = 90f;
 
 public Vector3 ControllPos;
public bool dontmove;
public float defaultdistance=15;
    [SerializeField]
    private LayerMask obstacleLayer;
    bool once;
public bool allwaysmove;
    public CameraSetting defaultCameraSetting;
    public CameraSetting nowCameraSetting;
float zpos;
public float distance;
public float rotaterate;
public Transform Player;
public float runclose=2;
 float _rotatesensvilty;
public xyz nowxyz;
public Vector3 rotation;
public bool Scaling; 
public float scale;
 void Awake()
 {

camera=gameObject.transform;
if (gameObject.proottag())
{
  gameObject.pclass().AutoRotateCamera=this;
} 
 Player=gameObject.root().transform;   


keikei.AutoRotateCameraAll=UnityEngine.Object.FindObjectsOfType(typeof(AutoRotateCamera))as AutoRotateCamera[];
       keiinput=gameObject.pclass().keiinput;
  
 }


public void CameraSettingSet(CameraSetting c){

nowCameraSetting=c;
rotaterate=c.rotaterate;
distance=c.distance;
rotateY=c.rotateY;
ControllPos=c.ControllPos;

}




void Start() {

  atractend();
  angleReset();
			 
}


  public void SetMessage(string mes,bool auto=false,Sprite icon=null){

message.SetMessagePanel(mes,auto,icon);
  }

  public void SetMessage(string mes,System.Action action){

message.action=delegate(){
  action();
};
SetMessage(mes);
  }


public void SetMessageAtractCamera(Transform trans,string messagetext,System.Action action=null,bool autoprocess=false){

lerpatractcamera(trans);

message.action=delegate(){
  atractend();
  action();
};
SetMessage(messagetext,autoprocess);

}

public void atractend(){ 
charaLookAtPosition=defaultcharaLookAtPosition;

Player=defaultcharaLookAtPosition.gameObject.root().transform;


CameraSettingSet(defaultCameraSetting);
  transform.parent=defaultparent;  
  distance=defaultdistance;
    learping=true;
 }

 
public void lerpatractcamera(Transform trans){

charaLookAtPosition=trans;
  transform.parent=trans;  // Update is called once per frame
  learping=true;
Player=gameObject.root().transform;   

}




public void lerpatractcamera(Transform trans,float distances){

lerpatractcamera(trans);
lerpatractcamera(distances);
}

public void lerpatractcamera(float distances){



distance=distances;
   // Update is called once per frame
    learping=true;
}

 public void lookchange(float time){

distance*=-1;
Invoke("lookchangeend",time);
 }
 public void lookchange(){

distance*=-1;
Invoke("lookchangeend",1f);
 }
 public void lookchangeend(){

distance*=-1;

 }

public void angleReset(){
var parent=camera.parent;
      camera.parent=null;
      Player.LookAt(camera,nowxyz.Gethight());
      Vector3 angle=Player.eulerAngles;
      Player.eulerAngles=nowxyz.Gethight(angle+new Vector3(180,180,180) ); 
		  rotaterate=0;
      camera.parent=parent;
}

public float yaxis=1.8f;
public float rotateY;
[Range(1,10)]
public float rotateYrange=1;
public void resetcamera(){
 camera.parent=null;
 cameraMoveSpeed=0;


}
public void recovercamera(){
 camera.parent=defaultparent;
 cameraMoveSpeed=2;
}

public void CameraControll(){
if (dontmove)
{
  return;
}
if (rotation.x!=0||learping||allwaysmove)
{
float _distance=distance*scale;
   rotaterate+= (float)rotation.x*_rotatesensvilty;
    rotateY+= (float)rotation.y/10;
    float _rotateY=rotateY*scale;
    _rotateY=Mathf.Clamp(_rotateY,-rotateYrange,rotateYrange);
     Vector3 vec=(new Vector3(Mathf.Sin(rotaterate)*_distance,yaxis+_rotateY,Mathf.Cos(rotaterate)*_distance));
Vector3 vecs=(-charaLookAtPosition.forward * vec.z) + (Vector3.up * vec.y)+ (-charaLookAtPosition.right * vec.x); //　通常のカメラ位置を計算
        var cameraPos = charaLookAtPosition.position+(vecs);
        //　カメラの位置をキャラクターの後ろ側に移動させる
     if (camera.position==cameraPos)
{
  learping=false;
}  camera.position = Vector3.Lerp(camera.position, cameraPos, cameraMoveSpeed * Time.deltaTime);

}
 

}


public bool learping;




 Vector3 direction;

    void Update() {
    if (Scaling)
    {
     scale= charaLookAtPosition.localScale.y;
    }else
    {
      scale=1;
    }
    if (keiinput!=null)
    {
      rotation=(Vector3)keiinput?.GetRotate();
direction=(Vector3)keiinput?.GetDpad();
    }

if (ScrollWheel)
{
    
distance+= Input.GetAxis("Mouse ScrollWheel")*5;
distance=Mathf.Clamp(distance,-20,20);

}

   

if (direction.y!=0&&!once)
{
  	angleReset();
once=true;
_rotatesensvilty=0;
   distance/=runclose;
   rotateY/=runclose;
}else if(direction.y==0&&once)
{
    once=false;
    _rotatesensvilty=rotatesensvilty;
   distance*=runclose;
   rotateY*=runclose;
}

CameraControll();
           
        RaycastHit hit;
        //　キャラクターとカメラの間に障害物があったら障害物の位置にカメラを移動させる
        if (Physics.Linecast(charaLookAtPosition.position+ControllPos, camera.position, out hit, obstacleLayer)) {
            camera.position = hit.point;
        }

        
    
             //　レイを視覚的に確認
        Debug.DrawLine(charaLookAtPosition.position, camera.position, Color.red, 0f, false);
 
        //　スピードを考慮しない場合はLookAtで出来る
        //transform.LookAt(charaTra.position);
        //　スピードを考慮する場合
if (lookat)
{
       camera.LookAt(charaLookAtPosition.position+(ControllPos*scale));
}
      }
}
 