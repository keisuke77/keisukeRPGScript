using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
using ItemSystem;
=======

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
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
<<<<<<< HEAD
  public Effekseer.EffekseerEffectAsset chargeeffect;
    // Start is called before the first frame update
    void Awake()
    { keikei.communicationbutton=communicationbutton;
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
      keikei.noitem=noitem;
=======
    public KeyCode nextmessagekey;
    public itemmanage itemmanage;
    public U10PS_DissolveOverTime playerdissolve;
    public Effekseer.EffekseerEmitter playeremitter;
    public SimpleMeshExploder SimpleMeshExploder;
public Effekseer.EffekseerEffectAsset chargeeffect;
    // Start is called before the first frame update
    void Awake()
    {  keikei.communicationbutton=communicationbutton;
    keikei.SimpleMeshExploder=SimpleMeshExploder;
      message.nextmessagekey=nextmessagekey;
      keikei.chargeeffect=chargeeffect;
      keikei.playerdissolve=playerdissolve;
      keikei.playeremitter=playeremitter;
      keikei.vanisheffect=vanisheffect;
      keikei.allitems=allitems;
      keikei.treasure=treasure;
    warning.messages=messagetext;
       itemmanage.inventorymember=inventorymember;
      keikei.particles=particles;
      keikei.spherecheck=spherecheck;
      keikei.noitem=noitem;
      keikei.inventory=inventory;
      keikei.playeriteminventory=playeriteminventory;
      keikei.myitemLists=playeriteminventory.myitemLists;
      keikei.explosion=explosion;
        keikei.camera=camera;
      
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
         keikei.itempickupbutton=itempickupbutton;
        keikei.starparticle=starparticle;
        keikei.effects=effects;
        keikei.playerdata=playerdata;
    }
<<<<<<< HEAD
void Start()
{
}
=======

>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
}
