using UnityEngine;
using System.Collections;
public class TurretScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range;

    [Header("Bullet setting")] [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField] private Transform[] gunBarrel;
    [SerializeField] private float countdown;
    private bool _isSecondBarrel;
    private bool _canShoot = true;

    private void Start()
    {
        InvokeRepeating(nameof(FindTarget), 0f, 0.3f);
    }

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            if (_canShoot)
            {
                StartCoroutine(_isSecondBarrel ? Shoot(0) : Shoot(1));

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
        bulletScript.TakeForce(target);
        bullet.transform.SetParent(null);
        _isSecondBarrel = !_isSecondBarrel;
  
        yield return new WaitForSeconds(countdown);
        _canShoot = !_canShoot;
    }
    
}