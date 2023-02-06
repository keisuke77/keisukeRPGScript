using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

public class InsertAnimation : MonoBehaviour 
{[Header("need animator")]
	private PlayableGraph graph;
	private AnimationPlayableOutput output;
	private Playable playable;
	[HideInInspector]
    public Animator animator;
	private AnimationMixerPlayable mixer;

	[SerializeField] AnimationCurve curve = null;

	void Awake()
	{ animator = GetComponent<Animator> ();
		
		graph = PlayableGraph.Create ();
		output = AnimationPlayableOutput.Create (graph, "test", GetComponent<Animator> ());
		mixer = AnimationMixerPlayable.Create (graph, 2, true);
		output.SetSourcePlayable (mixer);
		output.SetWeight (0);
	}

	void OnDestroy()
	{
		graph.Destroy ();
	}

	private float GetRate(float endTime, float time, bool isReverce = false)
	{
		float value = isReverce ? 
			Mathf.Clamp01 ((endTime - Time.timeSinceLevelLoad) / time) :
			Mathf.Clamp01 (1-(endTime - Time.timeSinceLevelLoad) / time);
		return value;
	}


	void Cleanup()
	{
		// アニメーションのクリーンナップ
		if (playable.IsValid () ) {
			graph.Disconnect (mixer, 0);
			playable.Destroy ();
		}
	}
public void Plays(AnimationClip animClip,float time=0.2f){

	StartCoroutine(Play(time,animClip));
}
	public IEnumerator Play(float time, AnimationClip animClip)
	{
		var oldPlayable = playable;
		playable = AnimationClipPlayable.Create (graph, animClip);

		if (graph.IsPlaying() == false) {

			yield return Fadein (playable, time);

		} else {
			
			yield return Transition (playable,oldPlayable, time);
		}

		// PlayableからAnimatorへ
		animator.playableGraph.Stop();
		yield return new WaitForSeconds (animClip.length - time * 2);
		animator.playableGraph.Play();

		yield return Fadeout (time);

		Cleanup ();

		graph.Stop ();
	}


	IEnumerator Fadein(Playable newPlayable, float time)
	{
		float endTIme =  Time.timeSinceLevelLoad + time;

		// アニメーションのセットアップ
		mixer.ConnectInput (0, newPlayable, 0, 1);

		graph.Play ();

		yield return new WaitWhile (() => {
			float diff = GetRate (endTIme, time);
			output.SetWeight ( curve.Evaluate (diff));
			return (endTIme > Time.timeSinceLevelLoad);
		});

		output.SetWeight (1);
	}


	IEnumerator Fadeout( float time)
	{
		float endTime =  Time.timeSinceLevelLoad + time;

		// PlayableからAnimatorへ
		yield return new WaitWhile (() => {
			float diff = GetRate (endTime, time, true);
			output.SetWeight ( curve.Evaluate (diff));
			return (endTime > Time.timeSinceLevelLoad);
		});
		output.SetWeight (0);
	}

	IEnumerator Transition(Playable newPlayable, Playable oldPlayable, float time)
	{
		float endTime =  Time.timeSinceLevelLoad + time;

		graph.Disconnect (mixer, 0);
		graph.Disconnect (mixer, 1);

		mixer.ConnectInput (0, newPlayable, 0, 0);
		mixer.ConnectInput (1, oldPlayable, 0, 1);

		var currentOutputWeight = output.GetWeight ();

		// AnimatorからPlayableへ遷移
		yield return new WaitWhile (() => {
			float diff = GetRate (endTime, time);
			mixer.SetInputWeight (0, diff);
			mixer.SetInputWeight (1, 1 - diff);

			output.SetWeight( diff * (1 - currentOutputWeight) + currentOutputWeight);

			return (endTime > Time.timeSinceLevelLoad);
		});
		mixer.SetInputWeight (0, 1);
		output.SetWeight (1);

		graph.Disconnect (mixer, 1);
		if (oldPlayable.IsValid ()) {
			oldPlayable.Destroy ();
		}
	}
}