using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialfade : MonoBehaviour
{
    public Material material;
    public bool fadestart=false;
    private List<GameObject> obj;
    private Color originalcolor;

    // Start is called before the first frame update
    void Start()
<<<<<<< HEAD
    {if (material!=null)
    {
        
    }
=======
    {
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
        originalcolor= material.color;
    }
     private void OnApplicationQuit()
    {
         material.color=originalcolor;
    }
public void objecttransformallfade(GameObject a){


 
<<<<<<< HEAD
  obj=a.GetAllChildrenAndSelf(); 
=======
  obj=getallchildren.GetAll(a); 
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
while(a.GetComponent<Renderer>().material.color.a>1){

 foreach (GameObject child in obj)
{
    if (child.GetComponent<Renderer>())
    {
        var c = child.GetComponent<Renderer>().material.color;
c-=new Color32(0,0,0,1);
if (c.a==0)
{
    Destroy(child);
}

    }
}
}

}



    // Updat e is called once per frame
    void Update()   
    {
      

        if (fadestart)
        {
if (material==null)
{
      material=GetComponent<Renderer>().material;
          
       
}
             
            material.color-=new Color32(0,0,0,1);
           if ( material.color.a==0)
           {
               Destroy(gameObject);
                        }
        }
    }
}
