using UnityEngine;using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public enum Mode
    {
        Opaque,
        Cutout,
        Fade,
        Transparent,
    }

public static class ColorExtensions
{
    public static Color GetRandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        return new Color(r, g, b);
    }
}
public static class MaterialExtension
{
    
public static List<Renderer> meshRenderers;

  public static void setA(this Image col,int a){
Color c=col.color;
c.a=a;
col.color=c;
     }
public static void ChangeChildMaterials(this Transform parentTransform, Material newMaterial)
    {
        foreach (Transform child in parentTransform)
        {
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material = newMaterial;
            }
        }
    }
 public static void ChangeChildColor(this GameObject parent, Color newColor)
    {
        Renderer[] renderers = parent.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.color = newColor;
        }
    }
        public static void SetBlendMode(this Material material, Mode blendMode)
    {
        switch (blendMode)
        {
            case Mode.Opaque:
                material.SetOverrideTag("RenderType", "");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
                break;
            case Mode.Cutout:
                material.SetOverrideTag("RenderType", "TransparentCutout");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.EnableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 2450;
                break;
            case Mode.Fade:
                material.SetOverrideTag("RenderType", "Transparent");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
            case Mode.Transparent:
                material.SetOverrideTag("RenderType", "Transparent");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
        }
    }

public static List<Renderer> GetRender(this GameObject obj){
 meshRenderers= new List<Renderer>();
         foreach (var item in obj.GetAllChildrenAndSelf())
     {
         if ((item.GetComponent<SkinnedMeshRenderer>()||item.GetComponent<MeshRenderer>())&&item.tag!="Nodissolve")
     { 
          meshRenderers.Add(item.GetComponent<Renderer>());
     }
     }
     return meshRenderers;
}


public static List<Material> GetMaterial(this GameObject obj){

return null;
}
}