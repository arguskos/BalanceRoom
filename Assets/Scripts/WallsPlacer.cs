using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsPlacer : MonoBehaviour {

	// Use this for initialization
    public GameObject Wall;
    public static WallsPlacer Instance;
    public  List<GameObject> Walls;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
	void Start ()
	{
	    for (int i = 0; i < 23; i++)
	    {
	        PlaceWall();
	    }

    }
    public  void  OnNewMoment()
    {
        foreach (var wall in Walls)
        {
            Destroy(wall.gameObject);
        }
    }
    public void PlaceWall()
    {
        var wall = Instantiate(Wall);
        //Vector3 randPoint = Random.onUnitSphere*GameManager.Instance.Radiuos;
        float wallWidth = 18;
        bool foundPlace = false;
        while (!foundPlace)
        {
            Vector3 randPoint = Random.onUnitSphere * GameManager.MyInstance.Radious;
            foundPlace = true;
            foreach (var w in Walls)
            {
                if (Vector3.Distance(randPoint, transform.position) < wallWidth)
                {
                    foundPlace = false;
                }
                
            }

        }

        wall.transform.position =Random.onUnitSphere * GameManager.MyInstance.Radious;
        wall.transform.LookAt(GameManager.MyInstance.Center.transform);
        Walls.Add(wall);

    }
	// Update is called once per frame
	void Update () {
		
	}
}
