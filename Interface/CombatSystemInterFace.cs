using UnityEngine;


public interface IDamagable
{ 
    void AddDamage(float damagevalue);
}

public interface IMove
{
    bool Stop{get;set;} 
    float speed{get;set;}
}


interface IForceIdle
{
    void AddForce(Vector3 force);
}
