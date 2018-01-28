using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerRef : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CameraFollow.PlayerRef = gameObject;
	}
}
