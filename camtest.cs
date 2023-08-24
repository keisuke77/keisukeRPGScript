using UnityEngine;

public class camtest : MonoBehaviour
{
   public Transform player; // プレイヤーのTransformを指定
   public Transform enemy; // 敵のTransformを指定（敵を見る必要がない場合は不要）

   public float distanceFromPlayer = 5f; // プレイヤーからの距離
   public float cameraSpeed = 5f; // カメラの回転速度

   public float minVerticalAngle = -20f; // カメラの最小上下角度
   public float maxVerticalAngle = 70f; // カメラの最大上下角度

   public float currentYaw = 0f; // カメラの現在のY軸回転角度
   public float currentPitch = 0f; // カメラの現在のX軸回転角度

   
   private void Update()
   {
       // カメラの水平回転
       currentYaw += Input.GetAxis("Mouse X") * cameraSpeed;
       // カメラの垂直回転
       currentPitch -= Input.GetAxis("Mouse Y") * cameraSpeed;
       currentPitch = Mathf.Clamp(currentPitch, minVerticalAngle, maxVerticalAngle);

       // プレイヤーの周りを回るカメラ位置を計算
       Vector3 offset = new Vector3(0, 0, -distanceFromPlayer);
       Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0);
       Vector3 cameraPosition = player.position + rotation * offset;

       // カメラ位置とプレイヤーの位置を更新
       transform.position = cameraPosition;
       transform.LookAt(player.position);

       // 敵が存在する場合は敵とプレイヤーが見えるようにカメラを向ける
       if (enemy != null)
       {
           Vector3 directionToEnemy = enemy.position - transform.position;
           transform.rotation = Quaternion.LookRotation(directionToEnemy, Vector3.up);
       }
   }
}