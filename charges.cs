using UnityEngine;
[System.Serializable]
public class charges {
    
 float chargevalue;
 public Animator anim;
public bool charge;
public keiinput keiinput;
 /// <summary>
 /// 
 /// Start is called on the frame when a script is enabled just before
 /// any of the Update methods is called the first time.
 /// </summary>
 public charges(GameObject obj)
 { keiinput=obj.pclass().keiinput;

    anim=obj.root().GetComponent<Animator>();
 }

public void chargeup(string boolname){
 anim.SetBool(boolname,true);
     
if (charge)
{
     
anim.SetFloat("chargepower",chargevalue); 
     charge=false;
     chargeeffonce=false;    
 anim.gameObject.EffspawnPlayerStop();
anim.gameObject.GetComponent<UnityChanControlScriptWithRgidBody>().stop=false;
}
     

}
public void charging(string boolname){

chargevalue+=Time.deltaTime;
anim.SetFloat("charge",chargevalue);
anim.gameObject.playerstop();

if (chargevalue>1&&!chargeeffonce)
{

      anim.gameObject.EffspawnPlayer(keikei.chargeeffect);
chargeeffonce=true;
}
if (chargevalue>5)
{
     keikei.explosion.Instantiate(anim.gameObject.root().transform);
     chargevalue=1;
     chargeup(boolname);
}

}
bool chargeeffonce;
public void chargepower(string boolname){

if (keiinput.attackduring&&anim.GetBool("idle")&&!charge){
chargevalue=0;
  
     charge=true;
     
}
if (charge)
{
     charging(boolname);
}

if (keiinput.attackup)
{
 chargeup(boolname);   
}

}


}