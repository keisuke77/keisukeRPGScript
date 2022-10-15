using System.Linq;
using UnityEngine;
 
public class click : MonoBehaviour
{


    public GameObject obj;
    private Camera mainCamera;
    private Vector3 currentPosition = Vector3.zero;
 
    void Start()
    {
        mainCamera = Camera.main;
    }
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
       var raycastHitList = Physics.RaycastAll(ray).ToList();
            Debug.Log(raycastHitList);

            if (raycastHitList.Any()) {
                var distance = Vector3.Distance(mainCamera.transform.position, raycastHitList.Last().point);
                var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
 
                currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
               
             Instantiate(obj,currentPosition+new Vector3(0,1,0), Quaternion.identity);
            }
        }
    }
 
    void OnDrawGizmos()
    {
        if (currentPosition != Vector3.zero) {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(currentPosition, 0.5f);
        }
    }
}