using UnityEngine;

public class animatorSET:MonoBehaviour
{
    public bool setbool;
    public string boolname;
    public string triggername;


    public void SetBool(GameObject obj){

if (obj?.GetComponent<Animator>()!=null)
{
    obj?.GetComponent<Animator>().SetBool(boolname,setbool);
}
    }
    public void SetTrigger(GameObject obj){

if (obj?.GetComponent<Animator>()!=null)
{
    obj?.GetComponent<Animator>().SetTrigger(triggername);
}
    }
    
}