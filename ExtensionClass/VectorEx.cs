using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using DG.Tweening;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public static class VectorEx
{
    public static List<Vector2> AllDerectionGet(this Vector2 center, float size)
    {
        List<Vector2> result = new List<Vector2>();
        for (var i = -1; i < 2; i++)
        {
            for (var j = -1; j < 2; j++)
            {
                var detect = new Vector2(i, j);
                for (var s = 0; s < size; s++)
                {
                    result.Add(center + (detect * s));
                }
            }
        }
        return result;
    }
}
