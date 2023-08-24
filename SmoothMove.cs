
 
using UnityEngine;
using System.Collections;
 
public class SmoothMove : MonoBehaviour {
 
	[SerializeField] private Transform target;	//　カメラの到達点
	[SerializeField] private float moveSpeed;	//　カメラの移動速度
	[SerializeField] private float duration;	//　カメラの移動間隔
	[SerializeField] private float rotateSpeed;	//　カメラの回転スピード
	[SerializeField] private float colorSpeed;	//　色変化のスピード
	[SerializeField] private float maxSpeed;	//　最高速度
	[SerializeField] private Color backColor;
	public bool movestart;	//　カメラの背景の色
 	//　カメラの背景の色
 public Transform test;
	private Vector3 moveVelocity;			//　現在の移動の速度
	private float xVelocity;			//　現在の回転の速度
	private float yVelocity;			//　現在の回転の速度
	private float zVelocity;			//　現在の回転の速度
	private Vector3 allRotateVelocity;		//　全ての角度を変える場合に使用する速度
	private float colorVelocity;			//　色変化用の現在の速度
	private float startTime;			//　開始時間
 
	void Start () {
		startTime = Time.time;
	}
 public void execute(){
movestart=true;
startTime = Time.time;
 }
 
 
 public void execute(Transform point){
	 target=point;
	 execute();
 }

 public void executerotate(Transform point){
point.position=transform.position;
	 target=point;
	 execute();
 }

	void Update () {


		if (Input.GetKeyDown(KeyCode.B))
		{
			executerotate(test);
		}
		if (!movestart)
		{
			return;
		}else if(transform.position==target.position&&transform.rotation==target.rotation)
		{
			movestart=false;
		}

		//　位置をスムーズに動かす
//		transform.position = Vector3.SmoothDamp (transform.position, target.position, ref moveVelocity, moveSpeed * Time.deltaTime, maxSpeed);
		//　位置をスムーズに動かすSmoothStep版
		var t = (Time.time - startTime) / duration;
		var xPos = Mathf.SmoothStep (transform.position.x, target.position.x, t);
		var yPos = Mathf.SmoothStep (transform.position.y, target.position.y, t);
		var zPos = Mathf.SmoothStep (transform.position.z, target.position.z, t);
		transform.position = new Vector3(xPos, yPos, zPos);
 
 
		//　カメラの角度をスムーズに動かす
		var xRotate = Mathf.SmoothDampAngle (transform.eulerAngles.x, target.eulerAngles.x, ref xVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
		var yRotate = Mathf.SmoothDampAngle (transform.eulerAngles.y, target.eulerAngles.y, ref yVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
		var zRotate = Mathf.SmoothDampAngle (transform.eulerAngles.z, target.eulerAngles.z, ref zVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
		transform.eulerAngles = new Vector3 (xRotate, yRotate, zRotate);
 
		//　カメラの背景色を変更
		var colorR = Mathf.SmoothDamp (Camera.main.backgroundColor.r, backColor.r, ref colorVelocity, colorSpeed * Time.deltaTime, maxSpeed);
		var colorG = Mathf.SmoothDamp (Camera.main.backgroundColor.g, backColor.g, ref colorVelocity, colorSpeed * Time.deltaTime, maxSpeed);
		var colorB = Mathf.SmoothDamp (Camera.main.backgroundColor.b, backColor.b, ref colorVelocity, colorSpeed * Time.deltaTime, maxSpeed);
 
		Camera.main.backgroundColor = new Color (colorR, colorG, colorB, 1f);
	}
}
 