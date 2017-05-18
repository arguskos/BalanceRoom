using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

	// Use this for initialization
    public GameObject Player;
    public Material Infront;
    public Material Behind;     
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    //transform.position = Player.transform.position;
	    //transform.position += transform.forward*20;
       // transform.LookAt(Player.transform);

    
    }

    void FixedUpdate()
    {

        var heading = transform.position - Player.transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance; 

                //Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(transform.position, -direction);// Physics.Raycast(transform.position, fwd);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform==Player.transform)
                hit.transform.GetComponent<Renderer>().material = Infront;
            else
            {
                Player.GetComponent<Renderer>().material = Behind;

            }
        }
        
    }
}
