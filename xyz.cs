using UnityEngine;

<<<<<<< HEAD
public enum directionXYZ
{front,horizon,height
	 
}
=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
[CreateAssetMenu(fileName = "xyz", menuName = "")]
public class xyz : ScriptableObject
{
public directionXYZ x;
public directionXYZ y;
public directionXYZ z;

<<<<<<< HEAD
   
=======
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
public Vector3 Gethight(){
return Gethight(1);
}

public Vector3 Gethight(float a){
   return new Vector3(x==directionXYZ.height?a:0,y==directionXYZ.height?a:0 ,z==directionXYZ.height?a:0);

}
public Vector3 Gethight(Vector3 a){
   return new Vector3(x==directionXYZ.height?a.x:0,y==directionXYZ.height?a.y:0 ,z==directionXYZ.height?a.z:0);

}
   }