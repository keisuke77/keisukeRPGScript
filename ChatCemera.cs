using UnityEngine;

public class ChatCemera : MonoBehaviour {
    
public ChatCameras ChatCameras;
private void Start() {
    keikei.delaycall(()=>  ChatCameras.Execute(0),1);
   
}
     
}