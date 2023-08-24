using UnityEngine;

[CreateAssetMenu(fileName = "gamescore", menuName = "")]
public class gamescore : ScriptableObject
{
    public int givedamage;
    public float cleartime;
    public int hp;

    public float score()
    {
        return hp / 10 + givedamage / 10 + 1000 / cleartime;
    }

    public void reset()
    {
        givedamage = 0;
        cleartime = 0;
        hp = 0;
    }
}
