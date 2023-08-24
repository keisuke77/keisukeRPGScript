using UnityEngine;

public class cubebuild : MonoBehaviour
{
    public GameObject cube;
    [SerializeField]
    private LayerMask obstacleLayer;
GameObject nearCube;
public int builddistance=5;
GameObject hitcollider;
public Color ChangeColor;
    void Update()
    {   nearCube=gameObject.NearserchTag("cube");
        
        Vector3 mypos=transform.position;
        RaycastHit hit;

        if (Physics.Linecast(mypos, nearCube.transform.position, out hit, obstacleLayer)) {
           
          if ((mypos-nearCube.transform.position).sqrMagnitude>builddistance){
               
                 if (Physics.Raycast(mypos,transform.forward,out hit,10.0f))
                    {
            if(hit.collider.gameObject.name=="placeable"&&hit.collider.isTrigger){
hitcollider=hit.collider.gameObject;
hitcollider.GetComponent<Renderer>().material.color=ChangeColor;


            }
                     }else
                     {
                        
                     }
            
               }
           
        }
    }
}