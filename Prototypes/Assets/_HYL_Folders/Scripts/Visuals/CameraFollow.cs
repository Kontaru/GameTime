using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //Camera look references
    public static GameObject PlayerRef;
    public static GameObject otherLook;          //Reference to anything else we want to look at

    //Camera follow speeds - camera lerps between values for a more cinematic look!
    public float smoothSpeed = 2f;
    public float playerfollowSmoothSpeed = 10f;
    float FL_folSpeed = 1;

    //Camera rotate speeds - Camera will whip back and forth smoothly to give the feeling of momentum
    public float rotateSpeed;
    public float playerfollowRotateSpeed;
    [SerializeField]
    float FL_rotSpeed = 1;

    private void Start()
    {
        FL_folSpeed = smoothSpeed;
        FL_rotSpeed = rotateSpeed;
    }

    // Use this for initialization
    void Update () {

        //If we have an otherLook target, then look at that instead
        if (otherLook != null)
        {
            Follow(otherLook);
            if (Vector3.Distance(transform.position, otherLook.transform.position) < 1.0f)
                StartCoroutine(StopLooking(otherLook));
        }
        //Otherwise if the player ref is stated, do the follow
        else if (PlayerRef != null)
        {
            Follow(PlayerRef);
        }


    }

    //Parents an object to another thing
    void Follow(GameObject parentGo)
    {
        //Position
        if (Vector3.Distance(transform.position, parentGo.transform.position) < 10.0f)
            FL_folSpeed = Mathf.Lerp(FL_folSpeed, playerfollowSmoothSpeed, Time.deltaTime);
        else
            FL_folSpeed = Mathf.Lerp(FL_folSpeed, smoothSpeed, Time.deltaTime);

        transform.position = Vector3.Lerp(transform.position, parentGo.transform.position, FL_folSpeed * Time.deltaTime);

        //Rotation
        if (Quaternion.Angle(transform.rotation, parentGo.transform.rotation) < 1.0f)
            FL_rotSpeed = Mathf.Lerp(FL_rotSpeed, playerfollowRotateSpeed, Time.deltaTime);
        else
            FL_rotSpeed = Mathf.Lerp(FL_rotSpeed, rotateSpeed, Time.deltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, parentGo.transform.rotation, FL_folSpeed * Time.deltaTime);
    }

    //After a few seconds, make the thing we're looking at = null, which should stop the camera from ever tracking this item.
    IEnumerator StopLooking(GameObject parentGO)
    {
        yield return new WaitForSeconds(3.0f);
        parentGO = null;
    }
}
