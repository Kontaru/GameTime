using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gear
{
    public string name;
    public float speedLimit;
}

[CreateAssetMenu(fileName = "Car")]
public class Car : ScriptableObject {

    public new string name;
    public GameObject model;

    public Gear[] gears;

    [Header("Basic")]
    public float acceleration;
    public float topSpeed;

    [Header("Advanced")]
    public float shiftTime;
}
