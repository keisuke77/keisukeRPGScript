using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onclickkey : MonoBehaviour
{
    public KeyCode key;
    Button but;

    // Start is called before the first frame update
    void Start()
    {
        but = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (key.keydown())
        {
            but.onClick.Invoke();
        }
    }
}
