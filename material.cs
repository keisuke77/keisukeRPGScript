using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class material : MonoBehaviour
{

    public SkinnedMeshRenderer skinmaterials;
    public Material materials;
    public Color color;
    public Color randomvivid;
    // Start is called before the first frame update
    void Start()
    {
        if (skinmaterials!=null)
        {
             color =skinmaterials.material.color;
      
        }
         
    }
public void changecolor(Color colorinto,float during ){
skinmaterials.material.color = colorinto;
StartCoroutine(returncolor(during));
}
IEnumerator returncolor(float during)
{ 
    yield return new WaitForSeconds(during);
    skinmaterials.material.color = color;
    yield return null;
}
    // Update is called once per frame
    void Update()
    {
        randomvivid=vivicolor.GetRandomVividColor(1);
        
   materials.color=randomvivid; }
}
