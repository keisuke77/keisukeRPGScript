using UnityEngine;

public class parentPaf : MonoBehaviour
{
    public float interval;
public int damagevalue;
void Start()
{
    InvokeRepeating("Play",0,interval);
}

public void Play(){
gameObject.root().GetComponent<hpcore>().damage(damagevalue,false,null,true);
}
}