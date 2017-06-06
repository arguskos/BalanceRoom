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
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	protected override void   Update () {
		base.Update();

	}
}
