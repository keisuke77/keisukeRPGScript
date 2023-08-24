//  GameObjectExtension.cs
//  http://kan-kikuchi.hatenablog.com/entry/GetComponentInParentAndChildren
//
//  Created by kikuchikan on 2015.08.25.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// GameObjectの拡張クラス
/// </summary>
public static class InstanceExtension
{
    public static void spawn(this Collider col, Transform trans, GameObject effect)
    {
        if (col != null)
        {
            Vector3 hitPos = col.ClosestPointOnBounds(trans.position);
            keikei.instantiate(effect, hitPos, Quaternion.identity);
            if (hitPos == null)
            {
                keikei.instantiate(effect, col.transform.position, Quaternion.identity);
            }
        }
    }

    public static GameObject Instantiate(this GameObject obj, Transform trans)
    {
        return keikei.instantiate(obj, trans.position, trans.rotation);
    }

    public static GameObject ResorcesInstantiate(this string objname, Transform trans)
    {
        return objname.GameObjectResourcesLoad().Instantiate(trans);
    }

    public static GameObject Instantiate(this GameObject obj, Vector3 trans)
    {
        return keikei.instantiate(obj, trans, Quaternion.identity);
    }
}
