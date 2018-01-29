using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    public Car car_Settings;

    public enum ShiftState
    {
        None,
        Cruising,
        Drag,
        Drift,
        Crashed
    }

    public enum Gear
    {
        None,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6
    }

    public ShiftState State;
    public Gear CurrentGear;

    public GameObject destination;
    public static NavMeshAgent nav_agent;
    DraftMode Drafting;
    DriftMode Drifting;

    public static float MPH;
    public static float KPH;
    public float BL_speedLimit;

    // Use this for initialization
    void Start()
    {
        nav_agent = GetComponent<NavMeshAgent>();

        Drafting = GetComponent<DraftMode>();
        Drifting = GetComponent<DriftMode>();

        CurrentGear = Gear.One;
        nav_agent.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        nav_agent.destination = destination.transform.position;

        SetSpeedLimit();
        Accelerate();

        if (State == ShiftState.Drag)
        {
            Drifting.Off();
            Drafting.On();
        }else if (State == ShiftState.Drift)
        {
            Drifting.On();
            Drafting.Off();
        }
        else if (State == ShiftState.Cruising)
        {
            Drifting.Off();
            Drafting.Off();
            Cruising();
        }
        else if (State == ShiftState.Crashed)
        {
            Drifting.Off();
            Drafting.Off();
        }

    }

    void SetSpeedLimit()
    {
        if (State == ShiftState.Drag)
        {
            if (CurrentGear == Gear.Six)
            {
                BL_speedLimit = car_Settings.gears[5].speedLimit;
            }
            else if (CurrentGear == Gear.Five)
            {
                BL_speedLimit = car_Settings.gears[4].speedLimit;
            }
            else if (CurrentGear == Gear.Four)
            {
                BL_speedLimit = car_Settings.gears[3].speedLimit;
            }
            else if (CurrentGear == Gear.Three)
            {
                BL_speedLimit = car_Settings.gears[2].speedLimit;
            }
            else if (CurrentGear == Gear.Two)
            {
                BL_speedLimit = car_Settings.gears[1].speedLimit;
            }
            else if (CurrentGear == Gear.One)
            {
                BL_speedLimit = car_Settings.gears[0].speedLimit;
            }
        }
    }

    void Accelerate()
    {
        if (MPH > BL_speedLimit)
            nav_agent.speed = Random.Range(BL_speedLimit / 2.237f, BL_speedLimit / 2.237f + 2.0f);
        else
            nav_agent.speed += car_Settings.acceleration * Time.deltaTime;

        MPH = nav_agent.speed * 2.237f;
        KPH = nav_agent.speed * 3.6f;
    }

    void Cruising()
    {
        
    }

    void ShiftUp()
    {
        int vGear = (int)CurrentGear;
        vGear += 1;
        CurrentGear = (Gear)vGear;
    }

    void ShiftDown()
    {
        int vGear = (int)CurrentGear;
        vGear -= 1;
        CurrentGear = (Gear)vGear;
    }
}
