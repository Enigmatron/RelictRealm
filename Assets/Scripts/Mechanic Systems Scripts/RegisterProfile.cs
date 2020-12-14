using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <Summary>
/// This class manages a set of interdependent values that rely on a max and minimum value and can take additional values to its current value
/// <Summary>
//TODO: it may make it easier to work with if other systems make the dictionary for these values rather than it being baked into the register profile: make it a "managed profile"
public class RegisterStatProfile <Key>
{
    public Dictionary<Key, Register> valuePairs;

    //the base base value that is added to in the current value by the addedvalue list
    public float BaseValue;
    public Dictionary<Key, float> CurrentValue
    {
        get; private set;
    }
    public Dictionary<Key, Dictionary<string, Register>> addedValue;
    public Dictionary<Key, float> MaxValue;

    

    //name is the value that it adds to 
    public void addValue(Key variablename, string name, Register val){
        addedValue[variablename].Add(name, val);

        CurrentValue[variablename] = 0;
        foreach(Register x in addedValue[variablename].Values){
            CurrentValue[variablename] += x.value;
        }

        CurrentValue[variablename] += valuePairs[variablename].value;

        if(CurrentValue[variablename] >= MaxValue[variablename]){
            CurrentValue[variablename] = MaxValue[variablename];
        }

        
    }

    public void removeValue(Key variablename, string name){
        addedValue[variablename].Remove(name);

        CurrentValue[variablename] = 0;
        foreach(Register x in addedValue[variablename].Values){
            CurrentValue[variablename] += x.value;
        }
        CurrentValue[variablename] += valuePairs[variablename].value;
        if (CurrentValue[variablename] >= MaxValue[variablename])
        {
            CurrentValue[variablename] = MaxValue[variablename];
        }    
    }


    public static Builder Initialize()
    {
        Builder temp = new Builder();
        temp.obj = new RegisterStatProfile<Key>();
        return temp;
    }

    public class Builder
    {
        public RegisterStatProfile<Key> obj;


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
        public RegisterStatProfile<Key> Declare()
        {
            obj.addedValue = new Dictionary<Key, Dictionary<string, Register>>();
            return obj;
        }
    }
}