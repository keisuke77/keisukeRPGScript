using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class ForceableObj : MonoBehaviour
{
    private int m_transition = 0;

    private NavMeshAgent m_navmesh_agent;
    private Rigidbody m_rigidbody;
    private int m_iskinematic_change_frame = 0;
    private Vector3 m_impact_vector;

    [Button("test", "test")]
    public int debug;
    public Vector3 Debuger;

    public void test()
    {
        AddForce(Debuger);
    }

    public void Update()
    {
        Debug.Log(m_rigidbody.IsSleeping());

        if (m_transition == 0)
        {
            m_transition = 1;
            m_iskinematic_change_frame = Time.frameCount; // 補足２
            m_navmesh_agent.enabled = false;
            m_rigidbody.isKinematic = false;
            m_rigidbody.AddForce(m_impact_vector, ForceMode.Impulse);
        }

        if ((m_transition == 1) && (m_rigidbody.IsSleeping()))
        {
            m_iskinematic_change_frame = Time.frameCount; // 補足２
            m_navmesh_agent.enabled = true;
            m_rigidbody.isKinematic = true;
        }
    }

    void Start()
    {
        m_navmesh_agent = GetComponent<NavMeshAgent>();
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public void AddForce(GameObject Attacker, float Power)
    {
        if ((m_iskinematic_change_frame == Time.frameCount))
            return; // 補足２

        Attacker.ColliderDataInput(gameObject, ref m_impact_vector, Power);

        if (m_impact_vector != Vector3.zero)
        {
            m_transition = 0;
        }
    }

    public void AddForce(Vector3 dir)
    {
        if ((m_iskinematic_change_frame == Time.frameCount))
            return; // 補足２
        m_impact_vector = dir;

        if (m_impact_vector != Vector3.zero)
        {
            m_transition = 0;
        }
    }
}
