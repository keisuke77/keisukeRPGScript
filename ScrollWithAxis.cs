using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollWithAxis : MonoBehaviour
{
    public Scrollbar scrollbar;
    public controll axis;
      // Set this in the Inspector
    public float sensitivity = 0.1f; // How fast the scrollbar moves with the axis

    // Update is called once per frame
    void Update()
    {
        // Get vertical axis ("Vertical" by default, can be customized in the Input settings)
        float vertical = keiinput.Instance.GetAxis(axis);

        // Add the axis value to the scrollbar's value, clamped between 0 and 1
        scrollbar.value = Mathf.Clamp(scrollbar.value - vertical * sensitivity, 0, 1);
    }
}
