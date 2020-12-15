using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <Summary>
/// This class is meant to have all registers update if one updates
/// <Summary>
//TODO: it may make it easier to work with if other systems make the dictionary for these values rather than it being baked into the register profile: make it a "managed profile"
public class RegisterProfile <Key>
{
    public Dictionary<Key, RegisterStat> profile;


    //TODO: add interdependency updating 
    

    //name is the value that it adds to 
    public void addValue(Key variablename, string name, Register val){
        profile[variablename].addValue(name, val);
    }

    public void removeValue(Key variablename, string name){
        profile[variablename].removeValue(name);
    }


    public static Builder Initialize()
    {
        Builder temp = new Builder();
        temp.obj = new RegisterProfile<Key>();
        return temp;
    }


    //TODO: make it so that once you've gotten every builder done then its done.
    public class Builder
    {
        public RegisterProfile<Key> obj;
        public Dictionary<Key, RegisterStat.Builder> dict;

        // public Builder Define_Base_Value(float val)
        // {
        //     obj.BaseValue = val;
        //     return this;
        // }

        // public Builder Define_Max_Value(float val)
        // {
        //     obj.BaseValue = val;
        //     return this;
        // }
        // public RegisterStatProfile<Key> Declare()
        // {
        //     obj.addedValue = new Dictionary<Key, Dictionary<string, Register>>();
        //     return obj;
        // }
    }
}