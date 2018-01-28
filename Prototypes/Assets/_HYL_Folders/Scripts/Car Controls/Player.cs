using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    public Car settings;

    public enum ShiftState
    {
        None,
        Cruising,
        Draft,
        Drift,
        Crashed
    }

    public ShiftState State;

    public GameObject destination;
    public static NavMeshAgent nav_agent;
    CruiseMode Cruising;
    DraftMode Drafting;
    DriftMode Drifting;

    public float MPH;
    public float KPH;

    // Use this for initialization
    void Start()
    {
        nav_agent = GetComponent<NavMeshAgent>();

        Cruising = GetComponent<CruiseMode>();
        Drafting = GetComponent<DraftMode>();
        Drifting = GetComponent<DriftMode>();
    }

    // Update is called once per frame
    void Update()
    {
        nav_agent.destination = destination.transform.position;

        MPH = nav_agent.speed * 2.237f;
        KPH = nav_agent.speed * 3.6f;

        if (State == ShiftState.Draft)
        {
            Drifting.Off();
            Drafting.On();
            Cruising.Off();
        }else if (State == ShiftState.Drift)
        {
            Drifting.On();
            Drafting.Off();
            Cruising.Off();
        }
        else if (State == ShiftState.Cruising)
        {
            Drifting.Off();
            Drafting.Off();
            Cruising.On();
        }
        else if (State == ShiftState.Crashed)
        {
            Drifting.Off();
            Drafting.Off();
            Cruising.Off();
        }

    }
}
