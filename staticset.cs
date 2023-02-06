using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemSystem;
public class staticset : MonoBehaviour
{
  
  
   public Itemkind[] allitems;
   public GameObject camera;
   public GameObject inventory;
   public iteminventory playeriteminventory;
   public GameObject explosion;
   public GameObject starparticle;
   public GameObject vanisheffect;
   public Button itempickupbutton;
   public Button communicationbutton;
   public Effekseer.EffekseerEffectAsset[] effects;
   public GameObject[] particles;
  public data playerdata;
    public Collider spherecheck;
    public Itemkind noitem;
    public itemuse[] inventorymember;
    public GameObject treasure;
    public GameObject[] messagetext;
    public SimpleMeshExploder SimpleMeshExploder;
public Effekseer.EffekseerEffectAsset chargeeffect;
    // Start is called before the first frame update
    void Awake()
    { keikei.communicationbutton=communicationbutton;
      keikei.SimpleMeshExploder=SimpleMeshExploder;
      keikei.chargeeffect=chargeeffect;
      keikei.vanisheffect=vanisheffect;
      keikei.allitems=allitems;
      keikei.treasure=treasure;
       keikei.particles=particles;
      keikei.spherecheck=spherecheck;
      keikei.inventory=inventory;
      keikei.playeriteminventory=playeriteminventory;
      keikei.explosion=explosion;
        keikei.camera=camera;
      
         keikei.itempickupbutton=itempickupbutton;
        keikei.starparticle=starparticle;
        keikei.effects=effects;
        keikei.playerdata=playerdata;
    }
void Start()
{
}
}
