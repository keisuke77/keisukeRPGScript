using UnityEngine;
using System.Collections.Generic;

public class DontDestroyObjectManager:MonoBehaviour {
    static List<GameObject> dontDestroyObjects = new List<GameObject>();

    static public void DontDestroyOnLoad(GameObject obj) {
        dontDestroyObjects.Add (obj);
    }

    static public void DestoryAll() {
        foreach (var obj in dontDestroyObjects) {
            Destroy(obj);   }
        dontDestroyObjects.Clear ();
    }
}