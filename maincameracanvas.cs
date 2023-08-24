using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class maincameracanvas : MonoBehaviour
{Canvas m_Canvas;
    // Start is called before the first frame update
    void Start()
    {m_Canvas=GetComponent<Canvas>();
         m_Canvas.renderMode = RenderMode.ScreenSpaceCamera;
               m_Canvas.worldCamera=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
