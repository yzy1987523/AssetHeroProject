using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISetValue {    
    void SetValue(MorphingValueType _index,ValueData _value);    
} 
public interface ISelectable
{
    void Select();
    void QuitSelect();
}

