using UnityEngine;
using DG.Tweening;

public class scalechangeplayer : MonoBehaviour
{
    public GameObject Canvasgroup;
    public AutoRotateCamera AutoRotateCamera;
    public UnityChanControlScriptWithRgidBody UnityChanControlScriptWithRgidBody;

    public void scalechange(float num){
gameObject.scalechange(num);
Canvasgroup.scalechange(1/num);
AutoRotateCamera.distance=
AutoRotateCamera.distance*num;
UnityChanControlScriptWithRgidBody.movespeed=num;
   }
}