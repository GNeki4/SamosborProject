using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIController : MonoBehaviour
{
    public float range = 10f;
    public GameObject target;
    public Vector3 start;

    NavMeshAgent agent;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        start = transform.position; //
    }

    public void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= range)
        {
            agent.SetDestination(target.transform.position);

            if (distance <= agent.stoppingDistance)
            {
                //attack
                FaceTarget();
            }
        }
        else
        {
            agent.SetDestination(start);
        }
    }

    public void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
