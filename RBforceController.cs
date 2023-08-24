using UnityEngine;
using System.Collections;

// Add a thrust force to push an object in its current forward
// direction (to simulate a rocket motor, say).
public class RBforceController : MonoBehaviour
{
    public float rotateSpeed;
    public float thrust;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis ("Horizontal");				// 入力デバイスの水平軸をhで定義
	    float v = Input.GetAxis ("Vertical");		
        rb.AddRelativeForce(Vector3.forward * thrust);
        transform.Rotate (0,h * rotateSpeed,0);	
    }
}
