using UnityEngine;

[CreateAssetMenu(fileName = "CameraSetting", menuName = "")]
public class CameraSetting : ScriptableObject
{
    public float distance=8;
    public float rotateY=1;
    public Vector3 ControllPos;
    public float rotaterate;
    
}