using UnityEngine;

public class multcamera : MonoBehaviour
{
    public CameraMultiTarget m_cameraMultiTarget;

    public GameObject[] m_gameObjects;

    private void Awake()
    {
        m_cameraMultiTarget.SetTargets( m_gameObjects );
    }
}