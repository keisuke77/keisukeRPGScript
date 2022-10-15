using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManage : Singleton<SceneManage>
{
    public string beforeScene;
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


    public void ReloadScene(){

LoadScene(SceneManager.GetActiveScene().name);
    } 
     public void BackScene(){

LoadScene(beforeScene);
    }
    public void FadeBackScene(){

FadeLoadScene(beforeScene);
    }


 public void LoadScene(string scenename) 
        {
            beforeScene=SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(scenename);
        }

        
public void FadeLoadScene(string scenename){

    Fade.Instance.FadeIn(2f ,()=>LoadScene(scenename));
       
}

public void FadeInoutScene(string scenename){
	Fade.Instance.FadeIn(1f,()=>{LoadScene(scenename);
       ;keikei.delaycall(()=>Fade.Instance.FadeOut(1,null),1f);}
);
}


}