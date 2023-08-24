
using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class itemhave : MonoBehaviour {

 

　　//手のオブジェクトを設定
public GameObject item;

    public GameObject targethand;

    public Vector3 offset;
    
private GameObject obj;
　　//調節用

    [SerializeField]

    float controlX = 90;

    [SerializeField]

    float controlY;

    [SerializeField]

    float controlZ;



    public string path = "Prefab/iphoneX";



    // Use this for initialization

    void Start () {

        offset = new Vector3(controlX,controlY,controlZ);

        HoldInHand();

    }

    

    // Update is called once per frame

    void Update () {

        obj.transform.position=targethand.transform.position;

    }

//Resources.Load<GameObject>(this.path)

    public void HoldInHand(){

    item.GetComponent<MeshCollider>().enabled=false;
        obj = Instantiate(item,targethand.transform.position,targethand.transform.rotation);

        obj.transform.SetParent(targethand.transform);

        obj.transform.eulerAngles = offset;

    }

}
