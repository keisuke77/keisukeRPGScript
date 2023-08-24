using UnityEngine;

public class SmoothLook : MonoBehaviour
{
Transform trans;
public Transform target;
Vector3 angle;
private float xVelocity;			//　現在の回転の速度
	private float yVelocity;			//　現在の回転の速度
	private float zVelocity;			//　現在の回転の速度
	[SerializeField] private float rotateSpeed;	//　カメラの回転スピード
	[SerializeField] private float maxSpeed;
bool once;
void Start()
{
    trans=transform;
}

public void execute(){

 angle =target.rotation.eulerAngles-  trans.rotation.eulerAngles;
once=true;
}
public void execute(Transform tra){
Debug.Log("awejkrfnwbufioejw");
 angle =tra.rotation.eulerAngles-  trans.rotation.eulerAngles;
once=true;
}
void Update()
{

    if (angle==trans.rotation.eulerAngles)
    {

        once=false;
        return;

    }
if (once)
{
    
var xRotate = Mathf.SmoothDampAngle (trans.eulerAngles.x, angle.x, ref xVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
		var yRotate = Mathf.SmoothDampAngle (trans.eulerAngles.y, angle.y, ref yVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
		var zRotate = Mathf.SmoothDampAngle (trans.eulerAngles.z, angle.z, ref zVelocity, rotateSpeed * Time.deltaTime, maxSpeed);
		trans.eulerAngles = new Vector3 (xRotate, yRotate, zRotate);
 

}

    
}
    	
		//　カメラの背景色を変更
	
}