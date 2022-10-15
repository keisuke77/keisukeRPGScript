using UnityEngine;

public class cooldown : MonoBehaviour
{
    public float time;
    void Update()
    {
        if (time>0)
        {
            time-=Time.deltaTime;
        }else
        {
            time=0;
        }
    }
}

public static class instance
{
    public static cooldown cool;
}