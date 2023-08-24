using UnityEngine;

using UnityEngine.UI;
public class onoffbutton : MonoBehaviour
{[SerializeField]
    GameObject obj;
    Button button;
 
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

   public void OnClick(){

obj.SetActive(!obj.activeSelf);
    }
}