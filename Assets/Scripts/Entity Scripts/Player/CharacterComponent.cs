using UnityEngine;
using UnityEngine.Networking;
using System.Collections;



public enum EntityTeam{
    Iota,
    Eta,
    Neutral, //they are attackable
    NPC, // they cant be attacked
}
public enum EntityID{
    Kenjinn,
    Tower
}
public abstract class CharacterComponent : Component{
    // ValueProfile statProfile;
    EntityTeam team;
    EntityID id;
    

    public void setValue(string name, float val){
        // if(statProfile.valuePairs.TryGetValue(name)){

        // = val;
        // }
    }
    public void setAddValue(string name, float val){
    //     if(statProfile.valuePairs.TryGetValue)
    //     statProfile.valuePairs[name].addedValue += val;

    }
}