using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class onbutton : MonoBehaviour
{
    private Text tet;
    public string scene = SceneManager.GetActiveScene().name;
    private string ori;
    private GameObject button;
    private Vector3 sca;
    private Vector3 orive;
    public InputField input;

    // Start is ca;lled before the first frame update
    void Start()
    {
        // ボタンのテキストコンポーネントをキャッシュ
        orive = this.transform.localScale;
        sca = orive * 1.1f;
        Debug.Log(sca);

        tet = GetComponentInChildren<Text>();
        button = this.gameObject;
        ori = tet.text;
    }

    public void OnMouseOver()
    {
        tet.text = "click!";
        button.transform.localScale = sca;
    }

    public void OnMouseExit()
    {
        tet.text = ori;
        button.transform.localScale = orive;
    }

    public void onbuttonclick()
    {
        Debug.Log("click");
        SceneManager.LoadScene(input.text);
        tet.text = "let go!";
    }

    // Update is called once per frame
    void Update() { }
}
