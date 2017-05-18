using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class BallMovement : MonoBehaviour {

	// Use this for initialization
    private bool _directionLeft;
    private bool _directionRight;
    private bool _directionUp;
    private bool _directionDown;
    private bool _directionUpRight;
    private bool _directionUpLeft;
    private bool _directionDownLeft;
    private bool _directionDownRight;
    private Rigidbody _rigid;
    public GameObject Center;
    void Start ()
    {
        _rigid = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	    _directionLeft = Input.GetKey(KeyCode.A);
        _directionRight = Input.GetKey(KeyCode.D);
	    _directionUp = Input.GetKey(KeyCode.W);
        _directionDown = Input.GetKey(KeyCode.S);


        




        Vector3 endDir = new Vector3(0,0,0);
	    if (_directionDown)
	        endDir +=  transform.up;
	    if (_directionUp)
	        endDir += -transform.up;
	    if (_directionLeft)
	        endDir += -transform.right;
	    if (_directionRight)
	        endDir += transform.right;
        if (_directionUpRight)
            endDir += new Vector3(1, 0, 1);
        if (_directionUpLeft)
            endDir += new Vector3(-1, 0, 1);
        if (_directionDownRight)
            endDir += new Vector3(1, 0, -1);
        if (_directionDownLeft)
            endDir += new Vector3(-1, 0, -1);
        print(endDir);
        //if(_rigid.velocity.magnitude<3)
        //    _rigid.AddForce(endDir,ForceMode.Acceleration);
        //
        Vector3 forceDirection = transform.position - Center.transform.position;

        // apply force on targettowards  me
        //_rigid.AddForce(-forceDirection.normalized * 1 * Time.fixedDeltaTime);
	    if (endDir == Vector3.zero)
	    {
	       _rigid.velocity=Vector3.zero;
	    }
        Vector3 gravityDirection = -(transform.position - Center.transform.position).normalized;
        //transform.LookAt(Center.transform);
        _rigid.AddForce(gravityDirection*10 );
        //if (_rigid.velocity.magnitude<5)
	   // endDir -= transform.forward;
       //_rigid.AddRelativeForce(endDir*20);
    }
}
