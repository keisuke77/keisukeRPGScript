using UnityEngine;

[CreateAssetMenu(fileName = "AttackPram", menuName = "My project (1)/AttackPram", order = 0)]
public class AttackPram : ScriptableObject {
     public int damagevalue;
    public int forcepower;
    public bool sequenceHit;
    public bool charge;
    public bodypart bodypart;
    public float ColliderSize=0.1f;
    public string name;
    
}