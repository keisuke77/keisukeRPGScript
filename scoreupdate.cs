using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreupdate : MonoBehaviour
{
    public GameObject kamifubuki;
    public GameObject higtext;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("recordupdate", 0)==1)
        {
            PlayerPrefs.SetInt("recordupdate", 0);
       kamifubuki.SetActive(true);  higtext.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
