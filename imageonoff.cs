using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class imageonoff : MonoBehaviour {
   public Image[] ImageObj;
    bool Flash = true;
    public float time;
    void Start () {
         StartCoroutine ("Flashing");
    }
    IEnumerator Flashing(){
        while (Flash) {
            yield return new WaitForSeconds (time);
            foreach (Image laserObj in ImageObj) {
                laserObj.enabled = !laserObj.enabled;
            }
        }
    }
}