using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractedObject : MonoBehaviour
{
    public PlanterAttractor Attractor;
	// Use this for initialization
	void Start ()
	{
	    GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Attractor.Attract(transform);
	}
}
