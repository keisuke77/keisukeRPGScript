using UnityEngine;using System.Collections;
using System.Collections.Generic;
 [System.Serializable]
public enum Emotion
{
    Normal,Anger,Sad,Surprised
}
 [System.Serializable]
    public class phase
    {
    public string message;
    public ChatCharactor ChatCharactor;
   public List<SelectionPhase> SelectionPhases;
   public Emotion Emotion;
    }
    
     [System.Serializable]
     public class SelectionPhase
    {
    public List<phase> phases;
    public string text;
    
    }
[CreateAssetMenu(fileName = "RPG/ChatData", menuName = "New Unity Project (1)/ChatData", order = 0)]
public class ChatData : ScriptableObject {

public List<phase> phases;

}