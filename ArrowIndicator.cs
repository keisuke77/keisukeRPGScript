using UnityEngine;
using UnityEngine.UI;

public class ArrowIndicator : MonoBehaviour
{
    public GameObject enemy;
    public Image arrowIndicator;
    private Camera cam;
    private RectTransform arrowRectTransform;
    private Vector3 enemyScreenPos;

    // Adding new variables for smoothing
    public float positionSmoothTime = 0.1f;
    public float rotationSmoothTime = 0.1f;
    private Vector3 velocity;
    private float angleVelocity;

    private void Start()
    {
        cam = Camera.main;
        arrowRectTransform = arrowIndicator.GetComponent<RectTransform>();
    }

    void Update() 
    {
        enemyScreenPos = cam.WorldToViewportPoint(enemy.transform.position);

        if (enemyScreenPos.z < 0) 
        {
            enemyScreenPos.x = 1 - enemyScreenPos.x;
            enemyScreenPos.y = 1 - enemyScreenPos.y;
        }

        enemyScreenPos.x = Mathf.Clamp(enemyScreenPos.x, 0.05f, 0.95f); 
        enemyScreenPos.y = Mathf.Clamp(enemyScreenPos.y, 0.05f, 0.95f); 

        // Smoothly move the arrow indicator to the target position
        Vector3 targetPosition = Vector3.SmoothDamp(arrowRectTransform.anchorMin, enemyScreenPos, ref velocity, positionSmoothTime);
        arrowRectTransform.anchorMin = targetPosition;
        arrowRectTransform.anchorMax = targetPosition;

        Vector3 enemyScreenPosCentered = new Vector3(enemyScreenPos.x - 0.5f, enemyScreenPos.y - 0.5f, enemyScreenPos.z);
        float targetAngle = Mathf.Atan2(-enemyScreenPosCentered.y, -enemyScreenPosCentered.x) * Mathf.Rad2Deg;

        // Smoothly rotate the arrow indicator to the target angle
        float smoothAngle = Mathf.SmoothDampAngle(arrowIndicator.rectTransform.eulerAngles.z, targetAngle + 180, ref angleVelocity, rotationSmoothTime);
        arrowIndicator.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, smoothAngle));
    }
}
