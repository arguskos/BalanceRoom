﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameObject Player;
    public GameObject Center;
    public float Radiuos;

    public GameMoment[] Moments;
    public int WallsToPlace;
    public float TargetSpeed;
    public int MinSpeedTarget;

    public float GameTime = 20;
    private float _passedTime;
    private int _currentMoment;
    public List<Dictionary<string, MinMaxPair>> AllData = new List<Dictionary<string, MinMaxPair>>();
    public Dictionary<string,float > ReturnInfo = new Dictionary<string, float>();
    enum Parametrs { TargetSpeed,WallsAmout}
    public float GetParametr(string name)
    {
        return ReturnInfo[name];
    }

    /// <summary>
    /// Create serise of parameters with name (moments)
    /// game manager interpolate between time with min max moments
    /// All who needs this info can take it
    /// For every object in a scene with interface bla call function do on spread calls....
    /// 
    /// </summary>
    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start()
    {
        TargetSpeed = Moments[_currentMoment].MinTargetSpeed;
        WallsToPlace = Moments[_currentMoment].MinWalls;
        //get all data 
        foreach (var entery in AllData[0])
        {
            ReturnInfo.Add(entery.Key,entery.Value.Min);

        }
    }

    private void OnRoomEnter()
    {
        //connect to server 
    }

    private void OnRoomExit()
    {
        //send score...
    }
    public void OnNewMoment()
    {
        WallsPlacer.Instance.OnNewMoment();
    }

    // Update is called once per frame
    void Update()
    {
        _passedTime += Time.deltaTime;
        //print((_passedTime - GameTime / Moments.Length * _currentMoment+GameTime/Moments.Length) / 3.333*(_currentMoment+1));
        //print((GameTime / Moments.Length * (_currentMoment + 1)));
        if (_currentMoment < Moments.Length )
        {
            float percentageForCurrentMoment = (_passedTime - (GameTime / Moments.Length * _currentMoment)) / (GameTime / Moments.Length);
            //TargetSpeed = (Moments[_currentMoment].MaxTargetSpeed- Moments[_currentMoment].MinTargetSpeed )* percentageForCurrentMoment;
            //WallsToPlace =(int)((Moments[_currentMoment].MaxWalls - Moments[_currentMoment].MinWalls) * percentageForCurrentMoment );

            foreach (var entery in AllData[_currentMoment])
            {
                ReturnInfo[entery.Key] = (entery.Value.Max - entery.Value.Min)*percentageForCurrentMoment;
            }

            if (_passedTime > GameTime / Moments.Length * (_currentMoment+1))
            {
                print(_currentMoment);
                _currentMoment++;
                OnNewMoment();
            }
        }
    }
}
