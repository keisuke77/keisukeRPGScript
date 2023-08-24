using UnityEngine;using UnityEngine.UI;


[CreateAssetMenu(fileName = "RPG/ChatCharactor", menuName = "New Unity Project (1)/ChatCharactor", order = 0)]
public class ChatCharactor : ScriptableObject {
    public string name;
    public Sprite icon;
    public float WalkSpeed;
    public float RunSpeed;
    public float JumpPower;
    public float IdleSpeed;
    public int MaxHP;
    public int CurrentHP;
    public int Power;
    public float knockBack;
    public int Defence;
    public string Explain;
}