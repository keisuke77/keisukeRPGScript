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

Player.pclass().playerMovePram.stop=true;
Player.pclass().AutoRotateCamera.enabled=false;

      
      }

void Play()
{Player.pclass().AutoRotateCamera.enabled=true;
Player.pclass().playerMovePram.stop=false;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
