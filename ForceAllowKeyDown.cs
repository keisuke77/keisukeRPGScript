using UnityEngine;

public class ForceAllowKeyDown : MonoBehaviour
{ 
    [SerializeField]
    private float       m_power         = 0.0f;
    [SerializeField]
    private Vector3     m_powerDir      = Vector3.zero;
    [SerializeField]
    private Rigidbody[] m_rigidbodies   = null;

    public KeyCode key;

    private void FixedUpdate()
    {


        float h = Input.GetAxis ("Horizontal");				// 入力デバイスの水平軸をhで定義
	    float v = Input.GetAxis ("Vertical");
        	m_powerDir.x = h;
            m_powerDir.z = v;
        if(key.keydown())
        { Debug.Log(m_powerDir.x);

            foreach( var rigidbody in m_rigidbodies )
            {
                rigidbody.AddForceAtPosition( m_powerDir.normalized * m_power, m_powerDir );
            }
        }
    }

}