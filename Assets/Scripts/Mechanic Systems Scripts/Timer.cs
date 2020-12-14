using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//TODO add an abstract class that allows classes to be added to a list and then remove themselves
//Just a simple timer that has its Value tracked
public class Timer
{
    UnityEvent onCompletion;
    Register value;
    float maxTime;
    public void Reset()
    {
        value.reset();
    }
    public void Update()
    {
        if (maxTime <= value.value)
        {
            onCompletion.Invoke();
            return;
        }
        else
        {
            value.setValue(Time.deltaTime);
        }

    }



    public class Builder
    {
        Timer obj;

        public Builder()
        {
            obj = new Timer();
        }
        public Builder setOnCompletion(UnityAction action){
            obj.onCompletion.AddListener(action);
            return this;
        }
        public Builder setMaxTime(float val){
            obj.maxTime = val;
            return this;
        }
        public Timer Initial(float val)
        {
            obj.value = new Register();
            return obj;
        }

    }
}
