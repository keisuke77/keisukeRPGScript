using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MaterialAnimation : MonoBehaviour {
    public Material[] mats;
    public AnimationClip clip;
    private void Start() {
        
        foreach (var item in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
        { 
          item.materials= item.materials.Concat(mats).ToArray();
          
        
          var anim=  item.gameObject.AddComponentIfnull<Animation>()as Animation;
anim.clip=clip;
anim.Play();
        }
    }
}