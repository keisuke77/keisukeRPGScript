using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class particleend : MonoBehaviour {
public Animator anim;
public string boolname;
public bool findeath;



	void Start () {
		var main = GetComponent<ParticleSystem>().main;
	main.stopAction = ParticleSystemStopAction.Callback;

   anim= keikei.playeranim;



		// StopActionはCallbackに設定している必要がある
		}

	void OnParticleSystemStopped () {
		Debug.Log("System has stopped!");
        
        anim.SetBool(boolname,true);
        if (findeath)
        {
            Destroy(gameObject);
        }

	}

}
	

