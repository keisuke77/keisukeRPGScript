using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          // プレイヤーのTransform
    public Transform enemy;           // 敵のTransform
    public float distanceFromPlayer;  // プレイヤーからカメラまでの距離
    public Vector3 offset;            // カメラのオフセット
    public LayerMask obstacleLayer;   // 障害物のレイヤー

    void Update()
    {
        if (player == null || enemy == null) return;

        // 敵とプレイヤーの間の方向を取得
        Vector3 directionFromEnemyToPlayer = (player.position - enemy.position).normalized;

        // プレイヤーの位置に、その方向に距離を掛けた値を足してカメラの位置を計算
        Vector3 desiredCameraPosition = player.position + directionFromEnemyToPlayer * distanceFromPlayer + offset;

        // カメラの高さを変えないようにする
        desiredCameraPosition.y = transform.position.y;

        // プレイヤーとカメラの間に障害物があるか確認
        if (Physics.Linecast(player.position, desiredCameraPosition, out RaycastHit hit, obstacleLayer))
        {
            // 障害物があれば、その位置にカメラを移動
            desiredCameraPosition = hit.point;
        }

        // カメラの位置を更新
        transform.position = desiredCameraPosition;

        // カメラをプレイヤーの方向に向ける
        transform.LookAt(player.position+offset);
    }
}
