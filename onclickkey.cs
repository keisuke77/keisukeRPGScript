using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onclickkey : MonoBehaviour
{
    public KeyCode key;
<<<<<<< HEAD
    Button but;

    // Start is called before the first frame update
    void Start()
    {
        but = GetComponent<Button>();
=======
  Button but;
    // Start is called before the first frame update
    void Start()
    {
        but=GetComponent<Button>();
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
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
