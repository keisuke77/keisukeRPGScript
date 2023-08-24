using UnityEngine;

public class BodyForce : MonoBehaviour {
    public float pow=0.1f;
    private void OnTriggerStay(Collider other) {
        Debug.Log("colllllll");
        other.root().GetComponent<DOForce>().AddForce(gameObject,pow);
    }
}