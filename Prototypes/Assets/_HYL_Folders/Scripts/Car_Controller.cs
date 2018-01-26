using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Car_Controller : MonoBehaviour {

    public GameObject destination;
    NavMeshAgent nav_agent;

	// Use this for initialization
	void Start () {
        nav_agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        nav_agent.destination = destination.transform.position;
    }
}
