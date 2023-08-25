using UnityEngine;

public class shaderoffset : MonoBehaviour
{
    
    public Renderer render;
    public Vector2 vec2;
    Vector2 offset;
    private void Start()
    {
          render = GetComponent<Renderer> ();
    
    }
    private void Update()
    {
        offset=offset+vec2;
          render.material.SetTextureOffset("_MainTex", offset);
    
    }
}