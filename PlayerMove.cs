using UI_InputSystem.Base;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

public class PlayerMove : playerMovePram
{
    public Vector3 LastMoveValue;
    Quaternion targetRotation;
    AutoRotateCamera AutoRotateCamera;
    public float h;				// 入力デバイスの水平軸をhで定義
    public float v;		
    public bool isJumping;
    public bool rigidcontroll;
public Vector3 forceValue;

public Vector3 velocity;

public float height;
    float forward;
    void Awake()
    {
        gameObject.pclass().playerMovePram = this;

    }

    public void Start()
    { targetRotation = transform.rotation;
        AutoRotateCamera = gameObject.pclass()?.AutoRotateCamera;
    }

    public override void AddForce(Vector3 force)
    {
        if (rigidcontroll)
        {
            rb.AddForce(force, ForceMode.Impulse);
        }
        else
        {
            StartCoroutine(AddForces(force));
        }
        if (AutoRotateCamera != null)
        {
            AutoRotateCamera.distance *= 2;
        }
    }

    IEnumerator AddForces(Vector3 force)
    {
        var forcepart = force / 10;
        var temp = forcepart;

        while (forcepart.sqrMagnitude < force.sqrMagnitude)
        {
            forceValue = temp;
            forcepart += temp;

            yield return new WaitForSeconds(0.0001f);
        }
        forceValue = Vector3.zero;
        if (AutoRotateCamera != null)
        {
            AutoRotateCamera.distance /= 2;
        }
        yield return null;
    }

    public void CalcVelocity()
    {
        if (anim != null)
        {
            if (anim.GetBool("swimming"))
            {
                height = keiinput.Instance.jump ? 1 : 0;
            }
            else
            {
                height = gravity;

                if (isJumping)
                {
                    height = jumpPower;
                }
            }
        }

        if (v > 0.1)
        {
            forward = forwardSpeed;
            forward *= v; // 移動速度を掛ける
        }
        else if (v < -0.1)
        {
            forward = backwardSpeed;
            forward *= v; // 移動速度を掛ける
        }
        else
        {
            forward = 0;
        }

        velocity = new Vector3(
            GetDirection(nowxyz.x),
            GetDirection(nowxyz.y),
            GetDirection(nowxyz.z)
        );

       

    }

    public float GetDirection(directionXYZ directionXYZ)
    {
        switch (directionXYZ)
        {
            case directionXYZ.front:
                return forward ;
                break;
            case directionXYZ.height:
                return height;
                break;
            case directionXYZ.horizon:
                return h ;
                break;
            default:
                return 0;
                break;
        }
    }

    public void MoveInput()
    {
        if (stop)
        {
            h = 0;
            v = 0;
            if (anim != null)
            {
                anim.SetFloat("Speed", 0); // Animator側で設定している"Speed"パラメタにvを渡す
                anim.SetFloat("Direction", 0);
            }
            return;
        }
      
            Vector2 dpad = keiinput.Instance.GetDpad();
            h = dpad.x;
            v = dpad.y;
        
        h = h.NotMini();
        v = v.NotMini();

        if (objrotate)
        {
            if (AutoRotateCamera != null)
            {
                AutoRotateCamera.rotaterate = 0;
                AutoRotateCamera.rotation = Vector3.zero;
            }
        }
        else
        {
            if (v == 0)
            {
                h = 0;
            }
        }

        if (keiinput.Instance.dashduring)
        {
            v *= dashpower;
        }

        if (rotateonly)
        {
            v = 0;
        }

        if (!isJumping)
        {
            anim.SetFloat("Speed", v);
        }

        anim.SetFloat("DirectionXdirectionXYZ", h);
    }



public bool camerabasemove;
    
    
    void FixedUpdate()
    {
        isJumping = anim.GetBool("Jump");
        MoveInput();
        CalcVelocity();
      
        if (camerabasemove)
        {
            objrotate=true;
              var cameravelc = Quaternion.AngleAxis(AutoRotateCamera.transform.eulerAngles.y, Vector3.up);
       var direction = cameravelc * new Vector3(h ,0, v).normalized;
        if (direction.magnitude > 0.5f)
        {
            targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            600 * Time.deltaTime
        );
        anim.SetFloat("Speed", direction.magnitude * movespeed, 0.1f, Time.deltaTime);
    velocity=direction;
        }else
        {
        trans.Rotate(nowxyz.Gethight() * h * rotateSpeed);
        // キャラクターのローカル空間での方向に変換
        velocity = trans.TransformDirection(velocity);
       

        }

    LastMoveValue = velocity * Time.deltaTime *movespeed* transform.localScale.x;
       

        if (rigidcontroll)
        {
            rb.velocity = LastMoveValue * 2;
            controller.enabled = false;
            rb.isKinematic = false;
        }
        else
        {
            controller.enabled = true;
            rb.isKinematic = true;
            controller.Move(LastMoveValue + forceValue);
        }
        // 左右のキー入力でキャラクタをY軸で旋回させる
         
        
      
    }
}
