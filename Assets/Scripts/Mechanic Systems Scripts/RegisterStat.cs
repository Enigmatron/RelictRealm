using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RegisterStat
{
    public Register valuePairs;

    //the base base value that is added to in the current value by the addedvalue list
    public float BaseValue;
    public float CurrentValue
    {
        get; private set;
    }
    public Dictionary<string, Register> addedValue;
    public float MaxValue;



    //name is the value that it adds to 
    public void addValue(string name, Register val)
    {
        addedValue.Add(name, val);

        CurrentValue = 0;
        foreach (Register x in addedValue.Values)
        {
            CurrentValue += x.value;
        }

        CurrentValue += valuePairs.value;

        if (CurrentValue >= MaxValue)
        {
            CurrentValue = MaxValue;
        }


    }

    public void removeValue(string name)
    {
        addedValue.Remove(name);

        CurrentValue = 0;
        foreach (Register x in addedValue.Values)
        {
            CurrentValue += x.value;
        }
        CurrentValue += valuePairs.value;
        if (CurrentValue >= MaxValue)
        {
            CurrentValue = MaxValue;
        }
    }


    public static Builder Initialize()
    {
        Builder temp = new Builder();
        temp.obj = new RegisterStat();
        return temp;
    }

    public class Builder
    {
        public RegisterStat obj;


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
        public RegisterStat Declare()
        {
            obj.addedValue = new Dictionary<string, Register>();
            return obj;
        }
    }
}