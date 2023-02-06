using UnityEngine;

public class CharactorClass : MonoBehaviour
{
    public Animator anim;
    public U10PS_DissolveOverTime U10PS_DissolveOverTime;
    public hpcore hpcore;
    public Effekseer.EffekseerEmitter emitter;
    public charactorchange charactorchange;

 	void Awake () 
	{
		emitter=gameObject.AddComponentIfnull<Effekseer.EffekseerEmitter>();
	
	}
public void dissolvekaihi(){
    if (U10PS_DissolveOverTime!=null)
    {
        
U10PS_DissolveOverTime.dissolve.meshRenderers=U10PS_DissolveOverTime.meshRenderers;
U10PS_DissolveOverTime.dissolve.dissolveOutIn(1f,()=>hpcore.muteki(1));

    }}


    public void CharacterChange(){

System.Action ac=delegate(){
	if (hpcore!=null)
	{
hpcore.muteki(2);
	}if (charactorchange!=null)
	{
charactorchange.charactoradd();
	}
};
        if (U10PS_DissolveOverTime!=null)
        {
            
U10PS_DissolveOverTime.dissolve.meshRenderers=U10PS_DissolveOverTime.meshRenderers;
U10PS_DissolveOverTime.dissolve.dissolveOutIn(2,ac);

        }else
        {
            ac();
        }
    }
}