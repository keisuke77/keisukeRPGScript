//  GameObjectExtension.cs
//  http://kan-kikuchi.hatenablog.com/entry/GetComponentInParentAndChildren
//
//  Cr
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// GameObjectの拡張クラス
/// </summary>
/// 
/// 
/// 
/// 
/// 
/// 
public static class GameObjectExtension{
public static Camera NowCameraGet(){
 var cams = GameObjectExtension.GetComponentsInActiveScene<Camera>(false);
        Camera temp = null;
        foreach (var item in cams)
        {
            if (temp == null)
            {
                temp = item;
            }
            if (item.depth > temp.depth)
            {
                temp = item;
            }
        }
        return temp;
}
  public static void Stop(this GameObject g ){

    foreach (var item in  g.root().GetComponentsInChildren<IMove>())
    {
        
item.Stop = true; 
    }
  }  public static void Restart(this GameObject g ){

    foreach (var item in  g.root().GetComponentsInChildren<IMove>())
    {
        
item.Stop = false; 
    }
  }

     
   
     // 通常trueしか指定しないのでデフォルト引数をtrueにしてます
    public static T[] GetComponentsInActiveScene<T>(bool includeInactive = true)
    {
        // ActiveなSceneのRootにあるGameObject[]を取得する
        var rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        // 空の IEnumerable<T>
        IEnumerable<T> resultComponents = (T[])Enumerable.Empty<T>();
        foreach (var item in rootGameObjects)
        {
            // includeInactive = true を指定するとGameObjectが非活性なものからも取得する
            var components = item.GetComponentsInChildren<T>(includeInactive);
            resultComponents = resultComponents.Concat(components);
        }
        return resultComponents.ToArray();
    }
  public static GameObject Clone(this GameObject go )
    {
        var clone = GameObject.Instantiate( go ,go.transform.parent) as GameObject;
        return clone;
    }
 
 public static List<GameObject> GetAllChildren(this GameObject gameObject)
        {
            Transform[] childTransforms = gameObject.GetComponentsInChildren<Transform>();
            var allChildren = new List<GameObject>(childTransforms.Length);

            foreach (var child in childTransforms)
            {
                if (child.gameObject != gameObject) allChildren.Add(child.gameObject);
            }

            return allChildren;
        }

        public static List<GameObject> GetAllChildrenAndSelf(this GameObject gameObject)
        {
            Transform[] childTransforms = gameObject.GetComponentsInChildren<Transform>();
            var allChildren = new List<GameObject>(childTransforms.Length);

            foreach (var child in childTransforms)
            {
                allChildren.Add(child.gameObject);
            }

            return allChildren;
        } /// <summary>
    /// コンポーネントを削除します
    /// </summary>
    public static void RemoveComponent<T>(this Component self) where T : Component
    {
        GameObject.Destroy(self.GetComponent<T>());
    }

        public static Mesh GetMesh(this GameObject gameObject)
        {
            MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
            if (meshFilter != null && meshFilter.sharedMesh != null) return meshFilter.sharedMesh;

            SkinnedMeshRenderer skinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
            if (skinnedMeshRenderer != null && skinnedMeshRenderer.sharedMesh != null) return skinnedMeshRenderer.sharedMesh;

            return null;
        }

        public static bool IsRendererEnabled(this GameObject gameObject)
        {
            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null) return meshRenderer.enabled;

            SkinnedMeshRenderer skinnedRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
            if (skinnedRenderer != null) return skinnedRenderer.enabled;

            return false;
        }

        public static Bounds GetInstantiatedBounds(this GameObject prefab)
		{
			GameObject go = MonoBehaviour.Instantiate(prefab);
			go.transform.position = prefab.transform.position;
			Bounds bounds = new Bounds(go.transform.position, Vector3.zero);
			foreach (Renderer r in go.GetComponentsInChildren<Renderer>())
			{
				bounds.Encapsulate(r.bounds);
			}
			foreach (Collider c in go.GetComponentsInChildren<Collider>())
			{
				bounds.Encapsulate(c.bounds);
			}
			MonoBehaviour.DestroyImmediate(go);
			return bounds;
		}

  
  
  /// <summary>
  /// 親や子オブジェクトも含めた範囲から指定のコンポーネントを取得する
  /// </summary>
  public static T GetComponentInParentAndChildren<T>(this GameObject gameObject) where T : UnityEngine.Component {

    if(gameObject.GetComponentInParent<T>() != null){
      return gameObject.GetComponentInParent<T>();
    }
    if(gameObject.GetComponentInChildren<T>() != null){
      return gameObject.GetComponentInChildren<T>();
    }

    return gameObject.GetComponent<T>();
  }
  
  /// <summary>
  /// 親や子オブジェクトも含めた範囲から指定のコンポーネントを全て取得する
  /// </summary>
  public static List<T> GetComponentsInParentAndChildren<T>(this GameObject gameObject) where T : UnityEngine.Component {
    List<T> _list = new List<T>(gameObject.GetComponents<T>());

    _list.AddRange (new List<T>(gameObject.GetComponentsInChildren<T>()));
    _list.AddRange (new List<T>(gameObject.GetComponentsInParent<T>()));

    return _list;
  }  

}