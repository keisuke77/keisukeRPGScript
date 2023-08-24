using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce : MonoBehaviour
{
    public bool relatemass;
    public bool forwardforce;
    Rigidbody rb;
    public float power = 10f;
    public Vector3 direction;
    [Header("forcemodeの時のみ")]
    public bool repeat;

[Button("AddForce","AddForce")]
    public int btn;
    public bool randomdirection;
    public ForceMode mode;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddForce()
    {
        if (forwardforce)
        {
            direction = transform.forward;
        }
        if (randomdirection)
        {
            direction = keikei.randomvector();
        }
        if (relatemass)
        {
            direction *= rb.mass;
        }


            rb.AddForce(direction * power, mode);
        
    }

    void FixedUpdate()
    {
        if (!repeat)
        {
            return;
        }
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (mode == ForceMode.Force)
        {
            AddForce();
        }
    }
    // Update is called once per frame
}
