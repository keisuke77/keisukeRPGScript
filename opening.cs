using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opening : MonoBehaviour
{
public Button startbutton;
public GameObject Player;
    // Start is called before the first frame update
   public void Start()
    {  startbutton.onClick.AddListener(Play);

<<<<<<< HEAD
Player.pclass().playerMovePram.stop=true;
=======
Player.GetComponent<UnityChanControlScriptWithRgidBody>().pause();
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
Player.pclass().AutoRotateCamera.enabled=false;

      
      }

void Play()
{Player.pclass().AutoRotateCamera.enabled=true;
<<<<<<< HEAD
Player.pclass().playerMovePram.stop=false;
=======
Player.GetComponent<UnityChanControlScriptWithRgidBody>().start();
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
