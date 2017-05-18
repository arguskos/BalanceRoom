﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameMoment", menuName = "Moment", order = 1)]
public class GameMoment : ScriptableObject {

	// Use this for initialization
    public float MinWalls;
    public float MaxWalls;
    public string Walls=Parameters.Names[(int)Parameters.ParamsName.WallsAmount];

    public float MinTargetSpeed;
    public float MaxTargetSpeed;
    public string Target = Parameters.Names[(int)Parameters.ParamsName.TargetSpeed];

    public Dictionary<string, MinMaxPair> MomentInfo;    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
