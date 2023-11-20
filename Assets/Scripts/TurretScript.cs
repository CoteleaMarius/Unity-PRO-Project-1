using UnityEngine;
using System.Collections;
public class TurretScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range;
    [SerializeField] private GameObject particles;
    [Header("Bullet setting")] [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField] private Transform[] gunBarrel;
    [SerializeField] private float countdown;
    private bool _isSecondBarrel;
    private bool _canShoot = true;
    private readonly float _turnSpeed = 10f;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Start()
    {
        InvokeRepeating(nameof(FindTarget), 0f, 0.3f);
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        int barrelNumber = 0;
        if (target != null)
        {
            Quaternion look = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, look, Time.deltaTime * _turnSpeed);
            if (_canShoot && TargetLock())
            {
                StartCoroutine(Shoot(barrelNumber));
                barrelNumber++;
                if (barrelNumber == gunBarrel.Length) barrelNumber = 0;
                audioSource.Play();
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                _canShoot = !_canShoot;
            }
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject currentTarget = null;
        float distance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToEnemy < distance)
            {
                distance = distanceToEnemy;
                currentTarget = target;
            }
        }

        if (distance <= range && currentTarget != null)
        {
            this.target = currentTarget.transform;
        }
        else
        {
            this.target = null;
        }
    }
    
    IEnumerator Shoot(int barrelNumber)
    {
        GameObject bullet =  Instantiate(bulletPrefab, gunBarrel[barrelNumber]);
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        Instantiate(particles, transform);
        bulletScript.TakeForce(target);
        bullet.transform.SetParent(null);
        _isSecondBarrel = !_isSecondBarrel;
  
        yield return new WaitForSeconds(countdown);
        _canShoot = !_canShoot;
    }

    private bool TargetLock()
    {
        float angle = Quaternion.Angle(transform.rotation, target.rotation);
        if (angle > 80 && angle < 100) return true;
        else return false;
    }
    
}