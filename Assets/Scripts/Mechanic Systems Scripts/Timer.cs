using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;



//TODO: add an abstract class that allows classes to be added to a list and then remove themselves
//Just a simple timer that has its Value tracked
public class Timer
{
    UnityEvent onCompletion;
    UnityEvent onStarted;

    public UnityEvent<float> onReset
    {
        get
        {
            return value.OnReset;
        }
    }
    public UnityEvent<float> OnChange
    {
        get
        {
            return value.OnChange;
        }
    }
    public Register value
    {
        get;
        protected
        set;
    }
    public float maxTime
    {
        get;
        protected
        set;
    }
    public bool started
    {
        get;
        protected
        set;
    }
    public void Reset()
    {
        value.reset();
    }
    public void Update()
    {
        if (started)
        {
            if (maxTime > value.value)
            {

                value.updateValue(Time.deltaTime);
            }
            else
            {
                onCompletion.Invoke();
            }
        }
    }

    public class Builder
    {
        Timer obj;
        public Builder()
        {
            obj = new Timer();
        }
        public Builder set_OnCompletion(UnityAction action)
        {
            obj.onCompletion.AddListener(action);
            return this;
        }
        public Builder set_MaxTime(float val)
        {
            obj.maxTime = val;
            return this;
        }
        public Timer initialize(float val)
        {
            obj.value = new Register();
            return obj;
        }

        public Builder set_Value(Register val)
        {
            obj.value = val;
            return this;
        }

        public Builder add_OnCompletionListener(UnityAction val)
        {
            obj.onCompletion.AddListener(val);
            return this;
        }
        public Builder add_OnStartedListener(UnityAction val)
        {
            obj.onCompletion.AddListener(val);
            return this;
        }
    }
}
