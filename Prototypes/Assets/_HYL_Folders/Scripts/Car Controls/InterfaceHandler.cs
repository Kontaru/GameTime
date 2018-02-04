using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfaceHandler : MonoBehaviour {

    Player Car;

    public TextMeshProUGUI Speed;

    // Use this for initialization
    void Start () {
        Car = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        Speed.text = string.Format("" + Mathf.Round(Player.MPH));
	}
}
