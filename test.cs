using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject b;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        var a=gameObject.GetComponentIfNotNull<hp>();
        b.Instantiate(transform);
    }
}