using UnityEngine;using UnityEngine.UI;
namespace osero
{
    
public class startmenu : MonoBehaviour {
    
   public enum GameMode
    {
        cpu,human,view
    }
    public Button startbutton;
    public Button continuebutton;
    public oserodata oserodata;
    public GameMode GameModes;
    public GameObject GameSystem;
    public nowturn myturn;
    public bool AISupport;
    void Play(){
        switch (GameModes)
        {
            case GameMode.human:
               Instantiate(GameSystem,Vector3.zero,Quaternion.identity);
                break; 
                case GameMode.cpu:

                var game=Instantiate(GameSystem,Vector3.zero,Quaternion.identity);
                var AI=game.AddComponent(typeof(oseroAI))as oseroAI;
                AI.AIAttack=true;
                break;
            default:
                break;
        }
        
    }

}
}