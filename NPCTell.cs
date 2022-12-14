using UnityEngine;

public class NPCTell : MonoBehaviour
{public string mes;

    void Start()
    {
        Play(mes);
    }
    public void Play(string mess){
keikei.AutoRotateCamera.SetMessageAtractCamera(transform,mes);
    }
}