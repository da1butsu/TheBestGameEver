using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    private bool _isPlayerNoticed;
    public List<Transform> patrolPoint;
    public PlayerController Player; 
    public float viewAngel;

    private NavMeshAgent _navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        
        InitComponentLinks();

        PickNewPatrolPoint();

    }

    // Update is called once per frame
    void Update()
    {

        NoticePlayerUpdate();
        ChaseUpdate();

        PatrolUpdate();
    }
   
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
    }

    private void NoticePlayerUpdate()
    {
        var directoin = Player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, directoin) < viewAngel)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, directoin, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    private  void PickNewPatrolPoint()
    {
       _navMeshAgent.destination = (patrolPoint[Random.Range(0, patrolPoint.Count)].position);
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {

            if (_navMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
        }
    }


}
