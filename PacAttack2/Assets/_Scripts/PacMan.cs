using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PacMan : MonoBehaviour {

	public Transform destination;

	private NavMeshAgent agent;

	void Update () 
	{
		agent = gameObject.GetComponent<NavMeshAgent>();

		agent.SetDestination(destination.position);
	}

}
	