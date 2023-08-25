using UnityEngine;

public class multcamera : MonoBehaviour
{
    public CameraMultiTarget m_cameraMultiTarget;

    public GameObject[] m_gameObjects;

    private void Awake()
<<<<<<< HEAD
    {keikei.multcamera=this;
=======
    {
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
        m_cameraMultiTarget.SetTargets( m_gameObjects );
    }
}