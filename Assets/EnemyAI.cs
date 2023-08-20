using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Animation anim;
    public GameObject Player;
    public EnemyGun EG;

    private UnityEngine.AI.NavMeshAgent agent;
    public List<Transform> waypoints = new List<Transform>();
    private int currentWaypointIndex = 0;
    private bool isChasingPlayer = false;
    private bool isReturningToWaypoint = false;

    private GameObject fishObject;
    private bool isBeingPulled = false;
    private float pullDistance = 1.5f;

    private void Start()
    {
        anim = GetComponent<Animation>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextWaypoint();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);

        if (isBeingPulled && fishObject != null)
        {
            // Move towards the fishObject's position
            Vector3 targetPosition = fishObject.transform.position;
            anim.Play("walk");

            agent.isStopped = false;
            agent.destination = targetPosition;

            float distanceToFish = Vector3.Distance(transform.position, targetPosition);
            if (distanceToFish <= pullDistance)
            {
                agent.isStopped = true;
                isBeingPulled = false;
                isChasingPlayer = false;
                isReturningToWaypoint = true;
                StartCoroutine(ResetIsBeingPulled());
            }
        }
        else if (isChasingPlayer)
        {
            if (distanceToPlayer <= 4)
            {
                isChasingPlayer = false;
                anim.CrossFade("hit2", 0.4f);
                EG.Attack();
            }
            else
            {
                agent.isStopped = false;
                agent.destination = Player.transform.position;
            }
        }
        else if (isReturningToWaypoint)
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
            if (distanceToWaypoint <= 2)
            {
                isReturningToWaypoint = false;
                GotoNextWaypoint();
            }
            else
            {
                agent.isStopped = false;
                agent.destination = waypoints[currentWaypointIndex].position;
            }
        }
        else
        {
            // Idle or other behavior
        }
    }

    public void ReceiveFish(GameObject fish)
    {
        fishObject = fish;
        if (fishObject != null)
        {
            Debug.Log("Received fish!");
            isBeingPulled = true;
        }
    }

    private IEnumerator ResetIsBeingPulled()
    {
        yield return new WaitForSeconds(5.0f);
        isBeingPulled = false;
        isReturningToWaypoint = true;
    }

    private void GotoNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        agent.destination = waypoints[currentWaypointIndex].position;
        anim.Play("walk");
    }
}
