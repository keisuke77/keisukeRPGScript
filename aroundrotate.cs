using UnityEngine;

public class aroundrotate : MonoBehaviour
{
    public GameObject target;
   public float speed=10;
    void FixedUpdate()
    {
        gameObject.transform.RotateAround(target.transform.position,transform.up, speed*Time.deltaTime);
  
    }
}