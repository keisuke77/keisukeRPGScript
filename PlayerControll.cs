using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PlayerControll : MonoBehaviour, IMove
{
    [SerializeField]
    private Animator anim;
    Quaternion targetRotation;
    Camera cam;
    public bool isTransformMove;
[Range(0,10)]    public float TransformSpeed=1;
   
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public bool Stop { get; set; }
    
     [SerializeField]
    private float gravity = 9.8f;
    public Vector3 direction;
  
  [Header("アニメーションの速度最高値　基本最高値は１"),Range(0,10)]
   public float _speed;
    
    public bool AngleChangeBrake;
    public float animDamper=0.1f;

    public bool simplemove;
    void Start()
    {Application.targetFrameRate = 120; 
        if (gameObject.pclass() != null)
        {
            gameObject.pclass().PlayerControll = this;
        }
        cam = Camera.main;
    }

    void OnEnable()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        CalculateMove();
    }

    void CalculateMove()
    {
        if (Stop)
        {
            anim.SetFloat("speed", 0);
            return;
        }

        direction=transform.CameraDirection(cam,keiinput.Instance.directionkey);

       if (direction.magnitude > 0.5f)
        {
            targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        // 前フレームからの回転量をあらかじめ求める
        var diffRotation = Quaternion.Inverse(transform.rotation) * targetRotation;

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            600 * Time.deltaTime
        );

        // 回転した角度と軸（ローカル空間）を求める
        diffRotation.ToAngleAxis(out var angle, out var axis);
 
        anim.SetFloat("deltaAngler", angle, 0.1f, Time.deltaTime);
        angle = angle / 360;
        if (AngleChangeBrake)
        {
                anim.SetFloat("speed",(direction.magnitude - angle) * speed, animDamper, Time.deltaTime);
        }else
        {
                   anim.SetFloat("speed", direction.magnitude  * speed, animDamper, Time.deltaTime);
     
        }
        if (simplemove)
        {
             anim.SetFloat("speed", (int)(keiinput.Instance.directionkey.magnitude * speed));
   
        }


    Debug.Log("hh");
        if (isTransformMove)
        {
            transform.position += direction * Time.deltaTime * TransformSpeed*speed;
        }
    }
}
