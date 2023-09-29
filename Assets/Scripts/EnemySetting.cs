using UnityEngine;

public class EnemySetting : MonoBehaviour
{
    [SerializeField] private uint health;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;

    public float GetSpeed()
    {
        return speed;
    }

    public uint GetHealth()
    {
        return health;
    }

    public void Damage(uint damageValue)
    {
        if (damageValue > health) return;
        health -= damageValue;
        if(health <= 0) Destroy(gameObject);
    }
}
