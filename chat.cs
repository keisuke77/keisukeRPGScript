using UnityEngine;
using UnityEngine.UI;

public class chat : MonoBehaviour
{public InputField InputField;

public Vector3 pos=new Vector3(0,2,0);


public void Play(string text){

text.CreateMesImage(gameObject,pos);
}


  
}