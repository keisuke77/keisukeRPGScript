using UnityEngine;

public class IKMovePos : MonoBehaviour
{
     public Transform lookAt = null;         // 見る対象
    public Transform body = null;          // 身体

    public Transform leftHand = null;       // 左手
    public Transform rightHand = null;      // 右手
    public Transform leftFoot = null;       // 左足
    public Transform rightFoot = null;      // 右足

    public Transform leftElbow = null;      // 左ひじ
    public Transform rightElbow = null;     // 右ひじ
    public Transform leftKnee = null;       // 左ひざ
    public Transform rightKnee = null;      // 右ひざ


public void Init(IKControl IKControl){
    
 IKControl.body      =body     ;
 IKControl.leftHand  =leftHand ;
 IKControl.rightHand =rightHand;
 IKControl.leftFoot  =leftFoot ;
 IKControl.rightFoot =rightFoot;
 IKControl.leftElbow =leftElbow;
 IKControl.rightElbow=rightElbow;
 IKControl.leftKnee  =leftKnee ;
 IKControl.rightKnee =rightKnee;IKControl.active=true;
}
}