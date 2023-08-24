using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCameraController : MonoBehaviour
{
    [Header("References")]
    public Transform player;  // プレイヤーのTransform
    public Transform enemy;   // 敵のTransform
    public LayerMask collisionMask; // プレイヤーとカメラの間に障害物があるか確認するためのレイヤーマスク

    [Header("Camera Parameters")]
    public float defaultDistance = 5.0f;  
    public float defaultHeight = 3.0f;  
    public float heightDamping = 2.0f;  
    public float rotationDamping = 3.0f;  
    public float positionDamping = 5.0f;  
    public Vector3 offset = Vector3.zero; // カメラが注視する位置へのオフセット
    public Vector3 offsetView = Vector3.zero; // プレイヤーと敵の位置へのオフセット
    public float distanceRate = 1.0f;
    [Range(0,100)]
    public float minDistance, maxDistance;
    public float rotationSpeed = 50.0f;  // カメラの回転速度
    public controll rotationAxis;
    private float currentHorizontalRotation = 0.0f;  // カメラの現在の水平回転角度

    void LateUpdate ()
    {
        // プレイヤーと敵の位置を計算
        Vector3 adjustedPlayerPos = player.position + offsetView;
        Vector3 adjustedEnemyPos = enemy.position + offsetView;

        // カメラの目標位置と回転を計算
        UpdateCameraPositionAndRotation(adjustedPlayerPos, adjustedEnemyPos);
    }

    void UpdateCameraPositionAndRotation(Vector3 playerPos, Vector3 enemyPos)
    {
           // Horizontalキーでのカメラの回転を追加
      float horizontalInput = keiinput.Instance.GetAxis(rotationAxis);
       currentHorizontalRotation += horizontalInput * rotationSpeed * Time.deltaTime;

    // カメラの目標の回転と高さを計算
      float targetRotationAngle = Quaternion.LookRotation(enemyPos - playerPos).eulerAngles.y + currentHorizontalRotation;

        // プレイヤーと敵の間の距離に基づいてカメラの距離を調整
        float calculatedDistance = Vector3.Distance(playerPos, enemyPos) * distanceRate;
        float clampedDistance = Mathf.Clamp(calculatedDistance, minDistance, maxDistance);

        // プレイヤーと敵の中間点を計算
        Vector3 middlePoint = (enemyPos + playerPos) / 2.0f;

        float targetHeight = middlePoint.y + defaultHeight;

        // 現在のカメラの角度と高さ
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // ダンピングを使用して現在の角度と高さを滑らかに調整
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, targetRotationAngle, rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, targetHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // カメラの新しい位置を計算
        Vector3 newPosition = middlePoint - (currentRotation * Vector3.forward * clampedDistance);
        newPosition.y = currentHeight;

        // カメラの位置の障害物を確認
        CheckForObstructions(ref newPosition, playerPos);

        

        // カメラの位置を滑らかに更新
        transform.position = Vector3.Lerp(transform.position, newPosition, positionDamping * Time.deltaTime);

        // オフセットを加えて中間点を注視
        transform.LookAt(middlePoint + offset);

   

    }

    void CheckForObstructions(ref Vector3 cameraPosition, Vector3 targetPosition)
    {
        RaycastHit hit;
        if (Physics.Linecast(targetPosition, cameraPosition, out hit, collisionMask))
        {
            // 障害物があれば、カメラの位置をそのポイントに設定
            cameraPosition = hit.point;
        }
    }
}
