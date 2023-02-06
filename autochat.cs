using UnityEngine;using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
public class autochat : MonoBehaviour
{


    public List<string> greating;
    public List<string> text;
    public List<string> text2;
    public Text texts;
    public List<string> text3;
    
    public List<string> endtext;
    public autochat instance;
    public bool auto;
    public GameObject aite;
void Start()
{if (auto)
{
     texts.text=Getchat();
    aite.pclass().message.SetMessagePanel(Getchat(),false);
    
}instance=this;
   
}    

public void execute(){

    texts.text=Getchat();
   
}
    public string Getchat(){
return (greating.GetAtRandom()+
text.GetAtRandom()+
text2.GetAtRandom()+
text3.GetAtRandom()+
endtext.GetAtRandom());


    }


}