using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class colorchange
{

public static Color GetRandomVividColor(float alpha){
    Color c;
    float rnd = Random.value;

    if (rnd < 1f / 6f) {
        c = new Color (0f, 1f, Random.value, alpha);
    } else if (rnd < 2f / 6f) {
        c = new Color (0f, Random.value, 1f, alpha);
    } else if (rnd < 3f / 6f) {
        c = new Color (1f, 0f, Random.value, alpha);
    } else if (rnd < 4f / 6f) {
        c = new Color (Random.value, 0f, 1f, alpha);
    } else if (rnd < 5f / 6f) {
        c = new Color (1f, Random.value, 0f, alpha);
    } else {
        c = new Color (Random.value, 1f, 0f, alpha);
    }

    return c;
}
}