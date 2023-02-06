using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "data", menuName = "warpdata")]
public class warpdata : ScriptableObject
{
    public GameObject warpeffect;
   public Vector3 pos;
   public Quaternion rotation;
   public string scenename;

    public void warps(GameObject other){
keikei.Allplayerstop();
keikei.playerdata.pos=pos;
keikei.playerdata.rotation=rotation;
datamanage.pos=true;
    other.pclass().gametransition(scenename);

    }
 
  }
