using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laidcontoroll : MonoBehaviour
{
public List<GameObject> laidmonsters;
    public int laidcount =0;
    public Transform objspawnpoint;
    [SerializeField]
    Countdown Countdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void onelaidclear(){
laidcount++;
Countdown.OnClickButtonStart();

}

public void laidset(){

  var a= Instantiate(laidmonsters[laidcount],objspawnpoint.position+new Vector3(Random.Range(-5,5),0,Random.Range(-5,5)),Quaternion.identity);

a.AddComponent(typeof(clearflag));

switch (laidcount)
{
    case 0:
        break;  case 1:
        break; 
        case 2:
        break;
         case 3:
        break;
         case 4:
        break; case 5:
        break; case 6:
        break; case 7:
        break;
    default:
        break;
}



}


    // Update is called once per frame
    void Update()
    {
        
    }
}
