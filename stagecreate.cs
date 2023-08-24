using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagecreate : MonoBehaviour
{

    public GameObject stage;
   public GameObject rakkastage;
  public GameObject goalobj;
    Vector3 pos;
    [SerializeField, Range(0, 10000)]
     float length;

    public GameObject enemy;
    public GameObject chest;
      [SerializeField, Range(0, 100)]
    int often; 
    [SerializeField, Range(0, 100)]
    int rakkaoften;
 public List<GameObject> trash ;
    
    // Start is called before the first frame update
    void Start()
    {chest=(GameObject)Resources.Load("keichest");
    stagecreatess();
    }
public void recreate(){

    pos=Vector3.zero;
foreach (var item in trash)
{
  Destroy(item); 
}
stagecreatess();
}

public void stagecreatess(){
    
        
    
         for (int i = 0; i < length; i++)
        {
            pos+=new Vector3(10*(int)Random.Range(1,-2),0,10*(int)Random.Range(1,-2));
          if (keikei.kakuritu(rakkaoften))
         { trash.Add( Instantiate(rakkastage,pos,Quaternion.identity));
          
         }else
         {
              trash.Add( Instantiate(stage,pos,Quaternion.identity));
          
         }
           if (keikei.kakuritu(often))
         {var k=  Instantiate(chest,pos,Random.rotationUniform);
      　Transform sampleTransform = k.transform;

 　　　 　　
      　Vector3 worldAngle = sampleTransform.eulerAngles;
 　　　 　　　worldAngle.x = 0.0f;
 　　　 　
 　　　 　　　worldAngle.z = 0.0f; 
 　　　 　　　sampleTransform.eulerAngles = worldAngle;
         trash.Add(k);
        }
        if (i==length-1)
        {
            trash.Add( Instantiate(goalobj,pos+Vector3.up,Quaternion.identity));
          
        }
          
        }
}
    // Update is called once per frame
    void Update()
    {
       

        
    }
}
