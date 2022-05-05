using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeBehaviour : MonoBehaviour
{
	public NavMeshAgent motor;
	public Vector3[] waypoints = new Vector3[6];
	Vector3 target;
	int waypointIndex;
	float waitTime;
	[SerializeField] int numOfPoints;

	public float yPos;

	private void Start()
	{
		motor = GetComponent<NavMeshAgent>();
		GetPoints();
		UpdateDestination();

		Time.timeScale = 0;
	}

	private void Update()
	{

		if (Vector3.Distance(transform.position, target) < 1)
		{
			IterateWaypointIndex();
			UpdateDestination();
		}

		if (Input.GetKeyDown(KeyCode.Space))
			Time.timeScale = 1;
	}

	private void UpdateDestination()
	{
		target = waypoints[waypointIndex];
		motor.SetDestination(target);
	}

	private void IterateWaypointIndex()
	{
		waypointIndex++;
		if (waypointIndex == waypoints.Length)
			waypointIndex = 0;
	}

	public void GetPoints() { waypoints = GameManager.gameInstance.GetWaypoints(numOfPoints); }
}
