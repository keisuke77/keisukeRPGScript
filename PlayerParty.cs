using UnityEngine;

[CreateAssetMenu(menuName = "RPG/PlayerParty", fileName = "PlayerParty")]
public class PlayerParty : ScriptableObject
{
    public RPGCharactor[] members;
    public string name;
    
}