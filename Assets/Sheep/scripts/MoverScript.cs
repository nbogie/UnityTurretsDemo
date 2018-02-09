using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoverScript : MonoBehaviour
{

	private GameObject[] targets;
	private NavMeshAgent navMeshAgent;

	void Start ()
	{
		targets = GameObject.FindGameObjectsWithTag ("Waypoint");
		navMeshAgent = GetComponent<NavMeshAgent> ();
		InvokeRepeating ("SetRandomDestination", Random.Range(1f,3f), Random.Range(3f,7f));
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			SetRandomDestination ();
		}
	}

	void SetRandomDestination ()
	{
		GameObject target = targets [Random.Range (0, targets.Length)];
		navMeshAgent.SetDestination (target.transform.position);
	}
}
