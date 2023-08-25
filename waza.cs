using UnityEngine;

[CreateAssetMenu(fileName = "waza", menuName = "enemywaza")]
public class waza : ScriptableObject
{
<<<<<<< HEAD
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
=======
    

    public Animation animation;
[System.Serializable]


public class wazas
{[Range(0,100)]
    public int kakuritu;
    public string name;
    public motions motions;
public waza wazachange;
[Range(0,100)]
    public int mindis;
    
[Range(0,100)]
    public int maxdis;
}
public wazas[] wazalist;

[Range(0,100)]
public float minwalk=1;
[Range(0,100)]
public float maxwalk=50;

[Range(0,100)]
public float interval=1;
}
>>>>>>> 8f801b51619bfcf5558b25515bc1db31499b7dae
