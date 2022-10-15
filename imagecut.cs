using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imagecut : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image=GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (image.sprite==null)
        {
            image.setA(0);
        }else{
            image.setA(255);}
    }
}
