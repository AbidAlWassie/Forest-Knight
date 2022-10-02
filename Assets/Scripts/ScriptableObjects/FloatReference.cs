using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FloatReference
{
    public bool UseConstant;
    public float ConstantValue;
    public FloatValue Variable;

    public float value
    {
        get { return UseConstant ? ConstantValue : Variable.value; }
    }
}
