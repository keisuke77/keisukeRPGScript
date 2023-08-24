using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class itemGetparformance : MonoBehaviour
{
    public GameObject camerarotation;
    public float duration=2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void startrotate(){
       
camerarotation.transform.DOLocalRotate(
                new Vector3(0f,180f,0f),
                duration
            );

camerarotation.transform.DOLocalMove(
                new Vector3(0f,0f,-3f),
                duration
            );



    } 
    
    
    public void endrotate(){
camerarotation.transform.DOLocalRotate(
                new Vector3(0f,0f,0f),
                duration
            );
camerarotation.transform.DOLocalMove(
                new Vector3(0f,0f,0f),
                duration
            );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
