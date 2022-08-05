using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMaxHelper
{
    public float Min { get; private set; }
    public float Max { get; private set; }

    public MinMaxHelper()
    {
        Min = float.MaxValue;
        Max = float.MinValue;
    }

    public void AddValue(float v)
    {
        if (v > Max)
        {
            Max = v;
        }
        else if (v < Min)
        {
            Min = v;
        }
    }
}
