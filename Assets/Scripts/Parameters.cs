using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Parameters : BaseParameters {

	public new static List<ParamsName>  Names = new List<ParamsName>();

	public enum ParamsName
	{
	    NumberWalls,
		TargetSpeed
	};
	 static  Parameters()
	{
		Names.Add(ParamsName.NumberWalls);
		Names.Add(ParamsName.TargetSpeed);

	}

	//TODO MAKE AN INTEFACE
	public static  Parameters.ParamsName GetParameter(Parameters.ParamsName paramName)
	{
		return Names[(int)paramName];
	}
}
