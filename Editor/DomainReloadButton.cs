using UnityEditor;
using UnityEngine;

public class DomainReloadButton
{
    [MenuItem("Tools/Reload Domain")]
    public static void ReloadDomain()
    {
        EditorUtility.RequestScriptReload();
    }
}
