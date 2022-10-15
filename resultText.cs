using UnityEngine;
using UnityEngine.UI;

public class resultText : MonoBehaviour
{
    public gamescore gamescore;

 public Text text;
    private void Start()
    {text.text="あなたのスコアは"+gamescore.score().ToString()+"/nです！！";
        
    }
}