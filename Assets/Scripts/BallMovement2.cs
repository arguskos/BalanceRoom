using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement2 : MonoBehaviour {

	// Use this for initialization
    public Attractor Attractor;
    public bool _grounded;
    private Rigidbody _rigid;
    void Start ()
    {
        _rigid = GetComponent<Rigidbody>();
        _rigid.WakeUp();
        _rigid.useGravity = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
     print("grounded");  
            _grounded=true;
    }
      void OnCollisionExit(Collision col)
    {
            _grounded=false;
    }
    void FixedUpdate()
    {
        if (Attractor)
        {
            Attractor.Attract(this);
        }
    }
}
