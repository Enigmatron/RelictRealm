using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <Summary>
/// this class manages values such as health stats and so on
/// <Summary>
public class RegisterProfile
{
    ////implement variable enum to remove the need for strings to hold variable name
    // public enum Variables{
    //     [field:Description("Health")]
    //     Health,
    //     Armor,
    //     MoveSpeed,
    //     JumpPower,
        
    // }
    public Dictionary<string, RegisterValue> valuePairs;

    public float BaseValue;
    public Dictionary<string, Dictionary<string, RegisterValue>> addedValue;
    public Dictionary<string, float> MaxValue;

    public Dictionary<string, float> CurrentValue{
        get; private set;
    }

    //name is the value that it adds to 
    public void addValue(string variablename, string name, RegisterValue val){
        addedValue[variablename].Add(name, val);

        CurrentValue[variablename] = 0;
        foreach(RegisterValue x in addedValue[name].Values){
            CurrentValue[variablename] += x.value;
        }
        CurrentValue[variablename] += valuePairs[variablename].value;
        CurrentValue[variablename] = CurrentValue[variablename] >= MaxValue[variablename] ? CurrentValue[name] : MaxValue[variablename];
    }

    public void removeValue(string variablename, string name){
        addedValue[variablename].Remove(name);

        CurrentValue[variablename] = 0;
        foreach(RegisterValue x in addedValue[variablename].Values){
            CurrentValue[variablename] += x.value;
        }
        CurrentValue[variablename] += valuePairs[variablename].value;
        CurrentValue[variablename] = CurrentValue[variablename] >= MaxValue[variablename] ? CurrentValue[name] : MaxValue[variablename];
    }

    

    public static Builder Initialize()
    {
        Builder temp = new Builder();
        temp.obj = new EntityRegisterProfile();
        return temp;
    }

    public class Builder
    {
        public EntityRegisterProfile obj;


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
        public EntityRegisterProfile Declare()
        {
            obj.addedValue = new Dictionary<string, Dictionary<string, RegisterValue>>();
            return obj;
        }
    }
}