using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
public static class ScriptableGenerator
{
    public static T CreateScriptableObject<T> (string paths="Assets/0ScriptableObjects")where T : UnityEngine.ScriptableObject
    {
        var obj = ScriptableObject.CreateInstance<T>();
        var fileName = $"{TypeNameToString(obj.GetType().ToString())}.asset";
        var path = paths;
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
#if UNITY_EDITOR
        AssetDatabase.CreateAsset(obj, Path.Combine(path, fileName));
    #endif
        return obj;
    }
    
    private static string TypeNameToString(string type)
    {
        var typeParts = type.Split(new char[] { '.' });
        if (!typeParts.Any())
            return string.Empty;

        var words = Regex.Matches(typeParts.Last(), "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)")
            .OfType<Match>()
            .Select(match => match.Value)
            .ToArray();
        return string.Join(" ", words);
    }
}