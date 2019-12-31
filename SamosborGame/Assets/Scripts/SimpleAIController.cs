using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAIController : MonoBehaviour
{
    /*
    public GameObject target;
    public bool followTarget = true;
    public float speed = 10f;
    public float stoppingDistance = 0;
    public float range = 10f;

    // Update is called once per frame
    void Update()
    {
        if(followTarget)
        {
            Seek();
        }
    }
    private void Seek()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance > stoppingDistance && distance < range)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 12 * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        
    }
    */
    public float range = 10f;
    public GameObject target; 

    NavMeshAgent agent;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
