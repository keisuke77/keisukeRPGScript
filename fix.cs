using UnityEngine;

public class fix : MonoBehaviour
{
    // Sets this transform to have the opposite rotation of the target

    Transform target;
    void Update()
    {
        transform.rotation = Quaternion.Inverse(target.rotation);
    }
}