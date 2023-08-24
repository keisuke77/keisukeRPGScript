using UnityEngine;
using System;
using System.Collections;
using DG.Tweening;
public class IKControl : MonoBehaviour
{
    Animator avatar;                        // アバター
public bool active;
public float value;
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
bool t;
public void Stop(){
    active=false;
}
    void OnAnimatorIK(int layerIndex)
    {if (active)
        {
         
        if (avatar == null)
        {
            // 初期化
            InitAvatar();
        }
        else
        {    MoveAvatar();
        
            // 動かす
           
        }}
    }

    void InitAvatar()
    {
        Debug.Log("InitAvatar");
        avatar = GetComponent<Animator>();          // アバター設定

        // 見る対象
       

        // グリップの位置初期化
        // 身体
        body.position = avatar.bodyPosition;
        body.rotation = avatar.bodyRotation;

        // 手
        leftHand.position = avatar.GetBoneTransform(HumanBodyBones.LeftHand).position;
        //leftHand.rotation = avatar.GetBoneTransform(HumanBodyBones.LeftHand).rotation;
        rightHand.position = avatar.GetBoneTransform(HumanBodyBones.RightHand).position;
        //rightHand.rotation = avatar.GetBoneTransform(HumanBodyBones.RightHand).rotation;

        // ひじ
        leftElbow.position = avatar.GetBoneTransform(HumanBodyBones.LeftLowerArm).position;
        rightElbow.position = avatar.GetBoneTransform(HumanBodyBones.RightLowerArm).position;

        // 足
        leftFoot.position = avatar.GetBoneTransform(HumanBodyBones.LeftFoot).position;
        //leftFoot.rotation = avatar.GetBoneTransform(HumanBodyBones.LeftFoot).rotation;
        rightFoot.position = avatar.GetBoneTransform(HumanBodyBones.RightFoot).position;
        //rightFoot.rotation = avatar.GetBoneTransform(HumanBodyBones.RightFoot).rotation;

        // ひざ
        leftKnee.position = avatar.GetBoneTransform(HumanBodyBones.LeftLowerLeg).position;
        rightKnee.position = avatar.GetBoneTransform(HumanBodyBones.RightLowerLeg).position;
            }

public void weightSet(float a,float b,float c){
DOTween.To(x => value = x, a, b, c);
}

public void weight(float value){
    avatar.SetIKPositionWeight(AvatarIKGoal.LeftHand, value);
        avatar.SetIKRotationWeight(AvatarIKGoal.LeftHand, value);
        avatar.SetIKPositionWeight(AvatarIKGoal.RightHand, value);
        avatar.SetIKRotationWeight(AvatarIKGoal.RightHand, value);
        avatar.SetIKPositionWeight(AvatarIKGoal.LeftFoot, value);
        avatar.SetIKRotationWeight(AvatarIKGoal.LeftFoot, value);
        avatar.SetIKPositionWeight(AvatarIKGoal.RightFoot, value);
        avatar.SetIKRotationWeight(AvatarIKGoal.RightFoot, value);

        avatar.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, value);
        avatar.SetIKHintPositionWeight(AvatarIKHint.RightElbow, value);
        avatar.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, value);
        avatar.SetIKHintPositionWeight(AvatarIKHint.RightKnee, value);

}
    void MoveAvatar()
    {
        // 顔の向き
       
        // 身体
        avatar.bodyPosition = body.position;
        avatar.bodyRotation = body.rotation;
 avatar.SetLookAtPosition(lookAt.position);
  avatar.SetLookAtWeight(1.0f, 0.3f, 0.6f, 1.0f, 0.5f);
 
        // 移動先を設定
        avatar.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
        avatar.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);
        avatar.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
        avatar.SetIKRotation(AvatarIKGoal.RightHand, rightHand.rotation);
        avatar.SetIKPosition(AvatarIKGoal.LeftFoot, leftFoot.position);
        avatar.SetIKRotation(AvatarIKGoal.LeftFoot, leftFoot.rotation);
        avatar.SetIKPosition(AvatarIKGoal.RightFoot, rightFoot.position);
        avatar.SetIKRotation(AvatarIKGoal.RightFoot, rightFoot.rotation);

        avatar.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbow.position);
        avatar.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbow.position);
        avatar.SetIKHintPosition(AvatarIKHint.LeftKnee, leftKnee.position);
        avatar.SetIKHintPosition(AvatarIKHint.RightKnee, rightKnee.position);

        // 移動
    weight(1);
         }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {InitAvatar();
          }
}