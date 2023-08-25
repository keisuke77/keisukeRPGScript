using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ride : MonoBehaviour
{ IKMovePos IKMovePos;
int count;
GameObject rider;
public xyz xyz;
public CameraSetting CameraSetting;
  public void RidePlayer(GameObject player){
    rider=player;
<<<<<<< HEAD
    rider.pclass().UpdateControlObj(gameObject,xyz);
player.pclass().AutoRotateCamera?.CameraSettingSet(CameraSetting);
IKMovePos.Init(player.GetComponent<IKControl>());
count= player.pclass().interactionlist.createinteraction("降りる",()=>{UnRide();  rider.pclass().interactionlist.deleteinteraction(count);});
   }

   public void UnRide(){
    rider.pclass().ResetControlObj();
rider.GetComponent<IKControl>().active=false;
keikei.PlayerEnterTransform(rider,gameObject.transform);
    }


	




void OnDestroy()
{
    UnRide();
    rider.pclass().interactionlist.deleteinteraction(count);
    rider=null;
=======
player.GetComponent<UnityChanControlScriptWithRgidBody>().nowxyz=xyz;
player.GetComponent<UnityChanControlScriptWithRgidBody>().ChangeControlObj(gameObject);
player.pclass().AutoRotateCamera.CameraSettingSet(CameraSetting);
IKMovePos.Init(player.GetComponent<IKControl>());

count= player.pclass().interactionlist.createinteraction("降りる",()=>{UnRide(player);  rider.pclass().interactionlist.deleteinteraction(count);});
   }

   public void UnRide(GameObject player){

player.GetComponent<UnityChanControlScriptWithRgidBody>().resetxyz();
player.pclass().AutoRotateCamera.atractend();
　　　　　player.GetComponent<UnityChanControlScriptWithRgidBody>().ChangeControlObj(player);
        player.GetComponent<IKControl>().active=false;
        keikei.PlayerEnterTransform(player,gameObject.transform);
    }
void OnDestroy()
{
    UnRide(rider);
    rider.pclass().interactionlist.deleteinteraction(count);
    
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}
    // Start is called before the first frame update
 void Start()
 {
    IKMovePos=GetComponentInChildren<IKMovePos>();
 }
}
