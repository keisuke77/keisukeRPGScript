using UnityEngine;

[CreateAssetMenu(fileName = "instance", menuName = "")]
public class instanceobj : ScriptableObject
{public GameObject obj;
public float deadtime;
  public void Instantiates(Transform trans){
 var a  = obj.Instantiate(trans);
 if (deadtime>0)
 {
  
a.destroy(deadtime);
 }
  }
}