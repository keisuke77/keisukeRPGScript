using UnityEngine;

[CreateAssetMenu(fileName = "RPGCharactor", menuName = "RPG/Charactor")]
public class RPGCharactor : ScriptableObject
{
    public RpgPlayerMotion[] RpgPlayerMotions;
    public int HP;
   
    public string nickname;
    public GameObject CharactorObj;
}