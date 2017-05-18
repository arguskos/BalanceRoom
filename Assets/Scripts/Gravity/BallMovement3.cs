using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement3 : MonoBehaviour
{
    public float MoveSpeed = 15;
    private Vector3 _moveDir;
    private Rigidbody _rigid;
	// Use this for initialization
	void Start ()
	{
	    _rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
       bool _directionLeft = Input.GetKey(KeyCode.A);
       bool _directionRight = Input.GetKey(KeyCode.D);
       bool _directionUp = Input.GetKey(KeyCode.W);
       bool _directionDown = Input.GetKey(KeyCode.S);



        Vector3 endDir = new Vector3(0, 0, 0);
        if (_directionDown)
            endDir += Vector3.back;
        if (_directionUp)
            endDir += Vector3.forward;
        if (_directionLeft)
            endDir += Vector3.left;
        if (_directionRight)
            endDir += Vector3.right;
        _moveDir = endDir;
	}

    void FixedUpdate()
    {
        _rigid.MovePosition(_rigid.position+transform.TransformDirection(_moveDir)*MoveSpeed*Time.deltaTime);
    }
}
