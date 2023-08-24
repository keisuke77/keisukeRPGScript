using System.Collections;
using UnityEngine;

[System.Serializable]
public class ShakeParameters
{
    [Range(0.1f, 2.0f)]
    public float shakeDuration = 0.5f; // シェイクの持続時間

    [Range(0.1f, 2.0f)]
    public float shakeMagnitude = 0.7f; // シェイクの振幅

    [Range(0.5f, 3.0f)]
    public float dampingSpeed = 1.0f;  // シェイクが減少する速度

    public ShakeParameters(float duration, float magnitude, float damping)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        dampingSpeed = damping;
    }
}

public class CameraShake : MonoBehaviour
{
    static Transform camTransform;

    public static bool isShaking = false;

    private static Vector3 originalPosition;

    private void Awake()
    {
        camTransform = transform;
    }
   public static void TriggerShake(ShakeParameters parameters)
    {
        if (!isShaking)
        {
            originalPosition = camTransform.localPosition; // シェイク開始前の位置を取得
            CoroutineRunner.Instance.StartCoroutine(Shake(parameters.shakeDuration, parameters.shakeMagnitude, parameters.dampingSpeed));
        }
    }

    static IEnumerator Shake(float duration, float magnitude, float damping)
    {
        isShaking = true;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            camTransform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;
            magnitude = Mathf.Lerp(magnitude, 0, damping * Time.deltaTime);

            yield return null;
        }

        camTransform.localPosition = originalPosition;
        isShaking = false;
    }
}
