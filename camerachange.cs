using UnityEngine;
using System.Collections;
 
public class camerachange : MonoBehaviour {
 int ori;
 public int active=0;
	//　メインカメラ
	
	[SerializeField]
    private Camera[] Cameralist;
	
void Start()
{ori=active;
	camerachanger();
}
public void change(){
active++;

}public void changeonly(){
camerachanger();


}

void camerachanger(){

	foreach (var Cameras in Cameralist)
	{
		Cameras.enabled=false;
	}
			
	
			
Cameralist[active].enabled=true;
}
	// Update is called once per frame
	void Update () {
		if (active==Cameralist.Length)
		{
			active=0;
			camerachanger();
	
		}
		//　1キーを押したらカメラの切り替えをする
		if(Input.GetKeyDown("1")) {

	
			change();
			camerachanger();
	
                }
						
	}
}
 