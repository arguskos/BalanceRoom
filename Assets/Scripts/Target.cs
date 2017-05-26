using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public GameObject TargetPrefab;
    private GameObject Center;
    public float MaxDirectionChangeTime = 10;
    private float _directionChangeTimer;
    private Vector3 RandomDir;
	// Use this for initialization
	void Start ()
	{
        Center = new GameObject("TargetCenter");
	    var obj =Instantiate(TargetPrefab);
        obj.transform.position = Random.onUnitSphere * GameManager.MyInstance.Radious;
        obj.transform.LookAt(GameManager.MyInstance.Center.transform);
        obj.transform.parent = Center.transform;
	    RandomDir = new Vector3(Random.value, Random.value, Random.value);

    }

    // Update is called once per frame
    void Update ()
	{
	    _directionChangeTimer += Time.deltaTime;
	    if (_directionChangeTimer > MaxDirectionChangeTime)
	    {
	        _directionChangeTimer = 0;
	        RandomDir = new Vector3(Random.value, Random.value, Random.value);
	    }
		print(Parameters.Names[(int)Parameters.ParamsName.TargetSpeed]);
		//Center.transform.Rotate(RandomDir * GameManager.Instance.GetParameter(Parameters.GetParameter(Parameters.ParamsName.TargetSpeed)));// [Parameters.Names[(int)Parameters.ParamsName.TargetSpeed]]);
    }
}
