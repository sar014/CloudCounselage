using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Unity.VisualScripting;

public class AssignPoint : MonoBehaviour
{
    [SerializeField] PointManager pointManager;
    [SerializeField] CharacterAnimation characterAnimation;
    [SerializeField] float minInterval = 10f;
    [SerializeField] float maxInterval = 20f;
    NavMeshAgent agent;
    Timer timer;
    Transform target;

    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        timer = new Timer();
        StartCoroutine(MoveAtIntervals());
    }

    IEnumerator MoveAtIntervals()
    {
        while (true)
        {
            float interval = timer.GetRandomInterval(minInterval, maxInterval);
            yield return new WaitForSeconds(interval);

            Vector3 point = pointManager.GetRandomPoints();
            if (point != Vector3.zero)
            {
                agent.SetDestination(point);
                characterAnimation.SetWalking(true);
                target = pointManager.GetTargetTransform(point);
            }

            // Wait until the agent reaches the destination
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

            characterAnimation.SetWalking(false);
        }
    }

    void Update()
    {
        // Rotate agent towards the target point
        if (target != null)
        {
            RotateAgentTowardsTarget();
        }
    }

    private void RotateAgentTowardsTarget()
    {
        Vector3 directionToTarget = target.position - transform.position;
        if (directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, agent.angularSpeed * Time.deltaTime);
        }
    }
}
