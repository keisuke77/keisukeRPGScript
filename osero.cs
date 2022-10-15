using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osero : MonoBehaviour
{
    
    
    
    [System.Serializable]
    public class koma
{

public koma[] komass;

    public koma(koma[] komaa){

      komass=  komaa;
    }
    public GameObject obj;

    public Renderer render;

   [System.Serializable]
 public enum color
{
   black,white,no
} 

public color colors;


public void Setcolor(){

render.material.color=Getcolor();
    
}
public Color Getcolor()
  {

Color c=Color.white;
          c.a=0;

  switch (colors)
  {
      case color.black:
      return Color.black;
          break;case color.white:
          
            return Color.white;case color.no:
          
            return c;
          break;


   
  }
  return c;
  }
}
public GameObject komaobj;
    public koma[,] komas=new koma[8,8];
     public koma[] komasq;
    

    // Start is called before the first frame update
    void Start()
    {
        komas=new koma[8,8];
        for (var i = 0; i < 8; i++)
        {

            for (var y = 0; y < 8; y++)
            {
              komas[i,y].obj=  Instantiate(komaobj,new Vector3(i,0,y),Quaternion.identity);
komas[i,y].render=komas[i,y].obj.GetComponent<Renderer>();
              komachange(i,y,0);
            }


            
        }
        
        komachange(3,4,1);
     komachange(4,3,1);
        komachange(3,3,2);
     komachange(4,4,2);
    }


public void komachange(int x,int y,int color){


    switch (color)
    {
        case 0:
komas[x,y].colors=koma.color.no;
            break;
            case 1:
komas[x,y].colors=koma.color.white;
            break;case 2:
komas[x,y].colors=koma.color.black;
            break;
        default:
            break;
    }
    
komas[x,y].Setcolor();

}


    // Update is called once per frame
    void Update()
    {
       
    }
}
