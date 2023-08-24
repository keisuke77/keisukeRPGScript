 using UnityEngine;using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

namespace Shogi
{


[CreateAssetMenu(fileName = "Koma", menuName = "Shogi/Koma", order = 0)]
public class Koma : ScriptableObject {
    public Vector2[] PlaceablePos;
    public string Name;
    public Texture NormalIcon;
    public Texture NariIcon;
    public bool Skipable;
    public int Score;
    public Vector2[] isNariPlaceablePos;
}
}