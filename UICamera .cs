using UnityEngine;
 
public class UICamera : MonoBehaviour {
 
    [SerializeField]
    private RectTransform canvasRectTfm;
    [SerializeField]
    private Transform targetTfm;
 
    private RectTransform myRectTfm;
    private Vector3 offset = new Vector3(0, 1.5f, 0);
 
    void Start() {
        myRectTfm = GetComponent<RectTransform>();
 
    }
 
    void Update() {
        Vector2 pos;
 
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);
 
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTfm, screenPos, Camera.main, out pos);
 
        myRectTfm.position = pos;
 
    }
}