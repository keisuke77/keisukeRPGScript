using UnityEngine;

[CreateAssetMenu(fileName = "charactors", menuName = "charactorscreate")]
public class charactors : ScriptableObject
{
    
[System.Serializable]
public class character{
public string name;
public GameObject bone;
public GameObject mesh;
public Avatar avatar;
public GameObject righthand;
public GameObject lefthand;
public GameObject rightfoot;
public GameObject leftfoot;
public transformdata weaponstransform;

public void Set(charactorchange charactorchange,character[] characters){

foreach (var characterss in characters)
	{
      characterss.bone.SetActive(false);
	characterss.mesh.SetActive(false);
      	}
			
	bone.SetActive(true);
	mesh.SetActive(true);
    charactorchange.anim.avatar=avatar;
    charactorchange.weapons.transform.parent=righthand.transform;
    keikei.transformenter(charactorchange.weapons.transform,weaponstransform);
}

   }
    
}