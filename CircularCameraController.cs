using UnityEngine;

public class CircularCameraController : MonoBehaviour
{
    public Transform player; // プレイヤーのTransformを指定
    public Transform target; // ターゲット（敵）のTransformを指定

    public float distanceFromPlayer = 5f; // プレイヤーからの距離
    public float cameraSpeed = 5f; // カメラの移動速度

    public float minVerticalAngle = -20f; // カメラの最小上下角度
    public float maxVerticalAngle = 70f; // カメラの最大上下角度

    private Vector3 originalPosition; // 円状の中心位置
    private float currentAngle = 0f; // 現在の角度

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originalPosition = player.position;
    }

    private void LateUpdate()
    {
        // プレイヤーの現在位置と円状の中心位置を取得
        Vector3 playerPosition = player.position;
        Vector3 centerPosition = originalPosition;

        // プレイヤーが移動した場合、円状も一緒に移動
        if (playerPosition != centerPosition)
        {
            Vector3 offset = playerPosition - centerPosition;
            centerPosition += offset;
            originalPosition = centerPosition;
        }

        // カメラの位置を円状に沿って計算
        float angleInRadians = currentAngle * Mathf.Deg2Rad;
        Vector3 cameraPosition = new Vector3(centerPosition.x + distanceFromPlayer * Mathf.Cos(angleInRadians),
                                             centerPosition.y,
                                             centerPosition.z + distanceFromPlayer * Mathf.Sin(angleInRadians));

        // カメラの上下角度を固定
        float desiredPitch = Mathf.Clamp(transform.eulerAngles.x, minVerticalAngle, maxVerticalAngle);
        transform.eulerAngles = new Vector3(desiredPitch, transform.eulerAngles.y, 0);

        // ターゲットが存在する場合、カメラをターゲットに向ける
        if (target != null)
        {
            transform.LookAt(target.position);
        }
        else
        {
            // カメラを円状の中心に向ける
            transform.LookAt(centerPosition);
        }

        // カメラ位置を更新
        transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime * cameraSpeed);

        // カメラの角度を更新
        currentAngle += Input.GetAxis("Horizontal") * cameraSpeed;
    }
}
 