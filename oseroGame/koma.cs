
using UnityEngine;
using DG.Tweening;
namespace osero
{
    
    public enum komatype
     {
        none,white,black
     }
     [System.Serializable]
    public class koma  {
        public komatype komatype;
        public GameObject komaobj;
        public Vector2 Adress;
        public Renderer render;
        public koma(GameObject komaModel,Vector2 Adresss){
            komaobj= keikei.Instantiate(komaModel,new Vector3(Adresss.x,0,Adresss.y) ,Quaternion.identity);
            render=komaobj.GetComponent<Renderer>();
            Adress=Adresss;
        }
     public Color KomaTypeGetColor(){
        switch (komatype)
        {
            case komatype.black: return Color.black;
                break;
                case komatype.white :return Color.white;
                break;
                case komatype.none: return Color.green;
                break;
           
        }
        return (Color)default;
 
     }
     public void ReChange(){
        Change(komatype);
     }
         
        public void Change(komatype komatypes){
           
            komatype=komatypes;  
            
            render.material.color=KomaTypeGetColor();
            komaobj.transform.DORotate(new Vector3(180,0,0),0.6f);
           
        }
    }
}