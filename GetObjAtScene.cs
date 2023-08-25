using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public static class GetObjAtScene
{
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
<<<<<<< HEAD
            if (components!=null)
            {
                  resultComponents = resultComponents.Concat(components);
  
            }
                }
=======
            resultComponents = resultComponents.Concat(components);
        }
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
        return resultComponents.ToArray();
    }

    // 1つだけ取得したい場合はこちら（GetComponentsInActiveSceneを元にして書いたので少し非効率です）
    public static T GetComponentInActiveScene<T>(bool includeInactive = true)
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
        return resultComponents.First();
    }
}