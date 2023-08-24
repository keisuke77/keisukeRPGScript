using UnityEngine;

public class KeisukeBehavior : MonoBehaviour
{
    [Button("SetUp", "SetUp")]
    public int Reset;

    public virtual void SetUp() { }

    void Awake()
    {
        SetUp();
    }
}
