using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectness : MonoBehaviour
{
  public bool shake;
  public GameObject effect;
  GameObject a;
    // Start is called before the first frame update
    void Start()
    {
       
          a= Instantiate(effect,keikei.player.transform.position, Quaternion.identity);
          a.transform.SetParent(keikei.player.transform);
 if (shake)
 {
     keikei.shake();
 
 }
     }
private void OnDestroy()
{
    Destroy(a);
}
    // Update is called once per frame
    void Update()
    {
        
        }
}
