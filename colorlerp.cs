using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "colors", menuName = "colorlerp")]
public class colorlerp : ScriptableObject
{
   [SerializeField]
private Gradient gradient;

public Color GetColor(float value){

return gradient.Evaluate(value);


}



 
  }