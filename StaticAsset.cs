using UnityEngine;

public class StaticAsset : Singleton<StaticAsset>
{
 public void Awake()
    {
        if (this!=Instance)
        {
            Destroy(gameObject);
            
            return;
        }
        
        transform.parent = null;
        DontDestroyOnLoad(this.gameObject);
        
        }

        public GameObject[] Objs;
        public Sprite[] sprites;
}