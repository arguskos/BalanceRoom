using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliders : MonoBehaviour {

	// Use this for initialization

    public string Side;
    public SphereMovement Player;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

    void OnTriggerStay()
    {
        print("elli");
       // GameManager.Instance.Player._blockedDirections[Side] = true;
    }
    void OnTriggerExit()
    {
      //  GameManager.Instance.Player._blockedDirections[Side] = false;
    }
}
