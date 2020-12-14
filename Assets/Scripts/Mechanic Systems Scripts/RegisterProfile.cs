using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <Summary>
/// this class manages values such as health stats and so on
/// <Summary>
public class RegisterProfile <Key>
{
    public Dictionary<Key, RegisterValue> valuePairs;

    public float BaseValue;
    public Dictionary<Key, Dictionary<string, RegisterValue>> addedValue;
    public Dictionary<Key, float> MaxValue;

    public Dictionary<Key, float> CurrentValue{
        get; private set;
    }

    //name is the value that it adds to 
    public void addValue(Key variablename, string name, RegisterValue val){
        addedValue[variablename].Add(name, val);

        CurrentValue[variablename] = 0;
        foreach(RegisterValue x in addedValue[variablename].Values){
            CurrentValue[variablename] += x.value;
        }
        CurrentValue[variablename] += valuePairs[variablename].value;
        CurrentValue[variablename] = CurrentValue[variablename] >= MaxValue[variablename] ? CurrentValue[variablename] : MaxValue[variablename];
    }

    public void removeValue(Key variablename, string name){
        addedValue[variablename].Remove(name);

        CurrentValue[variablename] = 0;
        foreach(RegisterValue x in addedValue[variablename].Values){
            CurrentValue[variablename] += x.value;
        }
        CurrentValue[variablename] += valuePairs[variablename].value;
        CurrentValue[variablename] = CurrentValue[variablename] >= MaxValue[variablename] ? CurrentValue[variablename] : MaxValue[variablename];
    }

    
    public static Builder Initialize()
    {
        Builder temp = new Builder();
        temp.obj = new RegisterProfile<Key>();
        return temp;
    }

    public class Builder
    {
        public RegisterProfile<Key> obj;


        public Builder Define_Base_Value(float val)
        {
            obj.BaseValue = val;
            return this;
        }

        public Builder Define_Max_Value(float val)
        {
            obj.BaseValue = val;
            return this;
        }
        public RegisterProfile<Key> Declare()
        {
            obj.addedValue = new Dictionary<Key, Dictionary<string, RegisterValue>>();
            return obj;
        }
    }
}