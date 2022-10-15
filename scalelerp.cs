using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scalelerp : MonoBehaviour
{
    public CanvasScaler canvasScaler;
    public RectTransform transforms;
    public float from;
    public float to;
    public float speed=3f;
    public GameObject cele;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      canvasScaler.scaleFactor=Mathf.Lerp(from, to,Time.time/speed);
      if (from==to)
      {
          Instantiate(cele,transforms.position,Quaternion.identity);
      }
    }
}
