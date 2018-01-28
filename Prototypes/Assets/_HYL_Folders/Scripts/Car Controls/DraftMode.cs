using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraftMode : MonoBehaviour {

    public bool BL_Drafting;
    Player playerSettings;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!BL_Drafting) return;


	}

    public void On()
    {
        BL_Drafting = true;
    }

    public void Off()
    {
        BL_Drafting = false;
    }
}
