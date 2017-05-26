using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GameManagerBase {

	public int Radious =10;
	public static GameManager MyInstance;
	void Awake()
	{
		if (MyInstance==null)
		{
			MyInstance=this;
		}
	} 
	public GameObject Center;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
