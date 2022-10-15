using UnityEngine;

public class maikura : MonoBehaviour
{
    public float sizeX = 50f;
    public float sizeY = 10f;
    public float sizeZ = 50f;
    public float sizeW = 17f;
public GameObject cube;

public void build(){

if (cube!=null){
 
                 DestroyImmediateChildObject(cube.transform);
                DestroyImmediateChildObject(gameObject.transform);
                 
        } 

        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                 cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.SetParent(transform);
                float noise = Mathf.PerlinNoise(x/ sizeW, z/ sizeW);
                float y = Mathf.Round(sizeY * noise);
                cube.transform.localPosition = new Vector3(x, y, z);
            }
        }
        transform.localPosition = new Vector3(-sizeX / 2, 0, -sizeZ / 2);

}

 public void DestroyImmediateChildObject( Transform parent_trans )
{
    for( int i = parent_trans.childCount - 1; i >= 0; --i ){
        GameObject.DestroyImmediate( parent_trans.GetChild( i ).gameObject );
    }
}

 void Awake()
    { 
        
        build();
          }
}