using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< HEAD
using ItemSystem;

=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
public class itempickup : MonoBehaviour
{
    public Itemkind Itemkind;
    
Button button;
    // Start is called before the first frame update
    void Start()
    {   button=keikei.itempickupbutton;
    }
void OnCollisionEnter(Collision collisionInfo)
{if(collisionInfo.gameObject.transform.root.gameObject.tag=="Player"){
button.gameObject.SetActive(true);
     button.GetComponent<Button>().onClick.AddListener(() => {
        Itemkind.add(collisionInfo.gameObject.root());
       keikei.starvanish(gameObject);
    
button.gameObject.SetActive(false);
return;
     });
  
}
    
}
void OnCollisionExit(Collision collisionInfo)
{if(collisionInfo.gameObject.transform.root.gameObject.tag=="Player"){
    
    button.GetComponent<Button>().onClick.RemoveAllListeners();
button.gameObject.SetActive(false);
    
}
    
}

public void ItemGet(Itemkind Itemkinds){

    
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
