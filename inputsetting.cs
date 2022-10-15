using UnityEngine;

[CreateAssetMenu(fileName = "inputsetting", menuName = "createinput")]
public class inputsetting : ScriptableObject
{
   
    
public string[] horizonaxis;
public string[] verticalaxiss;
public string[] rotatehorizonaxis;
public string[] rotateverticalaxis;
public KeyCode[] attackkey;
public KeyCode[] jumpkey;
public KeyCode[] guardkey;
public KeyCode[] dashkey;
public KeyCode[] hissatukey;
public KeyCode[] interactionkey;
public KeyCode[] throwkey;
public KeyCode[] addkey;
public KeyCode[] downkey;
public KeyCode[] decidekey;

}

public enum controll{
 attackkey,
 jumpkey,
 guardkey,
 dashkey,
 interactionkey, throwkey,
 addkey,
 downkey,
 decidekey
}


