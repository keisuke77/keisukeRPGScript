using UnityEngine;
using System.Collections;

public class spherecheck : MonoBehaviour
{
    CharacterController charCtrl;
public float radius;
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }
public void spheredamage(int damagevalue){
keikei.spherecheck.enabled=true;
check().transform.root.gameObject.GetComponentIfNotNull<enemyhp>().damage(damagevalue);

}

 private void Update()
{
    check();
}

    public GameObject check()
    {
        RaycastHit hit;

        Vector3 p1 = transform.position + charCtrl.center;
        float distanceToObstacle = 0;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(p1, radius, Vector3.down, out hit, 10))
        {
            return hit.collider.gameObject;
        }
        return null;
    }
}