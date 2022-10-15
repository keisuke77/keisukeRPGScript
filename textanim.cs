using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class textanim : MonoBehaviour
{
Text text;
string str;
    // Start is called before the first frame update
     void Awake()
    {
         text=GetComponent<Text>();
        str=text.text;
 
    }
void OnEnable()
{
    text.text="";
    text.DOText(str,3);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
