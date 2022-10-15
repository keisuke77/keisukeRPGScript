using UnityEngine;

public class materialoffset : MonoBehaviour
{
    // Scroll main texture based on time

   public float scrolltime = 0.5f;
    Renderer rend;
      public AnimationCurve curve;
public GameObject item;
public GameObject particle;
    void Start()
    {
        rend = GetComponent<Renderer> ();
    }
float timer;
public float offset;
float nowtime;
    void Update()
    {
        nowtime+=Time.deltaTime;
        if (nowtime<scrolltime)
    {
         timer+=curve.Evaluate(nowtime/scrolltime);
        offset=(timer%9);
        }else
    {


int Roundoffset=(int)Mathf.Round(offset);

          offset=Mathf.Lerp(offset,Roundoffset,0.2f);
          if (Mathf.Approximately(offset,Roundoffset))
          { rend.material.SetColor("_Color", Color.green);
              keikei.delaycall(()=>{SimpleMeshExploder.instance.Explode(transform); keikei.itemappend(item,transform,1,Roundoffset);},3f);
               }

    }
         rend.material.SetTextureOffset("_MainTex", new Vector2(offset/10, 0));
    
      
    }
}