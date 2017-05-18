using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

    // Use this for initialization
    bool useLocalUpVector = true;
    float fauxGravity = -1f;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void  Attract(BallMovement2 body)
    {
        Vector3 gravityUp;
        Vector3 localUp;
        Vector3 localForward;

        Transform t   = body.transform;
        Rigidbody r  = body.GetComponent<Rigidbody>();

        // Figure out the body's up vector
        if (useLocalUpVector)
        {
            gravityUp = transform.up;
        }
        else
        {
            gravityUp = t.position - transform.position;
            gravityUp.Normalize();
        }

        // Accelerate the body along its up vector
        r.AddForce(gravityUp * fauxGravity * r.mass);
        r.drag = body._grounded ? 1 : 0.1f;

        // If the object's freezerotation is set, we force the object upright
        if (r.freezeRotation)
        {
            // Orient relatived to gravity
            localUp = t.up;
            var q = Quaternion.FromToRotation(localUp, gravityUp);
            q = q * t.rotation;
            t.rotation = Quaternion.Slerp(t.rotation, q, 0.1f);
            localForward = t.forward;
        }
    }
}
