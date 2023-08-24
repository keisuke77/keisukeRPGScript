using UnityEngine;

public class GroundCast : MonoBehaviour {
      public float groundDistance = 0.2f; // Adjust as needed
 public LayerMask groundMask;
  public bool isGrounded;
  
    public RaycastHit hit;
  
    void Update() {
 isGrounded = Physics.Raycast(transform.position, -Vector3.up, out hit, groundDistance, groundMask);

       
  }
}