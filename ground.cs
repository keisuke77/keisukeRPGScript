using UnityEngine;

public class ground : MonoBehaviour {
      public LayerMask groundMask;
public bool isGrounded;

void OnTriggerEnter(Collider other) {
    if (groundMask == (groundMask | (1 << other.gameObject.layer))) {
        isGrounded = true;
    }
}

void OnTriggerExit(Collider other) {
    if (groundMask == (groundMask | (1 << other.gameObject.layer))) {
        isGrounded = false;
    }
}

}