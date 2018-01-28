using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftMode : MonoBehaviour {

    public bool BL_Drifting;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!BL_Drifting) return;


	}

    public void On()
    {
        BL_Drifting = true;
    }

    public void Off()
    {
        BL_Drifting = false;
    }
}
