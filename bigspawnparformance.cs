using UnityEngine;
using UnityEngine.UI;
public class bigspawnparformance : MonoBehaviour
{

    [SerializeField]
GameObject bigobj;
 [SerializeField]
Transform bigobjspawnpos;
 [SerializeField]
GameObject bigobjparticle;
[SerializeField]
public float cameradistance;
[SerializeField]
public Text text;
[SerializeField]
bool onstart;

    void Start()
    {if (!onstart)
    {
        return;
    }
        if (cameradistance==0)
    {
   
        spawn(bigobj,bigobjspawnpos,bigobjparticle);
    
    }else if(text==null)
    {
        spawn(bigobj,bigobjspawnpos,bigobjparticle,cameradistance);
    
    }else{
spawn(bigobj,bigobjspawnpos,bigobjparticle,cameradistance,text);
    
    }
    }
    
    public void spawn(GameObject bigobj,Transform bigobjspawnpos,GameObject bigobjparticle){

        keikei.bigspawn(bigobj,bigobjspawnpos,bigobjparticle);

    } public void spawn(GameObject bigobj,Transform bigobjspawnpos,GameObject bigobjparticle,float cameradistance){

        keikei.bigspawn(bigobj,bigobjspawnpos,bigobjparticle,cameradistance);

    }public void spawn(GameObject bigobj,Transform bigobjspawnpos,GameObject bigobjparticle,float cameradistance,Text text){

        keikei.bigspawn(bigobj,bigobjspawnpos,bigobjparticle,cameradistance,text);

    }
    
}