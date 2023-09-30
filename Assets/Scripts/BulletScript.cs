using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody _rb;
    [SerializeField] private uint damage = 15;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void TakeForce(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        _rb.AddForce(dir * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<EnemySetting>().Damage(damage);
        }
    }
}
