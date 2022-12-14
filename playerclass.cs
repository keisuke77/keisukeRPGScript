using UnityEngine;

public class playerclass : MonoBehaviour
{
    public AutoRotateCamera AutoRotateCamera;
public keiinput keiinput;
public itemcurrent itemcurrent;
public itemmanage itemmanage;
public datamanage datamanage;
public meleecamera meleecamera;
public Effekseer.EffekseerEmitter playeremitter;
public interactionlist interactionlist;
public itemuseplace itemuseplace;
public message message;
   public Collider RangeDamageCollider; 
	void Awake () 
	{playeremitter=GetComponent<Effekseer.EffekseerEmitter>();
	datamanage=GetComponent<datamanage>();
		int maxDisplayCount = 2;
		for (int i=0; i<maxDisplayCount && i<Display.displays.Length; i++) {
			Display.displays[i].Activate();
		}
	}


}