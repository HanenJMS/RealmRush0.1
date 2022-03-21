using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;
    [SerializeField] float distanceToDestination = 1f;
    [SerializeField] [Range(0, 5f)]float speed = 1f;
    //NavMeshAgent agent;
    Vector3 currentPosition;
    private void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        StartCoroutine(FollowPath());
    }
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startingPosition = this.transform.position;
            Vector3 endingPosition = waypoint.transform.position;
            float travelPercentage = 0f;
            transform.LookAt(endingPosition);
            while(travelPercentage < 1f)
            {
                travelPercentage += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startingPosition, endingPosition, travelPercentage);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private void UseAgentNav(Waypoint waypoint)
    {
        //currentPosition = this.transform.position;
        //Debug.Log(waypoint.name);
        //agent.SetDestination(waypoint.transform.position);
        //distanceToDestination = Vector3.Distance(currentPosition, waypoint.transform.position);
        //waitTime = distanceToDestination / agent.speed;
    }
}
