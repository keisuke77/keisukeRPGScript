using UnityEngine;

[CreateAssetMenu(fileName = "waza", menuName = "enemywaza")]
public class waza : ScriptableObject
{
    public Animation animation;

    [System.Serializable]
    public class wazas
    {
        [Range(0, 100)]
        public int kakuritu;
        public string name;
        public motions motions;
        public waza wazachange;

        [Range(0, 100)]
        public int mindis;

        [Range(0, 100)]
        public int maxdis;
    }

    public wazas[] wazalist;

  
    [Range(0, 20)]
    public float MinInterval,MaxInterval = 1;
    
}
