using UnityEngine;

public class BaseControll : MonoBehaviour {
      
    public float speed = 1.0f;

    [SerializeField]
    private float gravity = 9.8f;
    public Vector3 direction;

    public string horizon = "Horizontal";
    public string vertical = "Vertical";
}