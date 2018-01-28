using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiseMode : MonoBehaviour {

    public bool BL_Cruising;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!BL_Cruising) return;

	}

    public void On()
    {
        BL_Cruising = true;
    }

    public void Off()
    {
        BL_Cruising = false;
    }
}
