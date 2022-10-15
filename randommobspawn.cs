using UnityEngine;

public class randommobspawn : MonoBehaviour {
    public int num;
    public GameObject obj;
    public int distance;
   public LayerMask targetLayer;
  public RaycastHit hitInfo;
int i;
    
	  void Start()
    {     while (i<num)
    {
        i++;
        if (Physics.SphereCast(transform.position+keikei.randomvector(distance), 3, Vector3.down, out hitInfo, Mathf.Infinity, targetLayer))
{
 Instantiate(obj,hitInfo.point,Quaternion.identity);
}
    }
        
    }
}