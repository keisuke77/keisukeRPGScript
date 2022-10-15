using UnityEngine;

[CreateAssetMenu(fileName = "EnemyParty", menuName = "RPG/EnemyParty")]
public class EnemyParty : ScriptableObject
{
     public RPGCharactor[] members;
    public string name;
}