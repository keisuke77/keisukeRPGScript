using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleecamera : MonoBehaviour
{
    public Transform enemy;
    public Transform player;
    public Vector3 controll;
    public Vector3 LookControll;
    public float distance;
    public Vector3 pos;
    Camera cam;

 

    public void Set(Transform t)
    {
        enemy = t;
        this.enabled = true;
    }

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void OnEnable()
    {
        gameObject.pclass().AutoRotateCamera.dontmove = true;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        gameObject.pclass().AutoRotateCamera.dontmove = false;
    }

    // Update is called once per frame
    void Update()
    {
        pos = (enemy.position - player.position).normalized * distance + controll + player.position;

        cam.transform.position = pos;
        cam.transform.LookAt(enemy.position + LookControll);
    }
}
