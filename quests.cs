using UnityEngine;

[CreateAssetMenu(fileName = "quests", menuName = "createquests", order = 0)]
public class quests : ScriptableObject {
    public string title;
    public quest[] questss;
}