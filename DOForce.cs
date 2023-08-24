using UnityEngine;

using DG.Tweening;

public class DOForce : MonoBehaviour
{
    [Header("吹っ飛び速度調整"),Range(0,100)]
    public float knockbackSpeed;
    [Header("吹っ飛び曲線調整")]
    public AnimationCurve Curve;
    public bool isRigid;
    public LayerMask groundMask;
    public float groundDistance=1;
    public RaycastHit hit;
    public Vector3 CastOffset;

    public EffectAndParticle HitEffect;
 [Range(0,1)]
public float ReflectionForce;
    public bool TweeningExecute;
  
    public void AddForce(GameObject Attacker, float Power)
    { Vector3 m_impact_vector=Vector3.one;
    if (Attacker)
    {
           Attacker.ColliderDataInput(gameObject, ref m_impact_vector, Power);
       AddForce(m_impact_vector,Power);
    }
       
    }
  
    public void AddForce(Vector3 impactVector, float Power)
    {
        Debug.Log("doforce");
        if (!TweeningExecute&&DOTween.IsTweening(transform))
            return; 
               
              if (Physics.Raycast(transform.position+CastOffset,impactVector.normalized, out hit, groundDistance, groundMask))
        {
            return;
        }
             
               if (isRigid)
               {
                GetComponent<Rigidbody>().AddForce(impactVector,ForceMode.Impulse);
               }else
               {
               
            
              var tween=    transform.DOPunchPosition(
    new Vector3(Power/7, 0, Power/7), // パンチの方向と強さ
    0.2f                    // 演出時間
).OnComplete(()=>{transform.DOLocalMove(impactVector, knockbackSpeed).SetRelative(true).SetEase(Curve);});
               
                 
                  tween.OnUpdate(()=>{
                     if (Physics.Raycast(transform.position+CastOffset,impactVector.normalized, out hit, groundDistance, groundMask))
        {
            tween.Kill();
            if (HitEffect!=null)
            {
                  HitEffect.Execute(hit.point);
            }
          
            if (ReflectionForce!=0)
            {
                AddForce(-1*impactVector*ReflectionForce,Power);
            }
        }


                  });
               }
            
           }
}
