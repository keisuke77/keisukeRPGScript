using UnityEngine;

public class footprintcreate : MonoBehaviour
{
    public GameObject footPrintPrefab;
    

 public void FootStep()
    {
        Instantiate(footPrintPrefab, transform.position, Quaternion.Euler(90, transform.localEulerAngles.y, 0));
    }
    public void FootStepRight()
    {
        Instantiate(footPrintPrefab, transform.position + transform.right * 0.15f, Quaternion.Euler(90, transform.localEulerAngles.y, 0));
    }
    
    public void FootStepLeft()
    {
        Instantiate(footPrintPrefab, transform.position + transform.right * -0.15f, Quaternion.Euler(90, transform.localEulerAngles.y, 0));
    }
}