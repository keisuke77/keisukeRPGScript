
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public static class vectorextension 
{
    

public static Vector3 ToEulerAnglesZimbalLock(float x, Quaternion q)
{
    // Z=0radの時のオイラー角を求める
    return ToEulerAnglesZimbalLock(x, 0f, q);
}

public static Vector3 ToEulerAnglesZimbalLock(float x, float z, Quaternion q)
{
    float y;
    if (x > 0)
    {
        var yMinusZ = Mathf.Atan2(2 * q.x * q.y - 2 * q.z * q.w, 2 * Mathf.Pow(q.w, 2) + 2 * Mathf.Pow(q.x, 2) - 1);
        y = yMinusZ + z;
    }
    else
    {
        var yPlusZ = Mathf.Atan2(-(2 * q.x * q.y - 2 * q.z * q.w), 2 * Mathf.Pow(q.w, 2) + 2 * Mathf.Pow(q.x, 2) - 1);
        y = yPlusZ - z;
    }

    var angles = new Vector3(x, y, z) * Mathf.Rad2Deg;
    return new Vector3(
        Normalize(angles.x),
        Normalize(angles.y),
        Normalize(angles.z)
    );
}


public static Vector3 ToEulerAngles(this Quaternion q)
{ 
    var sinX = 2 * q.y * q.z - 2 * q.x * q.w;
    var absSinX = Mathf.Abs(sinX);
    const float e = 0.001f;
    // X軸の回転が0度付近の場合、0になるか360で差が大きいので0に丸める
    if (absSinX < e)
    {
        sinX = 0f;
    }
    var x = Mathf.Asin(-sinX);
    // X軸の回転が90度付近の場合はジンバルロック状態になっている
    if (float.IsNaN(x) || Mathf.Abs((Mathf.Abs(x) -  Mathf.PI / 2f)) < e)
    {
        x = Mathf.Sign(-sinX) * (Mathf.PI / 2f);
        return ToEulerAnglesZimbalLock(x, q);
    }
     x = Mathf.Asin(-sinX);
    var cosX = Mathf.Cos(x);

    var sinY = (2 * q.x * q.z + 2 * q.y * q.w) / cosX;
    var cosY = (2 * Mathf.Pow(q.w, 2) + 2 * Mathf.Pow(q.z, 2) - 1) / cosX;
    var y = Mathf.Atan2(sinY, cosY);

    var sinZ = (2 * q.x * q.y + 2 * q.z * q.w) / cosX;
    var cosZ = (2 * Mathf.Pow(q.w, 2) + 2 * Mathf.Pow(q.y, 2) - 1) / cosX;
    var z = Mathf.Atan2(sinZ, cosZ);

    var angles = new Vector3(x, y, z) * Mathf.Rad2Deg;
    return new Vector3(
        Normalize(angles.x),
        Normalize(angles.y),
        Normalize(angles.z)
    );
}

public static float Normalize(float x)
{
    return (x > 0f ? x : 360f + x) % 360;
}

}