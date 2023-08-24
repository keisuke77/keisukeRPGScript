using UnityEngine;

public class raycast : MonoBehaviour
{
   public GameObject hiteffect;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

  //左クリックを受け付ける
        if (Input.GetMouseButtonDown(0))
      {  if (Physics.Raycast(ray, out hit,100)){
            print("Hit something!");
            Instantiate(hiteffect,hit.point,Quaternion.identity);
      ray = new Ray(new Vector3(0,0,0),new Vector3(0,0,0));
        }}
      
    }
}