using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwapper : MonoBehaviour {

    public Player.ShiftState newState;

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            Player vPlayer = other.GetComponent<Player>();
            if(vPlayer != null)
            {
                vPlayer.State = newState;
            }
        }
    }
}
