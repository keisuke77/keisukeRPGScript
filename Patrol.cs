using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Patrol
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public Patrol(NavMeshAgent NavMeshAgent, Transform[] pointss)
    {
        agent = NavMeshAgent;
        points = pointss;
        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        //(つまり、エージェントは目標地点に近づいても
        // 速度をおとしません)
        agent.autoBraking = false;
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
        {
            return;
        }

        // エージェントが現在設定された目標地点に行くように設定します
        agent.destination = points[destPoint].position;
        destPoint++;
        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
    }

    public void Update()
    {
        destPoint = (int)Mathf.Repeat(destPoint, points.Length);
        // エージェントが現目標地点に近づいてきたら、
        // 次の目標地点を選択します
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }
}
