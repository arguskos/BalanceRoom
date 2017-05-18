using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class Parameters
{

    public static List<string> Names= new List<string>();

    public enum ParamsName
    {
        WallsAmount,
        TargetSpeed
    };
    static Parameters()
    {
        Names.Add("WallsAmmount");
        Names.Add("TargetSpeed");

    }
}
