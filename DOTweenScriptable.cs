using UnityEngine;

[CreateAssetMenu(fileName = "DOTweenScriptable", menuName = "")]
public class DOTweenScriptable : ScriptableObject
{
     public Vector3 move;
    public Vector3 rot;
    public Vector3 Scale;
    public float speed;
    public bool autoStart;

}