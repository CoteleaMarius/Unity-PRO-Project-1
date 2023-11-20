using UnityEngine;

public class EnemySetting : MonoBehaviour
{
    [SerializeField] private uint health;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private GameObject boomFX;
    
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
        if (damageValue > health)
        {
            CoinController.AddCoin(10);
            Instantiate(boomFX, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            Destroy(gameObject);
        }
        health -= damageValue;
    }
}
