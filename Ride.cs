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
}
    // Start is called before the first frame update
 void Start()
 {
    IKMovePos=GetComponentInChildren<IKMovePos>();
 }
}
