using UnityEngine;

[CreateAssetMenu(fileName = "inputsetting", menuName = "createinput")]
public class inputsetting : ScriptableObject
{
    public string[] horizonaxis;
    public string[] verticalaxis;
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

public enum controll
{
    none,
    attackkey,
    jumpkey,
    guardkey,
    dashkey,
    interactionkey, 
    attackkeyup,
    jumpkeyup,
    guardkeyup,
    dashkeyup,
    interactionkeyup,
    throwkey,
    addkey,
    downkey,hissatukey,
    decidekey,horizonaxis,rotateverticalaxis,verticalaxis,rotatehorizonaxis
}
