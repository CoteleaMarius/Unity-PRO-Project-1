using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMovement : MonoBehaviour
{
    private Vector3 _finishPoint;
    private NavMeshAgent _navMesh;
    private EnemySetting _enemySetup;

    private void Awake()
    {
        _navMesh = gameObject.GetComponent<NavMeshAgent>();
        _finishPoint = GameObject.FindGameObjectWithTag("Finish").gameObject.transform.position;
        _enemySetup = gameObject.GetComponent<EnemySetting>();
    }

    private void Start()
    {
        _navMesh.destination = _finishPoint;
        _navMesh.speed = _enemySetup.GetSpeed();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
