
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ClickPointInstantiate : MonoBehaviour
{
    public GameObject cube;
 
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
      
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(cube, hit.point, Quaternion.identity);
            }
        }
	}
 
}