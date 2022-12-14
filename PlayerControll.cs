using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [SerializeField]
public class PlayerControll : MonoBehaviour
{
    private CharacterController controller;
    Animator anim;
    Quaternion targetRotation;
    [SerializeField]
    private float speed = 1.0f;[SerializeField]
    private float gravity = 9.8f;
   public Vector3 direction;

   public string horizon= "Horizontal";
   public string vertical= "Vertical";
    void Start()
    {TryGetComponent(out anim);TryGetComponent(out controller);
    targetRotation=transform.rotation;
    }

    void Update()
    {
        CalculateMove();
    }

    void CalculateMove()
    {
        float horizontalInput = Input.GetAxis(horizon);
        float verticalInput = Input.GetAxis(vertical);
        var cameravelc=Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y,Vector3.up);
         direction =cameravelc*  new Vector3(horizontalInput, 0, verticalInput).normalized;
if (direction.magnitude>0.5f)
{
    targetRotation=Quaternion.LookRotation(direction,Vector3.up);
}
transform.rotation=Quaternion.RotateTowards(transform.rotation,targetRotation,600*Time.deltaTime);
       anim.SetFloat("speed",direction.magnitude*speed,0.1f,Time.deltaTime);
       
       }
}