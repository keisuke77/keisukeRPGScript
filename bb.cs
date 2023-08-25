using UnityEngine;

/// <summary>
/// Transform.RotateAroundを用いた円運動
/// </summary>
public class UseRotateAround : MonoBehaviour
{
    // 中心点
    
 [SerializeField] private Transform _center; 
bool nocenter;
    // 回転軸
    [SerializeField] private Vector3 _axis = Vector3.up;

    // 円運動周期
    [SerializeField] private float _period = 2;
void Start()
{if (_center==null)
{
    nocenter=true;
}
    
}
    private void Update()
    {if (nocenter)
    {
         transform.RotateAround(
            Vector3.zero,
            _axis,
            360 / _period * Time.deltaTime
        );
    }else
    {
         transform.RotateAround(
            _center.position,
            _axis,
            360 / _period * Time.deltaTime
        );
    }
        // 中心点centerの周りを、軸axisで、period周期で円運動
       
    }
}