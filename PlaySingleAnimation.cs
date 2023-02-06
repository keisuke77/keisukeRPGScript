using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;
using UnityEngine.Timeline;

[RequireComponent (typeof(Animator))]
public class PlaySingleAnimation : MonoBehaviour
{
PlayableGraph graph;
[HideInInspector]
public Animator animator; 
void OnEnable ()
{
animator =  GetComponent<Animator> ();
if (animator.runtimeAnimatorController == null) {
graph = GetComponent<Animator> ().playableGraph;
} else {
graph = PlayableGraph.Create ();
var output = AnimationPlayableOutput.Create (graph, name, animator);
}
}

void OnDisable()
{
graph.Destroy ();
}

public void Play (AnimationClip newAnimation)
{
StartCoroutine(PlayAnimation(newAnimation));
}

public IEnumerator PlayAnimation (AnimationClip newAnimation)
{
var playable = AnimationClipPlayable.Create (graph, newAnimation);
var output = graph.GetOutput (0);
output.SetSourcePlayable (playable);

graph.Play ();
yield return new WaitForSeconds (newAnimation.length);

graph.DestroyPlayable (playable);
graph.Stop ();
}
}